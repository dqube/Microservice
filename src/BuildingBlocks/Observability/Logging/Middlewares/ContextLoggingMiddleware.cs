using CompanyName.MyProjectName.BuildingBlocks.Contexts;
using Microsoft.AspNetCore.Http;

namespace CompanyName.MyProjectName.BuildingBlocks.Observability.Logging.Middlewares;

internal sealed class ContextLoggingMiddleware : IMiddleware
{
    private readonly IContextProvider _contextProvider;

    public ContextLoggingMiddleware(IContextProvider contextProvider)
    {
        _contextProvider = contextProvider;
    }

    public async Task InvokeAsync(HttpContext httpContext, RequestDelegate next)
    {
        // Optionally, enrich OpenTelemetry logs with context here
        await next(httpContext);
    }
}