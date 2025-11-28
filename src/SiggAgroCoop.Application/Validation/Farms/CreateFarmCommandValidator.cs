using FluentValidation;
using SiggAgroCoop.Application.Commands.Farms;

namespace SiggAgroCoop.Application.Validation.Farms;

public class CreateFarmCommandValidator : AbstractValidator<CreateFarmCommand>
{
    public CreateFarmCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name is required.")
            .MaximumLength(150).WithMessage("Name must be at most 150 characters.");

        RuleFor(x => x.Location)
            .NotEmpty().WithMessage("Location is required.")
            .MaximumLength(250).WithMessage("Location must be at most 250 characters.");
    }
}
