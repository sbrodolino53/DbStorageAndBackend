// Features/Users/RegisterDtoValidator.cs
using FluentValidation;
using MinimalApiTemplate.Features.Users;

public class RegisterDtoValidator : AbstractValidator<RegisterDto>
{
    public RegisterDtoValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email required")
            .EmailAddress().WithMessage("Invalid e-mail format");

        RuleFor(x => x.Password)
            .MinimumLength(8).WithMessage("Password must be ≥ 8 chars")
            .Matches("[A-Z]").WithMessage("Password must contain uppercase")
            .Matches("[a-z]").WithMessage("Password must contain lowercase")
            .Matches("[0-9]").WithMessage("Password must contain digit");
    }
}