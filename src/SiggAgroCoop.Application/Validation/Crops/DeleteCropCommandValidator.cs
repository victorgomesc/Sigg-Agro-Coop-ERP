using FluentValidation;
using SiggAgroCoop.Application.Commands.Crops;

namespace SiggAgroCoop.Application.Validation.Crops;

public class DeleteCropCommandValidator : AbstractValidator<DeleteCropCommand>
{
    public DeleteCropCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}
