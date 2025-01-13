using Backend.Core.Domain.Enums;
using FluentValidation;

namespace Backend.Core.Application.UseCases.Task.CreateTask;

public sealed class CreateTaskValidator : AbstractValidator<CreateTaskRequest>
{
    public CreateTaskValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty()
            .MinimumLength(3)
            .MaximumLength(100);

        RuleFor(x => x.Description)
            .MaximumLength(500)
            .When(x => !string.IsNullOrEmpty(x.Description));

        RuleFor(x => x.Priority)
            .NotEmpty()
            .Must(BeValidPriority);

        RuleFor(x => x.Status)
            .NotEmpty()
            .Must(BeValidStatus);

        RuleFor(x => x.Date)
            .NotEmpty();
    }

    private bool BeValidPriority(string priority)
        => Enum.TryParse<Priority>(priority, true, out _);

    private bool BeValidStatus(string status)
        => Enum.TryParse<Status>(status, true, out _);
}
