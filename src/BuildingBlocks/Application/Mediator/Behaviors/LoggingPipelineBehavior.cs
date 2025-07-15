using CompanyName.MyProjectName.BuildingBlocks.Application.Mediator.Core;
using Microsoft.Extensions.Logging;

namespace CompanyName.MyProjectName.BuildingBlocks.Application.Mediator.Behaviors;

public class LoggingPipelineBehavior<TMessage, TResponse> : IPipelineBehavior<TMessage, TResponse>
    where TMessage : IMessage
{
    private readonly ILogger<LoggingPipelineBehavior<TMessage, TResponse>> _logger;

    public LoggingPipelineBehavior(ILogger<LoggingPipelineBehavior<TMessage, TResponse>> logger)
    {
        _logger = logger;
    }

    public async Task<TResponse> Handle(
        TMessage message,
        MessageHandlerDelegate<TMessage, TResponse> next,
        CancellationToken cancellationToken)
    {
        _logger.LogInformation("Handling {MessageType} with payload {@Message}",
            typeof(TMessage).Name, message);

        try
        {
            var response = await next(message, cancellationToken);

            _logger.LogInformation("Successfully handled {MessageType}", typeof(TMessage).Name);
            return response;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error handling {MessageType}", typeof(TMessage).Name);
            throw;
        }
    }
}
