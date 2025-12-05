using MediatR;

namespace SiggAgroCoop.Application.Commands.Employees;

public record DeleteEmployeeCommand(Guid Id) : IRequest<bool>;
