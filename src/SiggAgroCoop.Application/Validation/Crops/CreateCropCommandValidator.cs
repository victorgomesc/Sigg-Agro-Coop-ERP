using FluentValidation;
using SiggAgroCoop.Application.Commands.Crops;

namespace SiggAgroCoop.Application.Validation.Crops;

public class CreateCropCommandValidator : AbstractValidator<CreateCropCommand>
{
    public CreateCropCommandValidator()
    {
        RuleFor(x => x.Name).NotEmpty().MaximumLength(150);
        RuleFor(x => x.Variety).NotEmpty().MaximumLength(150);
        RuleFor(x => x.Season).NotEmpty().MaximumLength(100);
        RuleFor(x => x.FarmId).NotEmpty();
    }
}
