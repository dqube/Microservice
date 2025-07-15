using CompanyName.MyProjectName.BuildingBlocks.Application.Mediator.Core;
namespace CompanyName.MyProjectName.BuildingBlocks.Application.Mediator.Behaviors;
using FluentValidation;
public class ValidationPipelineBehavior<TMessage, TResponse> : IPipelineBehavior<TMessage, TResponse>
    where TResponse : notnull
    where TMessage : IMessage
{
    private readonly IEnumerable<IValidator<TMessage>> _validators;

    public ValidationPipelineBehavior(IEnumerable<IValidator<TMessage>> validators)
    {
        _validators = validators;
    }

    public async Task<TResponse> Handle(
        TMessage message,
        MessageHandlerDelegate<TMessage, TResponse> next,
        CancellationToken cancellationToken)
    {
        if (!_validators.Any()) return await next(message, cancellationToken);

        var validationResults = await Task.WhenAll(
            _validators.Select(v => v.ValidateAsync(message, cancellationToken)));

        var failures = validationResults
            .SelectMany(r => r.Errors)
            .Where(f => f != null)
            .ToList();

        if (failures.Count != 0)
        {
            var errorMessages = string.Join("; ", failures.Select(f => $"{f.PropertyName}: {f.ErrorMessage}"));
            throw new ValidationException($"Validation failed: {errorMessages}", failures);
        }

        return await next(message, cancellationToken);
    }
}

