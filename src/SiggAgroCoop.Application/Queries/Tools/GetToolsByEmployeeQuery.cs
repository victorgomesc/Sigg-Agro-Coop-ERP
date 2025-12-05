using MediatR;
using SiggAgroCoop.Application.DTOs.Tools;

namespace SiggAgroCoop.Application.Queries.Tools;

public record GetToolsByEmployeeQuery(Guid EmployeeId) : IRequest<IEnumerable<ToolDto>>;
