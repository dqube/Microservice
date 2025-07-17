using CompanyName.MyProjectName.BuildingBlocks.Application.CQRS.Core;
using Microsoft.Extensions.DependencyInjection;

namespace CompanyName.MyProjectName.BuildingBlocks.Application.CQRS.Dispatchers;

internal sealed class DomainEventDispatcher : IDomainEventDispatcher
{
    private readonly IServiceProvider _serviceProvider;

    public DomainEventDispatcher(IServiceProvider serviceProvider)
        => _serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));

    public Task DispatchAsync(IDomainEvent @event, CancellationToken cancellationToken = default)
    {
        if (@event is null) throw new ArgumentNullException(nameof(@event));
        return DispatchAsyncCore(cancellationToken, @event);
    }

    public Task DispatchAsync(IDomainEvent[] events, CancellationToken cancellationToken = default)
    {
        if (events is null) throw new ArgumentNullException(nameof(events));
        return DispatchAsyncCore(cancellationToken, events);
    }

    private async Task DispatchAsyncCore(CancellationToken cancellationToken, params IDomainEvent[] events)
    {
        if (events.Length == 0)
            return;

        using var scope = _serviceProvider.CreateScope();
        foreach (var @event in events)
        {
            var handlerType = typeof(IDomainEventHandler<>).MakeGenericType(@event.GetType());
            var handlers = scope.ServiceProvider.GetServices(handlerType);

            var handleMethod = handlerType.GetMethod("HandleAsync");
            if (handleMethod is null)
                continue;

            var tasks = handlers
                .Select(handler => (Task)handleMethod.Invoke(handler, new object[] { @event, cancellationToken })!)
                .Where(task => task is not null);

            await Task.WhenAll(tasks);
        }
    }
}