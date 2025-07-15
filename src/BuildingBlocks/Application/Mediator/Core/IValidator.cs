using System.ComponentModel.DataAnnotations;

namespace CompanyName.MyProjectName.BuildingBlocks.Application.Mediator.Core;

// Dummy IValidator interface for demonstration
public interface IValidator<T>
{
    Task<ValidationResult> ValidateAsync(T instance, CancellationToken cancellationToken);
}
