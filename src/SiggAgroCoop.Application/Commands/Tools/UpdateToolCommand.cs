using MediatR;

namespace SiggAgroCoop.Application.Commands.Tools;

public record UpdateToolCommand(
    Guid Id,
    string Name,
    string Description,
    DateTime AcquisitionDate,
    Guid EmployeeId
) : IRequest<bool>;
