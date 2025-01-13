using FluentValidation;

namespace Backend.Core.Application.UseCases.User.UpdateUser;

public sealed class UpdateUserValidator : AbstractValidator<UpdateUserRequest>
{
    public UpdateUserValidator()
    {
        RuleFor(x => x.Name)
            .MinimumLength(3)
            .MaximumLength(100)
            .When(x => !string.IsNullOrEmpty(x.Name));

        RuleFor(x => x.Email)
            .EmailAddress()
            .MaximumLength(256)
            .When(x => !string.IsNullOrEmpty(x.Email));

        RuleFor(x => x.Password)
            .MinimumLength(8)
            .MaximumLength(60)
            .When(x => !string.IsNullOrEmpty(x.Password));
    }
}
