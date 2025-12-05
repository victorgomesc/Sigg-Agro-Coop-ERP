using FluentValidation;
using SiggAgroCoop.Application.Commands.Employees;

namespace SiggAgroCoop.Application.Validation.Employees;

public class DeleteEmployeeCommandValidator : AbstractValidator<DeleteEmployeeCommand>
{
    public DeleteEmployeeCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}
