using MediatR;

namespace SiggAgroCoop.Application.Commands.Tools;

public record CreateToolCommand(
    string Name,
    string Description,
    DateTime AcquisitionDate,
    Guid EmployeeId
) : IRequest<Guid>;
