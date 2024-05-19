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
}

internal static class Jobs
{
    public static void Register()
    {
        RecurringJob.AddOrUpdate<ITimerService>("print-time", service => service.PrintNow(), Cron.Minutely);
    }
}