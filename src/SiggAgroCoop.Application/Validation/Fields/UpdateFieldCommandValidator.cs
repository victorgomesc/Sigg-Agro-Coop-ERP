using FluentValidation;
using SiggAgroCoop.Application.Commands.Fields;

namespace SiggAgroCoop.Application.Validation.Fields;

public class UpdateFieldCommandValidator : AbstractValidator<UpdateFieldCommand>
{
    public UpdateFieldCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Id is required.");

        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name is required.")
            .MaximumLength(150).WithMessage("Name must be at most 150 characters.");

        RuleFor(x => x.AreaInHectares)
            .GreaterThan(0).WithMessage("AreaInHectares must be greater than zero.");

        RuleFor(x => x.SectorId)
            .NotEmpty().WithMessage("SectorId is required.");
    }
}
