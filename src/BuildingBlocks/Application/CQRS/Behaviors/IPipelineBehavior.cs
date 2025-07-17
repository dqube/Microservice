using CompanyName.MyProjectName.BuildingBlocks.Application.CQRS.Core;

namespace CompanyName.MyProjectName.BuildingBlocks.Application.CQRS.Behaviors;

public interface IPipelineBehavior<TMessage, TResponse>
    where TMessage : IMessage
{
    Task<TResponse> Handle(
        TMessage message,
        MessageHandlerDelegate<TMessage, TResponse> next,
        CancellationToken ct);
}
