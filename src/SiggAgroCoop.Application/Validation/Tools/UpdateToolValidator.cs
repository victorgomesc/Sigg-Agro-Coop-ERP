using FluentValidation;
using SiggAgroCoop.Application.Commands.Tools;

namespace SiggAgroCoop.Application.Validation.Tools;

public class UpdateToolCommandValidator : AbstractValidator<UpdateToolCommand>
{
    public UpdateToolCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
        RuleFor(x => x.Name).NotEmpty().MaximumLength(150);
        RuleFor(x => x.Description).NotEmpty().MaximumLength(300);
        RuleFor(x => x.EmployeeId).NotEmpty();
    }
}
