namespace CompanyName.MyProjectName.BuildingBlocks.Domain.Events;

// YourCompany.DDD.Abstractions/IDomainEvent.cs
public interface IDomainEvent
{
    DateTime OccurredOn { get; }
}
