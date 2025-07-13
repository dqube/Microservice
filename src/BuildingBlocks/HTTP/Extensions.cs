using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using CompanyName.MyProjectName.BuildingBlocks.Abstractions;
using CompanyName.MyProjectName.BuildingBlocks.HTTP;
using CompanyName.MyProjectName.BuildingBlocks.HTTP.LoadBalancing;
using CompanyName.MyProjectName.BuildingBlocks.HTTP.Logging;
using CompanyName.MyProjectName.BuildingBlocks.HTTP.ServiceDiscovery;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Http;
using Polly;
using Polly.Extensions.Http;

namespace CompanyName.MyProjectName.BuildingBlocks.HTTP;

public static class Extensions
{
    public static IHttpClientBuilder AddHttpClient(this IServiceCollection services, IConfiguration configuration)
    {
        var httpClientSection = configuration.GetSection("httpClient");
        var httpClientOptions = httpClientSection.Get<HttpClientOptions>() ?? new HttpClientOptions();
        services.Configure<HttpClientOptions>(httpClientSection);

        var consulOptions = configuration.GetSection("consul").Get<ConsulOptions>() ?? new ConsulOptions();
        var fabioOptions = configuration.GetSection("fabio").Get<FabioOptions>() ?? new FabioOptions();

        var builder = services
            .AddHttpClient(httpClientOptions.Name)
            .AddTransientHttpErrorPolicy(_ => HttpPolicyExtensions.HandleTransientHttpError()
                .WaitAndRetryAsync(httpClientOptions.Resiliency.Retries, retry =>
                    httpClientOptions.Resiliency.Exponential
                        ? TimeSpan.FromSeconds(Math.Pow(2, retry))
                        : httpClientOptions.Resiliency.RetryInterval ?? TimeSpan.FromSeconds(2)));

        var certificateLocation = httpClientOptions.Certificate?.Location;
        if (httpClientOptions.Certificate is not null && !string.IsNullOrWhiteSpace(certificateLocation))
        {
            var certificate = X509CertificateLoader.LoadPkcs12(File.ReadAllBytes(certificateLocation), httpClientOptions.Certificate.Password);
            builder.ConfigurePrimaryHttpMessageHandler(() =>
            {
                var handler = new HttpClientHandler();
                if (certificate is not null)
                {
                    handler.ClientCertificates.Add(certificate);
                }

                return handler;
            });
        }

        if (httpClientOptions.RequestMasking?.Enabled == true)
        {
            builder.Services.Replace(ServiceDescriptor.Singleton<IHttpMessageHandlerBuilderFilter, HttpLoggingFilter>());
        }

        if (string.IsNullOrWhiteSpace(httpClientOptions.Type))
        {
            return builder;
        }

        return httpClientOptions.Type.ToLowerInvariant() switch
        {
            "consul" => consulOptions.Enabled ? builder.AddConsulHandler() : builder,
            "fabio" => fabioOptions.Enabled ? builder.AddFabioHandler() : builder,
            _ => throw new InvalidOperationException($"Unsupported HTTP client type: '{httpClientOptions.Type}'.")
        };
    }
}
