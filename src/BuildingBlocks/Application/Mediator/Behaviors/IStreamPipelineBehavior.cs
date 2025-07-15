using CompanyName.MyProjectName.BuildingBlocks.Application.Mediator.Core;

namespace CompanyName.MyProjectName.BuildingBlocks.Application.Mediator.Behaviors;

// Update the IStreamPipelineBehavior interface to use invariant TMessage
public interface IStreamPipelineBehavior<TMessage>
    where TMessage : IStreamMessage
{
    IAsyncEnumerable<object> Handle(
        TMessage message,
        StreamHandlerDelegate<TMessage> next,
        CancellationToken ct);
}
