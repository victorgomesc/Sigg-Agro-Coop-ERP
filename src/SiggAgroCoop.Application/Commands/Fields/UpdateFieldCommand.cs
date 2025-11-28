using MediatR;

namespace SiggAgroCoop.Application.Commands.Fields;

public record UpdateFieldCommand(Guid Id, string Name, double AreaInHectares, Guid SectorId) : IRequest<bool>;
