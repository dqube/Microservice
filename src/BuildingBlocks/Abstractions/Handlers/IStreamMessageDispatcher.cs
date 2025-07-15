using CompanyName.MyProjectName.BuildingBlocks.Abstractions.Abstractions;

namespace CompanyName.MyProjectName.BuildingBlocks.Abstractions.Handlers;

public interface IStreamMessageDispatcher
{
    IAsyncEnumerable<object> DispatchAsync<TMessage>(TMessage message, CancellationToken ct)
        where TMessage : class, IStreamMessage;

    IAsyncEnumerable<object> DispatchAsync<TMessage>(IAsyncEnumerable<TMessage> messages, CancellationToken ct)
        where TMessage : class, IStreamMessage;
}