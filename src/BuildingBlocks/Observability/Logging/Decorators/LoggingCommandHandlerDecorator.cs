using System.Collections.Concurrent;
using CompanyName.MyProjectName.BuildingBlocks.Abstractions.Abstractions;
using CompanyName.MyProjectName.BuildingBlocks.Abstractions.Attributes;
using CompanyName.MyProjectName.BuildingBlocks.Abstractions.Handlers;
using CompanyName.MyProjectName.BuildingBlocks.Contexts;
using Humanizer;
using Microsoft.Extensions.Logging;

namespace CompanyName.MyProjectName.BuildingBlocks.Observability.Logging.Decorators;

[Decorator]
internal sealed class LoggingCommandHandlerDecorator<T> : ICommandHandler<T>
    where T : class, ICommand
{
    private static readonly ConcurrentDictionary<Type, string> Names = new();
    private readonly ICommandHandler<T> _handler;
    private readonly IContextProvider _contextProvider;
    private readonly ILogger<LoggingCommandHandlerDecorator<T>> _logger;

    public LoggingCommandHandlerDecorator(
        ICommandHandler<T> handler,
        IContextProvider contextProvider,
        ILogger<LoggingCommandHandlerDecorator<T>> logger)
    {
        _handler = handler;
        _contextProvider = contextProvider;
        _logger = logger;
    }

    public async Task HandleAsync(T command, CancellationToken cancellationToken = default)
    {
        var context = _contextProvider.Current();
        var name = Names.GetOrAdd(typeof(T), command.GetType().Name.Underscore());
        _logger.LogInformation(
            "Handling a command: {CommandName} [Trace ID: {TraceId}, Correlation ID: {CorrelationId}, Message ID: {MessageId}, Causation ID: {CausationId}, User ID: {UserId}']...",
            name,
            context.TraceId,
            context.CorrelationId,
            context.MessageId,
            context.CausationId,
            context.UserId ?? string.Empty);
        await _handler.HandleAsync(command, cancellationToken);
        _logger.LogInformation(
            "Handled a command: {CommandName} [Trace ID: {TraceId}, Correlation ID: {CorrelationId}, Message ID: {MessageId}, Causation ID: {CausationId}, User ID: {UserId}]",
            name,
            context.TraceId,
            context.CorrelationId,
            context.MessageId,
            context.CausationId,
            context.UserId ?? string.Empty);
    }
}

[Decorator]
internal sealed class LoggingCommandHandlerDecorator<TCommand, TResponse> : ICommandHandler<TCommand, TResponse>
    where TCommand : class, ICommand<TResponse>
{
    private static readonly ConcurrentDictionary<Type, string> Names = new();
    private readonly ICommandHandler<TCommand, TResponse> _handler;
    private readonly IContextProvider _contextProvider;
    private readonly ILogger<LoggingCommandHandlerDecorator<TCommand, TResponse>> _logger;

    public LoggingCommandHandlerDecorator(
        ICommandHandler<TCommand, TResponse> handler,
        IContextProvider contextProvider,
        ILogger<LoggingCommandHandlerDecorator<TCommand, TResponse>> logger)
    {
        _handler = handler;
        _contextProvider = contextProvider;
        _logger = logger;
    }

    public async Task<TResponse> HandleAsync(TCommand command, CancellationToken cancellationToken = default)
    {
        var context = _contextProvider.Current();
        var name = Names.GetOrAdd(typeof(TCommand), command.GetType().Name.Underscore());
        _logger.LogInformation(
            "Handling a command: {CommandName} [Trace ID: {TraceId}, Correlation ID: {CorrelationId}, Message ID: {MessageId}, Causation ID: {CausationId}, User ID: {UserId}']...",
            name,
            context.TraceId,
            context.CorrelationId,
            context.MessageId,
            context.CausationId,
            context.UserId ?? string.Empty);
        var result = await _handler.HandleAsync(command, cancellationToken);
        _logger.LogInformation(
            "Handled a command: {CommandName} [Trace ID: {TraceId}, Correlation ID: {CorrelationId}, Message ID: {MessageId}, Causation ID: {CausationId}, User ID: {UserId}]",
            name,
            context.TraceId,
            context.CorrelationId,
            context.MessageId,
            context.CausationId,
            context.UserId ?? string.Empty);
        return result;
    }
}