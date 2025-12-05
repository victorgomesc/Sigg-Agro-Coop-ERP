using MediatR;
using SiggAgroCoop.Application.DTOs.Tools;

namespace SiggAgroCoop.Application.Queries.Tools;

public record GetAllToolsQuery() : IRequest<IEnumerable<ToolDto>>;
