using CompanyName.MyProjectName.BuildingBlocks.Abstractions;
using CompanyName.MyProjectName.BuildingBlocks.Jobs;
using CompanyName.MyProjectName.Patients.Application;
using CompanyName.MyProjectName.Patients.Domain;
using CompanyName.MyProjectName.Patients.Infrastructure;
using CompanyName.MyProjectName.Patients.Infrastructure.Jobs;
using Hangfire;

namespace CompanyName.MyProjectName.Patients.API;

internal static class Extensions
{
    public static IServiceCollection AddPatients(this IServiceCollection services, IConfiguration configuration)
    {
        return services
            .AddApplication()
            .AddDomain()
            .AddInfrastructure(configuration);
    }

    public static IApplicationBuilder UseRecurringJobs(this WebApplication app)
    {
        var recurringJobManager = app.Services.GetRequiredService<IRecurringJobManager>();
        var configuration = app.Configuration;
        var section = configuration.GetSection("quartz");
        var options = section.BindOptions<JobOptions>();
        recurringJobManager.AddOrUpdate<ITimerService>("print-time", service => service.PrintNow(), options.Jobs["scheduler"].Cron);
        return app;
    }
}