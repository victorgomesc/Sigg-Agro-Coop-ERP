using FluentValidation;
using SiggAgroCoop.Application.Commands.Crops;

namespace SiggAgroCoop.Application.Validation.Crops;

public class UpdateCropCommandValidator : AbstractValidator<UpdateCropCommand>
{
    public UpdateCropCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
        RuleFor(x => x.Name).NotEmpty().MaximumLength(150);
        RuleFor(x => x.Variety).NotEmpty().MaximumLength(150);
        RuleFor(x => x.Season).NotEmpty().MaximumLength(100);
        RuleFor(x => x.FarmId).NotEmpty();
    }
}
