using CompanyName.MyProjectName.BuildingBlocks.Abstractions.Abstractions;

namespace CompanyName.MyProjectName.BuildingBlocks.Abstractions.Handlers;

public interface IStreamMessageHandler<in TMessage>
    where TMessage : class, IStreamMessage
{
    IAsyncEnumerable<object> Handle(TMessage message, CancellationToken ct);
}
