using FluentValidation.Results;

namespace Backend.Core.Application.Exceptions;

public class ValidationFailureException(List<ValidationFailure> failures)
    : FluentValidation.ValidationException("Validation failure")
{
    public List<ValidationFailure> Failures = failures;
}
