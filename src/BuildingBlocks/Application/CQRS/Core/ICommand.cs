namespace CompanyName.MyProjectName.BuildingBlocks.Application.CQRS.Core;

public interface ICommand<out TResponse> : IMessage
{
}

public interface ICommand : ICommand<Unit>
{
}

// Delegate for the next handler in the pipeline
public delegate Task<TResponse> MessageHandlerDelegate<in TMessage, TResponse>(
    TMessage message,
    CancellationToken cancellationToken)
    where TMessage : IMessage;


// Define the StreamHandlerDelegate delegate
public delegate IAsyncEnumerable<object> StreamHandlerDelegate<in TMessage>(
    TMessage message,
    CancellationToken cancellationToken)
    where TMessage : IStreamMessage;
