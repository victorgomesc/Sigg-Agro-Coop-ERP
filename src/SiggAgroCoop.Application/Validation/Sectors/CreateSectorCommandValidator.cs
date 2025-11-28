using FluentValidation;
using SiggAgroCoop.Application.Commands.Sectors;

namespace SiggAgroCoop.Application.Validation.Sectors;

public class CreateSectorCommandValidator : AbstractValidator<CreateSectorCommand>
{
    public CreateSectorCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name is required.")
            .MaximumLength(150).WithMessage("Name must be at most 150 characters.");

        RuleFor(x => x.FarmId)
            .NotEmpty().WithMessage("FarmId is required.");
    }
}
