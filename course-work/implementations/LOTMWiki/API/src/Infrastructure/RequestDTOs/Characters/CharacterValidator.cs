using FluentValidation;

namespace api.Infrastructure.RequestDTOs.Characters;

public class CharacterValidator : AbstractValidator<CharacterRequest>
{
    public CharacterValidator()
    {
        RuleFor(character => character.Name)
            .NotEmpty().WithMessage("Character name is required")
            .MinimumLength(4).WithMessage("Character name must be at least 4 characters")
            .MaximumLength(25).WithMessage("Character name cannot exceed 25 characters");
        
        RuleFor(character => character.Country)
            .MinimumLength(4).WithMessage("Country name must be at least 4 characters")
            .MaximumLength(25).WithMessage("Country name annot exceed 25 characters");
    }
}