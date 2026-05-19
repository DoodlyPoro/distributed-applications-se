using FluentValidation;

namespace api.Infrastructure.RequestDTOs.Auth;

public class AuthTokenValidator : AbstractValidator<AuthTokenRequest>
{
    public AuthTokenValidator()
    {
        RuleFor(x => x.Username)
            .NotEmpty().WithMessage("Username is required.")
            .MinimumLength(5).WithMessage("Username must be at least 5 characters long.").
            MaximumLength(20).WithMessage("Username must be at most 20 characters long.");
        
        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Password is required.")
            .MinimumLength(5).WithMessage("Password must be at least 5 characters long.").
            MaximumLength(20).WithMessage("Password must be at most 20 characters long.");
    }
}