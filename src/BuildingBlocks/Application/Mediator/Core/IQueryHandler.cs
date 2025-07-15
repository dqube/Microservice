namespace CompanyName.MyProjectName.BuildingBlocks.Application.Mediator.Core;

public interface IQueryHandler<in TQuery, TResponse>
    where TQuery : class, IQuery<TResponse>
{
    Task<TResponse> HandleAsync(TQuery query, CancellationToken cancellationToken = default);
}