using Azure.Identity;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.AzureAppConfiguration;
using Microsoft.Extensions.DependencyInjection;

namespace CompanyName.MyProjectName.BuildingBlocks.Security.Vault;

public static class Extensions
{
    private const string SectionName = "vault";

    public static WebApplicationBuilder AddVault(this WebApplicationBuilder builder)
    {
        var section = builder.Configuration.GetSection(SectionName);
        var vaultOptions = new VaultOptions();
        section.Bind(vaultOptions);
        string env = string.IsNullOrEmpty(Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")) ? "Development" : Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Unknown";
        RuntimeSettings runtime = RuntimeSettings.Create(env);
        runtime.UAMI = builder.Configuration.GetSection("UserAssignedManagedIdentityClientId").Value ?? "Unknown";
        builder.Services.AddSingleton<RuntimeSettings>(runtime);
        if (vaultOptions.Enabled)
        {
            builder.Configuration.AddAzureAppConfiguration(
                opts =>
#pragma warning disable SA1117 // Parameters should be on same line or separate lines
            {
                switch (runtime.CurrentEnvironment)
                {
                    case RuntimeSettings.Environment.Development:
                        var tid = builder.Configuration.GetSection("AppConfig:ServicePrincipal:TenantId").Value ?? "3ecb6e23-e454-47b7-8259-162345d74e10";
                        var cid = builder.Configuration.GetSection("AppConfig:ServicePrincipal:ClientId").Value ?? "0d07909a-542b-46ff-8c77-f619a90d6a92";
                        var sec = builder.Configuration.GetSection("AppConfig:ServicePrincipal:Secret").Value ?? "hr98Q~y6wC42jM82QyI7HX1h1b0QeU8MHgJkIcrC";
                        opts.Connect(vaultOptions.Endpoint).ConfigureKeyVault(kv =>
                        {
                            kv.SetCredential(new ClientSecretCredential(tid, cid, sec));
                            kv.SetSecretRefreshInterval("API:Settings:Secrets", TimeSpan.FromHours(24));
                        });

                        break;
                    case RuntimeSettings.Environment.Production:
                        string c = builder.Configuration.GetSection("AppConfiguration").Value ?? throw new Exception("AppConfiguration not set");

                        opts.Connect(new Uri(c), new ManagedIdentityCredential(runtime.UAMI)).ConfigureKeyVault(kv =>
                        {
                            kv.SetCredential(new ManagedIdentityCredential(runtime.UAMI));
                            kv.SetSecretRefreshInterval("API:Settings:Secrets", TimeSpan.FromHours(24));
                        });
                        break;
                    case RuntimeSettings.Environment.Test or RuntimeSettings.Environment.PPE:
                        throw new ArgumentException("Confiuration needed");
                    default:
                        throw new ArgumentException("Environment not set");
                }

                opts
                          .Select("Settings:*")
                          .Select("API:*")
                          .Select($"API:{env}")
                          .ConfigureRefresh(refresh =>
                          {
                              refresh
                                .Register("Settings", refreshAll: true)
                                .SetCacheExpiration(TimeSpan.FromDays(1));
                          });

                          // .UseFeatureFlags(featureFlagOptions =>
                          // {
                          //    featureFlagOptions.CacheExpirationInterval = TimeSpan.FromDays(1);
                          //    featureFlagOptions.Select(KeyFilter.Any, LabelFilter.Null).Select(KeyFilter.Any, env);
                          // });

                // builder.Services.AddSingleton<IConfigurationRefresher>(opts.GetRefresher());
            }, optional: true);
#pragma warning restore SA1117 // Parameters should be on same line or separate lines

            // builder.Configuration.AddAzureAppConfiguration(vaultOptions.Endpoint);

            // builder.Configuration.AddAzureAppConfiguration(options =>
            // {
            //    options.Connect(vaultOptions.Endpoint)

            // // Load all keys that start with `TestApp:` and have no label
            //           .Select("TestApp:*", LabelFilter.Null)

            // // Configure to reload configuration if the registered sentinel key is modified
            //           .ConfigureRefresh(refreshOptions =>
            //                refreshOptions.Register("TestApp:Settings:Sentinel", refreshAll: true));
            // });
        }

        return builder;
    }
}
