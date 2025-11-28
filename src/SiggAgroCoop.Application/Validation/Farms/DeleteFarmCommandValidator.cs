using FluentValidation;
using SiggAgroCoop.Application.Commands.Farms;

namespace SiggAgroCoop.Application.Validation.Farms;

public class DeleteFarmCommandValidator : AbstractValidator<DeleteFarmCommand>
{
    public DeleteFarmCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Id is required.");
    }
}
