using CompanyName.MyProjectName.BuildingBlocks.Application.CQRS.Core;
using Microsoft.Extensions.DependencyInjection;

namespace CompanyName.MyProjectName.BuildingBlocks.Application.CQRS.Dispatchers;
#nullable enable
internal sealed class QueryDispatcher : IQueryDispatcher
{
    private readonly IServiceProvider _serviceProvider;

    public QueryDispatcher(IServiceProvider serviceProvider)
        => _serviceProvider = serviceProvider;

    public async Task<TResult> QueryAsync<TResult>(IQuery<TResult> query, CancellationToken cancellationToken = default)
    {
        if (query is null)
            throw new ArgumentNullException(nameof(query), "Query cannot be null.");

        await using var scope = _serviceProvider.CreateAsyncScope();
        var handlerType = typeof(IQueryHandler<,>).MakeGenericType(query.GetType(), typeof(TResult));
        var handler = scope.ServiceProvider.GetService(handlerType);
        if (handler is null)
            throw new InvalidOperationException($"No query handler registered for '{query.GetType().Name}' and result '{typeof(TResult).Name}'.");

        var method = handlerType.GetMethod(nameof(IQueryHandler<IQuery<TResult>, TResult>.HandleAsync));
        if (method is null)
            throw new InvalidOperationException($"Query handler for '{typeof(TResult).Name}' does not implement HandleAsync.");

        var task = (Task<TResult>?)method.Invoke(handler, new object[] { query, cancellationToken });
        if (task is null)
            throw new InvalidOperationException("Failed to invoke query handler.");

        return await task.ConfigureAwait(false);
    }
}
#nullable disable