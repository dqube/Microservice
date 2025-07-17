namespace CompanyName.MyProjectName.BuildingBlocks.Application.CQRS.Core;

public interface IEventHandler<in TEvent> : IMessageHandler<TEvent>
    where TEvent :  IEvent
{
}
