using FluentValidation;

namespace Application.Features.Users.Commands.Create;

public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
{
    public CreateUserCommandValidator()
    {
        RuleFor(x => x.User.email)
            .NotEmpty().WithMessage("Email can't be empty.")
            .EmailAddress().WithMessage("Email not in valid format.");

        RuleFor(x => x.User.city)
            .NotEmpty().WithMessage("City can't be empty.");
    }
}
