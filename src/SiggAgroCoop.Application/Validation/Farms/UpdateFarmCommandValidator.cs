using FluentValidation;
using SiggAgroCoop.Application.Commands.Farms;

namespace SiggAgroCoop.Application.Validation.Farms;

public class UpdateFarmCommandValidator : AbstractValidator<UpdateFarmCommand>
{
    public UpdateFarmCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Id is required.");

        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name is required.")
            .MaximumLength(150).WithMessage("Name must be at most 150 characters.");

        RuleFor(x => x.Location)
            .NotEmpty().WithMessage("Location is required.")
            .MaximumLength(250).WithMessage("Location must be at most 250 characters.");
    }
}
