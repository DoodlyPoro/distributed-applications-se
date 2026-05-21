using FluentValidation;

namespace api.Infrastructure.RequestDTOs.Sequences;

public class SequenceValidator : AbstractValidator<SequenceRequest>
{
    public SequenceValidator()
    {
        RuleFor(sequence => sequence.Name)
            .NotEmpty().WithMessage("Name is required.")
            .MinimumLength(5).WithMessage("Name must be at least 5 characters long.")
            .MaximumLength(30).WithMessage("Name must be no more than 30 characters long.");
        
        RuleFor(sequence => sequence.Number)
            .NotEmpty().WithMessage("Number is required.")
            .GreaterThanOrEqualTo(0).WithMessage("Number must be greater than or equal to 0.");
        
        RuleFor(sequence => sequence.Description)
            .NotEmpty().WithMessage("Description is required.")
            .MinimumLength(25).WithMessage("Description must be at least 25 characters long.")
            .MaximumLength(250).WithMessage("Description must be no more than 250 characters long.");
    }
}