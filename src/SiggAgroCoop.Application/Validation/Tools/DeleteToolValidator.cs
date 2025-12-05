using FluentValidation;
using SiggAgroCoop.Application.Commands.Tools;

namespace SiggAgroCoop.Application.Validation.Tools;

public class DeleteToolCommandValidator : AbstractValidator<DeleteToolCommand>
{
    public DeleteToolCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}
