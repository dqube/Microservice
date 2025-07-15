namespace CompanyName.MyProjectName.BuildingBlocks.Infrastructure.Data;

public interface IUnitOfWork
{
    Task ExecuteAsync(Func<Task> action, CancellationToken cancellationToken = default);
}