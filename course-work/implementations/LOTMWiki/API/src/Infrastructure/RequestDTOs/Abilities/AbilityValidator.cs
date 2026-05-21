using Common.Entity;
using FluentValidation;

namespace api.Infrastructure.RequestDTOs.Abilities;

public class AbilityValidator : AbstractValidator<AbilityRequest>
{
    public AbilityValidator()
    {
        RuleFor(ability => ability.Name)
            .NotEmpty().WithMessage("Name is required")
            .MinimumLength(5).WithMessage("Name must be at least 5 characters long")
            .MaximumLength(25).WithMessage("Name must be less than 25 characters long");
        
        RuleFor(ability => ability.Description)
            .NotEmpty().WithMessage("Description is required")
            .MinimumLength(25).WithMessage("Description must be at least 25 characters long")
            .MaximumLength(250).WithMessage("Description must be less than 250 characters long");
    }
}