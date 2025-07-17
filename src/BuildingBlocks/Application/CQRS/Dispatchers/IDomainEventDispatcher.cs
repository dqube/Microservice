
using CompanyName.MyProjectName.BuildingBlocks.Application.CQRS.Core;

namespace CompanyName.MyProjectName.BuildingBlocks.Application.CQRS.Dispatchers;

public interface IDomainEventDispatcher
{
    Task DispatchAsync(IDomainEvent @event, CancellationToken cancellationToken = default);

    Task DispatchAsync(IDomainEvent[] events, CancellationToken cancellationToken = default);
}