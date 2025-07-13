using CompanyName.MyProjectName.BuildingBlocks.API.Exceptions.Middlewares;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CompanyName.MyProjectName.BuildingBlocks.API.OpenAPI;

public static class Extensions
{
    public static IServiceCollection AddOpenApi(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddOpenApi(); // Document name is v1

        return services;
    }

    public static IApplicationBuilder UseOpenApi(this IApplicationBuilder app)
       => app.UseOpenApi();
}