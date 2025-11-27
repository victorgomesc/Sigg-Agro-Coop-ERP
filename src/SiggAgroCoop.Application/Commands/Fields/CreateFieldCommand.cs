using MediatR;

namespace SiggAgroCoop.Application.Commands.Fields;

public record CreateFieldCommand(string Name, double AreaInHectares, Guid SectorId) : IRequest<Guid>;
