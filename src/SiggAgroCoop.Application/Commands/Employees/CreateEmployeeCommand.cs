using MediatR;

namespace SiggAgroCoop.Application.Commands.Employees;

public record CreateEmployeeCommand(
    string Name,
    string Role,
    string DocumentId
) : IRequest<Guid>;
