using CompanyName.MyProjectName.BuildingBlocks.Infrastructure.Data.Internals;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CompanyName.MyProjectName.BuildingBlocks.Infrastructure.Data;

public static class Extensions
{
    public static IServiceCollection AddPostgres<T>(this IServiceCollection services, IConfiguration configuration)
        where T : DbContext
    {
        var section = configuration.GetSection("postgres");
        var options = section.Get<PostgresOptions>() ?? new PostgresOptions();
        services.Configure<PostgresOptions>(section);
        if (!section.Exists())
        {
            return services;
        }

        services.AddDbContext<T>(x => x.UseNpgsql(options.ConnectionString));
        services.AddHostedService<DatabaseInitializer<T>>();
        services.AddHostedService<DataInitializer>();
        services.AddScoped<IUnitOfWork, PostgresUnitOfWork<T>>();
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        return services;
    }
    public static IServiceCollection AddInitializer<T>(this IServiceCollection services) where T : class, IDataInitializer
        => services.AddTransient<IDataInitializer, T>();
}