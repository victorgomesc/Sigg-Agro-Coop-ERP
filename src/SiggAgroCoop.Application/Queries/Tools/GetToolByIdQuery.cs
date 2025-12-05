using MediatR;
using SiggAgroCoop.Application.DTOs.Tools;

namespace SiggAgroCoop.Application.Queries.Tools;

public record GetToolByIdQuery(Guid Id) : IRequest<ToolDto?>;
