using Backend.Core.Application.Exceptions;
using FluentValidation;
using MediatR;

namespace Backend.Core.Application.Shared.Behavior;

public sealed class ValidationBehavior<TRequest, TResponse>
(
    IEnumerable<IValidator<TRequest>> validators
) : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
{
    private readonly IEnumerable<IValidator<TRequest>> _validators = validators;

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if (!_validators.Any())
            return await next();

        var validationContext = new ValidationContext<TRequest>(request);
        var validationsResult = await Task.WhenAll(
            _validators.Select(x => x.ValidateAsync(validationContext, cancellationToken))
        );

        var failures = validationsResult
            .SelectMany(x => x.Errors)
            .Where(x => x is not null)
            .ToList();

        if (failures.Count > 0)
            throw new ValidationFailureException(failures);

        return await next();
    }
}
