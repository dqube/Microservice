using CompanyName.MyProjectName.BuildingBlocks.Application.CQRS.Core;

namespace CompanyName.MyProjectName.BuildingBlocks.Application.CQRS.Dispatchers;

public interface ICommandDispatcher
{
    Task SendAsync<TCommand>(TCommand command, CancellationToken cancellationToken = default)
        where TCommand : class, ICommand;

    Task<TResult> SendAsync<TResult>(ICommand<TResult> command, CancellationToken cancellationToken = default);
}
