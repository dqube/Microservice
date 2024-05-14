using CompanyName.MyProjectName.BuildingBlocks.Abstractions;
using CompanyName.MyProjectName.BuildingBlocks.Abstractions.Dispatchers;
using CompanyName.MyProjectName.BuildingBlocks.API.CORS;
using CompanyName.MyProjectName.BuildingBlocks.API.Exceptions;
using CompanyName.MyProjectName.BuildingBlocks.API.Networking;
using CompanyName.MyProjectName.BuildingBlocks.API.Swagger;
using CompanyName.MyProjectName.BuildingBlocks.Contexts;
using CompanyName.MyProjectName.BuildingBlocks.HTTP;
using CompanyName.MyProjectName.BuildingBlocks.Messaging;
using CompanyName.MyProjectName.BuildingBlocks.Observability;
using CompanyName.MyProjectName.BuildingBlocks.Observability.Logging;
using CompanyName.MyProjectName.BuildingBlocks.Observability.Metrics;
using CompanyName.MyProjectName.BuildingBlocks.Observability.Tracing;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace CompanyName.MyProjectName.BuildingBlocks.Framework;

public static class Extensions
{
    public static WebApplicationBuilder AddMicroFramework(this WebApplicationBuilder builder)
    {
        // builder.AddVault();
        var appOptions = builder.Configuration.GetSection("app").BindOptions<AppOptions>();
        var appInfo = new AppInfo(appOptions.Name, appOptions.Version);
        builder.Services.AddSingleton(appInfo);

        RenderLogo(appOptions);

        builder
            .AddLogging().Services
            .AddErrorHandling()
            .AddHandlers(appOptions.Project)
            .AddDispatchers()
            .AddContexts()
            .AddMemoryCache()
            .AddHttpContextAccessor()
            .AddMicro(builder.Configuration)

            // .AddAuth(builder.Configuration)
            .AddCorsPolicy(builder.Configuration)
            .AddSwaggerDocs(builder.Configuration)
            .AddHeadersForwarding(builder.Configuration)
            .AddMessaging(builder.Configuration)
            .AddHealthCheck(builder.Configuration)

             .AddMetrics(builder.Configuration)
             .AddTracing(builder.Configuration)

            // .AddConsul(builder.Configuration)
            // .AddFabio(builder.Configuration)
            // .AddSecurity(builder.Configuration)
            .AddLogger(builder.Configuration);

        builder.Services
            .AddHttpClient(builder.Configuration)
            .AddContextHandler();

        // .AddVaultCertificatesHandler(builder.Configuration);
        // .AddConsulHandler()
        // .AddFabioHandler();

        // builder.Services
        //     .AddMessagingMetricsDecorators()
        //     .AddMessagingTracingDecorators();
        return builder;
    }

    public static WebApplication UseMicroFramework(this WebApplication app)
    {
        app
            .UseHeadersForwarding()
            .UseCorsPolicy()
            .UseErrorHandling()
            .UseSwaggerDocs()

            // .UseAuthentication()
            .UseRouting()

            // .UseMetrics()
            // .UseAuthorization()
            .UseContexts()
            .UseContextLogger();

        return app;
    }

    private static void RenderLogo(AppOptions app)
    {
        if (string.IsNullOrWhiteSpace(app.Name))
        {
            return;
        }

        Console.WriteLine($"{app.Name} {app.Version}");
    }
}