using CompanyName.MyProjectName.BuildingBlocks.Application.CQRS.Core;

namespace CompanyName.MyProjectName.BuildingBlocks.Application.CQRS.Behaviors;

// Update the IStreamPipelineBehavior interface to use invariant TMessage
public interface IStreamPipelineBehavior<TMessage>
    where TMessage : IStreamMessage
{
    IAsyncEnumerable<object> Handle(
        TMessage message,
        StreamHandlerDelegate<TMessage> next,
        CancellationToken ct);
}
