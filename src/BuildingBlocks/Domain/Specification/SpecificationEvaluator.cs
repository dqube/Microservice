namespace CompanyName.MyProjectName.BuildingBlocks.Domain.Specification;

public static class SpecificationEvaluator
{
    public static IQueryable<T> GetQuery<T>(
        IQueryable<T> inputQuery,
        ISpecification<T> specification)
    {
        var query = inputQuery;

        // Apply WHERE clause
        if (specification.Criteria != null)
        {
            query = query.Where(specification.Criteria);
        }

        // Note: We DON'T apply Includes here - that happens in Infrastructure
        // The Includes collection is just stored for later use

        // Apply ORDER BY
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
            query = query.Skip(specification.Skip)
                         .Take(specification.Take);
        }

        return query;
    }

    public static IQueryable<T> ApplyCriteria<T>(
        IQueryable<T> query,
        ISpecification<T> specification)
    {
        if (specification.Criteria != null)
        {
            query = query.Where(specification.Criteria);
        }
        return query;
    }

    public static IQueryable<T> ApplyOrderBy<T>(
        IQueryable<T> query,
        ISpecification<T> specification)
    {
        if (specification.OrderBy != null)
        {
            query = query.OrderBy(specification.OrderBy);
        }
        else if (specification.OrderByDescending != null)
        {
            query = query.OrderByDescending(specification.OrderByDescending);
        }
        return query;
    }

    public static IQueryable<T> ApplyPaging<T>(
        IQueryable<T> query,
        ISpecification<T> specification)
    {
        if (specification.IsPagingEnabled)
        {
            query = query.Skip(specification.Skip)
                         .Take(specification.Take);
        }
        return query;
    }
}