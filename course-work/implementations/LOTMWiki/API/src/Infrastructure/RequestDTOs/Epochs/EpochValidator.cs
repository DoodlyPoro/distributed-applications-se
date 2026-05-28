using Common.Entity;
using FluentValidation;

namespace api.Infrastructure.RequestDTOs.Epochs;

public class EpochValidator : AbstractValidator<EpochRequest>
{
    public EpochValidator()
    {
        RuleFor(epoch => epoch.Number)
            .NotEmpty().WithMessage("Epoch Number is required.")
            .GreaterThan(0).WithMessage("Epoch Number must be greater than zero.");
        
        RuleFor(epoch => epoch.Name)
            .NotEmpty().WithMessage("Epoch Name is required.")
            .MinimumLength(5).WithMessage("Epoch Name must be at least 5 characters long.")
            .MaximumLength(30).WithMessage("Epoch Name must be no more than 30 characters long.");

        RuleFor(epoch => epoch.StartYear)
            .NotEmpty().WithMessage("Start Year is required.");
    }
}