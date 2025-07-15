using CompanyName.MyProjectName.BuildingBlocks.Domain.Core;

namespace CompanyName.MyProjectName.BuildingBlocks.Domain.Events;

public interface IDomainService<TEntity, TId, TValue>
    where TEntity : Entity<TId, TValue>
    where TId : IIdentity<TValue>
    where TValue : notnull
{
    Task<TEntity> GetByIdAsync(TId id);
    Task SaveAsync(TEntity entity);
    Task DeleteAsync(TId id);
}