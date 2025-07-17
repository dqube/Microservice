namespace CompanyName.MyProjectName.BuildingBlocks.Application.CQRS.Core;

public interface IMessageHandler<in TMessage>
    where TMessage : IMessage
{
    Task HandleAsync(TMessage message, CancellationToken ct = default);
}
