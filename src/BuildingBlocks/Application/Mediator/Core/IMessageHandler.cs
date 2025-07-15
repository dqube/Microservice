namespace CompanyName.MyProjectName.BuildingBlocks.Application.Mediator.Core;

public interface IMessageHandler<in TMessage>
    where TMessage : IMessage
{
    Task Handle(TMessage message, CancellationToken ct = default);
}
