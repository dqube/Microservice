namespace CompanyName.MyProjectName.BuildingBlocks.Application.Mediator.Core;

public interface IStreamMessageHandler<in TMessage>
    where TMessage : class, IStreamMessage
{
    IAsyncEnumerable<object> Handle(TMessage message, CancellationToken ct);
}
