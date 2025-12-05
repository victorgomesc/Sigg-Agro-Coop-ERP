using MediatR;

namespace SiggAgroCoop.Application.Commands.Employees;

public record UpdateEmployeeCommand(
    Guid Id,
    string Name,
    string Role,
    string DocumentId
) : IRequest<bool>;
