namespace CompanyName.MyProjectName.BuildingBlocks.Application.Mediator.Core;

public interface IRetryable
{
    int RetryCount { get; }
    bool IsRetryableException(Exception exception);
}
