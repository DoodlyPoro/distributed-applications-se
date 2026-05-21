using FluentValidation;

namespace api.Infrastructure.RequestDTOs.Pathways;

public class PathwayValidator : AbstractValidator<PathwayRequest>
{
    public PathwayValidator()
    {
        RuleFor(pathway => pathway.Name)
            .NotEmpty().WithMessage("Name is required")
            .MinimumLength(4).WithMessage("Name must be at least 4 characters long")
            .MaximumLength(15).WithMessage("Name must be less than 15 characters long");
        
        RuleFor(pathway => pathway.Description)
            .NotEmpty().WithMessage("Description is required")
            .MinimumLength(25).WithMessage("Description must be at least 25 characters long")
            .MaximumLength(250).WithMessage("Description must be less than 250 characters long");
    }
}