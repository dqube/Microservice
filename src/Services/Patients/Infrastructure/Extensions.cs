using CompanyName.MyProjectName.BuildingBlocks.SQLServer;
using CompanyName.MyProjectName.Patients.Domain.Patients.Repositories;
using CompanyName.MyProjectName.Patients.Infrastructure.DAL;
using CompanyName.MyProjectName.Patients.Infrastructure.DAL.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CompanyName.MyProjectName.Patients.Infrastructure;

internal static class Extensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services
            .AddScoped<IPatientRepository, PatientRepository>()
            .AddMSSqlServer<PatientsDbContext>("patient");

        return services;

        // .AddUnitOfWork<PatientsUnitOfWork>();
    }
}