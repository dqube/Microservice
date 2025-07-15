using CompanyName.MyProjectName.BuildingBlocks.Abstractions.Handlers;
using CompanyName.MyProjectName.BuildingBlocks.Observability.Logging.Decorators;
using CompanyName.MyProjectName.BuildingBlocks.Observability.Logging.Middlewares;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using OpenTelemetry.Logs;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;

namespace CompanyName.MyProjectName.BuildingBlocks.Observability.Logging;

#nullable enable
public static class Extensions
{
    private const string AppSectionName = "app";

    public static IServiceCollection AddLogger(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<ContextLoggingMiddleware>();
        services.AddTransient(typeof(ICommandHandler<>), typeof(LoggingCommandHandlerDecorator<>));
        services.AddTransient(typeof(ICommandHandler<,>), typeof(LoggingCommandHandlerDecorator<,>));
        services.AddTransient(typeof(IEventHandler<>), typeof(LoggingEventHandlerDecorator<>));
        return services;
    }

    public static IApplicationBuilder UseContextLogger(this IApplicationBuilder app)
        => app.UseMiddleware<ContextLoggingMiddleware>();

    public static WebApplicationBuilder AddLogging(
        this WebApplicationBuilder builder,
        string appSectionName = AppSectionName)
    {
        builder.Logging.ClearProviders();
        builder.Logging.AddOpenTelemetry(options =>
        {
            options.IncludeScopes = true;
            options.ParseStateValues = true;
            options.IncludeFormattedMessage = true;
            options.SetResourceBuilder(ResourceBuilder.CreateDefault().AddService(builder.Environment.ApplicationName));
        });

        builder.Services.AddOpenTelemetry().WithTracing(tracing =>
        {
            tracing.SetResourceBuilder(ResourceBuilder.CreateDefault().AddService(builder.Environment.ApplicationName));
            tracing.AddAspNetCoreInstrumentation();
            tracing.AddHttpClientInstrumentation();

            // Add exporters as needed, e.g. tracing.AddOtlpExporter();
        });
        return builder;
    }

    public static IApplicationBuilder UseRequestLogging(this IApplicationBuilder app)
    {
        // Optionally add request logging middleware or OpenTelemetry instrumentation here
        return app;
    }
}