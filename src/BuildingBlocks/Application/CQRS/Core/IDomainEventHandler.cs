
namespace CompanyName.MyProjectName.BuildingBlocks.Application.CQRS.Core;

public interface IDomainEventHandler<in TEvent>
    where TEvent : class, IDomainEvent
{
    Task HandleAsync(TEvent @event, CancellationToken cancellationToken = default);
}