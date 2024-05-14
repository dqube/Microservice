﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace CompanyName.MyProjectName.BuildingBlocks.Observability;

#nullable enable
public static class Extensions
{
    public static IServiceCollection AddHealthCheck(this IServiceCollection services, IConfiguration configuration)
    {
                services.AddHealthChecks();

        // services
        //   .AddHealthChecks()
        //   .AddNpgSql(configuration.GetConnectionString("Database")!)
        //   .AddRedis(configuration.GetConnectionString("Cache")!);
                return services;
    }

    public static IApplicationBuilder UseHealthCheck(this WebApplication app)
    {
        app.MapHealthChecks("/health", new HealthCheckOptions
        {
            AllowCachingResponses = false,
            ResultStatusCodes =
                {
                    [HealthStatus.Healthy] = StatusCodes.Status200OK,
                    [HealthStatus.Degraded] = StatusCodes.Status200OK,
                    [HealthStatus.Unhealthy] = StatusCodes.Status503ServiceUnavailable
                }
        });
        return app;
    }
}
