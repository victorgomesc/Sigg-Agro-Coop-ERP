using FluentValidation;
using SiggAgroCoop.Application.Commands.Sectors;

namespace SiggAgroCoop.Application.Validation.Sectors;

public class DeleteSectorCommandValidator : AbstractValidator<DeleteSectorCommand>
{
    public DeleteSectorCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Id is required.");
    }
}
