using CompanyName.MyProjectName.BuildingBlocks.Domain.Exceptions;

namespace CompanyName.MyProjectName.BuildingBlocks.Domain.Core;

public abstract class ValidatableEntity<TId, TValue> : Entity<TId, TValue>
    where TId : IStronglyTpeId<TValue>
    where TValue : notnull
{
    protected ValidatableEntity(TId id) : base(id) { }

    protected void Validate(ValidationResult validationResult)
    {
        if (!validationResult.IsValid)
            throw new DomainValidationException(validationResult.Errors);
    }
}
