using FluentValidation;

namespace api.Infrastructure.RequestDTOs.Users;

public class UserValidator : AbstractValidator<UserRequest>
{
    public UserValidator()
    {
        RuleFor(user => user.Username)
            .NotEmpty().WithMessage("Username is required.")
            .MinimumLength(5).WithMessage("Username must be at least 5 characters long.")
            .MaximumLength(20).WithMessage("Username must be at most 20 characters long.");
        RuleFor(user => user.Password)
            .NotEmpty().WithMessage("Password is required.")
            .MinimumLength(5).WithMessage("Password must be at least 5 characters long.")
            .MaximumLength(20).WithMessage("Password must be at most 20 characters long.");
        RuleFor(user => user.Firstname)
            .NotEmpty().WithMessage("Firstname is required.")
            .MaximumLength(25).WithMessage("Firstname must be at most 25 characters long.");
        RuleFor(user => user.Lastname)
            .NotEmpty().WithMessage("Lastname is required.")
            .MaximumLength(25).WithMessage("Lastname must be at most 25 characters long.");
        RuleFor(user => user.Age)
            .NotEmpty().WithMessage("Age is required.");
    }
}