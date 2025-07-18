using CompanyName.MyProjectName.BuildingBlocks.Domain.Core;
using CompanyName.MyProjectName.BuildingBlocks.Domain.Repository;
using CompanyName.MyProjectName.BuildingBlocks.Domain.Specification;
using Microsoft.EntityFrameworkCore;

namespace CompanyName.MyProjectName.BuildingBlocks.Infrastructure.Repository;

// Persistence/Repositories/Repository.cs
public class Repository<TEntity, TId> : IRepository<TEntity, TId>
    where TEntity : class
    where TId : IStronglyTpeId<TId>
{
    private readonly DbContext _dbContext;
    private readonly DbSet<TEntity> _dbSet;

    public Repository(DbContext dbContext)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        _dbSet = _dbContext.Set<TEntity>();
    }

    public async Task AddAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        if (entity == null) throw new ArgumentNullException(nameof(entity));
        await _dbSet.AddAsync(entity, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        if (entity == null) throw new ArgumentNullException(nameof(entity));
        _dbSet.Remove(entity);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task<TEntity?> GetByIdAsync(TId id, CancellationToken cancellationToken = default)
    {
        if (id == null) throw new ArgumentNullException(nameof(id));
        // Assumes TEntity has a property named "Id" of type TId
        return await _dbSet.FindAsync(new object[] { id }, cancellationToken);
    }

    public async Task<IReadOnlyList<TEntity>> ListAsync(CancellationToken cancellationToken = default)
    {
        return await _dbSet.ToListAsync(cancellationToken);
    }

    public async Task<IReadOnlyList<TEntity>> ListAsync(ISpecification<TEntity> specification, CancellationToken cancellationToken = default)
    {
        if (specification == null) throw new ArgumentNullException(nameof(specification));

        IQueryable<TEntity> query = _dbSet;

        // Apply criteria
        if (specification.Criteria != null)
        {
            query = query.Where(specification.Criteria);
        }

        // Apply includes
        foreach (var include in specification.Includes)
        {
            query = query.Include(include);
        }
        foreach (var includeString in specification.IncludeStrings)
        {
            query = query.Include(includeString);
        }

        // Apply ordering
        if (specification.OrderBy != null)
        {
            query = query.OrderBy(specification.OrderBy);
        }
        else if (specification.OrderByDescending != null)
        {
            query = query.OrderByDescending(specification.OrderByDescending);
        }

        // Apply paging
        if (specification.IsPagingEnabled)
        {
            query = query.Skip(specification.Skip).Take(specification.Take);
        }

        return await query.ToListAsync(cancellationToken);
    }

    public async Task UpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        if (entity == null) throw new ArgumentNullException(nameof(entity));
        _dbSet.Update(entity);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}

