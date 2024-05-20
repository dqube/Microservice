using CompanyName.MyProjectName.BuildingBlocks.Abstractions;
using Hangfire;
using Hangfire.SqlServer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CompanyName.MyProjectName.BuildingBlocks.Jobs;

public static class Extensions
{
   public static IServiceCollection AddHangfire(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        var section = configuration.GetSection("quartz");
        var options = section.BindOptions<JobOptions>();
        services.Configure<JobOptions>(section);
        services.AddHangfire(configuration => configuration
        .SetDataCompatibilityLevel(CompatibilityLevel.Version_180)
        .UseSimpleAssemblyNameTypeSerializer()
        .UseRecommendedSerializerSettings()
        .UseSqlServerStorage(options.ConnectionString, new SqlServerStorageOptions
        {
            CommandBatchMaxTimeout = TimeSpan.FromMinutes(5),
            SlidingInvisibilityTimeout = TimeSpan.FromMinutes(5),
            QueuePollInterval = TimeSpan.Zero,
            UseRecommendedIsolationLevel = true,
            DisableGlobalLocks = true
        }));

        services.AddHangfireServer();
        GlobalJobFilters.Filters.Add(new LogJobsAttribute());
        return services;
    }
}