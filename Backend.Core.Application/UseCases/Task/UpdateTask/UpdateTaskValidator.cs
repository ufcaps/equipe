using Backend.Core.Domain.Enums;
using FluentValidation;

namespace Backend.Core.Application.UseCases.Task.UpdateTask;

public sealed class UpdateTaskValidator : AbstractValidator<UpdateTaskRequest>
{
    public UpdateTaskValidator()
    {
        RuleFor(x => x.Title)
            .MinimumLength(3)
            .MaximumLength(100)
            .When(x => !string.IsNullOrEmpty(x.Title));

        RuleFor(x => x.Description)
            .MaximumLength(500)
            .When(x => !string.IsNullOrEmpty(x.Description));

        RuleFor(x => x.Priority)
            .Must(BeValidPriority)
            .When(x => !string.IsNullOrEmpty(x.Priority));

        RuleFor(x => x.Status)
            .Must(BeValidStatus)
            .When(x => !string.IsNullOrEmpty(x.Status));
    }

    private bool BeValidPriority(string? priority)
        => Enum.TryParse<Priority>(priority, true, out _);

    private bool BeValidStatus(string? status)
        => Enum.TryParse<Status>(status, true, out _);
}
