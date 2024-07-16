using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.AzureAppConfiguration;

namespace CompanyName.MyProjectName.BuildingBlocks.Security.Vault;

public static class Extensions
{
    private const string SectionName = "vault";

    public static WebApplicationBuilder AddVault(this WebApplicationBuilder builder)
    {
        var section = builder.Configuration.GetSection(SectionName);
        var vaultOptions = new VaultOptions();
        section.Bind(vaultOptions);
        if (vaultOptions.Enabled)
        {
            builder.Configuration.AddAzureAppConfiguration(vaultOptions.Endpoint);

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
