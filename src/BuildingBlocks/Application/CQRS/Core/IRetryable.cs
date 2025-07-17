namespace CompanyName.MyProjectName.BuildingBlocks.Application.CQRS.Core;

public interface IRetryable
{
    int RetryCount { get; }
    bool IsRetryableException(Exception exception);
}
