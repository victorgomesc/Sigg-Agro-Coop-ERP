using FluentValidation;
using SiggAgroCoop.Application.Commands.Fields;

namespace SiggAgroCoop.Application.Validation.Fields;

public class DeleteFieldCommandValidator : AbstractValidator<DeleteFieldCommand>
{
    public DeleteFieldCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Id is required.");
    }
}
