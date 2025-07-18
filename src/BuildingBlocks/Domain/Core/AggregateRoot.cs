using CompanyName.MyProjectName.BuildingBlocks.Domain.Events;

namespace CompanyName.MyProjectName.BuildingBlocks.Domain.Core;
public abstract class AggregateRoot<TId, TKey> : Entity<TId, TKey>
    where TId : IStronglyTpeId<TKey>
    where TKey : notnull
{
    private readonly List<IDomainEvent> _domainEvents = new();

    public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();

    protected AggregateRoot(TId id) : base(id) { }

    protected void AddDomainEvent(IDomainEvent eventItem) => _domainEvents.Add(eventItem);

    public void ClearDomainEvents() => _domainEvents.Clear();
}