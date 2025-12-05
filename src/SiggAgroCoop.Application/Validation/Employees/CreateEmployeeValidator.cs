using FluentValidation;
using SiggAgroCoop.Application.Commands.Employees;

namespace SiggAgroCoop.Application.Validation.Employees;

public class CreateEmployeeCommandValidator : AbstractValidator<CreateEmployeeCommand>
{
    public CreateEmployeeCommandValidator()
    {
        RuleFor(x => x.Name).NotEmpty().MaximumLength(150);
        RuleFor(x => x.Role).NotEmpty().MaximumLength(100);
        RuleFor(x => x.DocumentId).NotEmpty().MaximumLength(20);
    }
}
