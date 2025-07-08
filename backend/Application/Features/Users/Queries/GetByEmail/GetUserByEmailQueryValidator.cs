using FluentValidation;

namespace Application.Features.Users.Queries.GetByEmail;

public class GetUserByEmailQueryValidator : AbstractValidator<GetUserByEmailQuery>
{
    public GetUserByEmailQueryValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email can't be empty.")
            .EmailAddress().WithMessage("Incorrect email format.");
    }
}
