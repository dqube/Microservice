namespace CompanyName.MyProjectName.BuildingBlocks.Application.Mediator.Core;

public interface IEventHandler<in TEvent> : IMessageHandler<TEvent>
    where TEvent :  IEvent
{
}
