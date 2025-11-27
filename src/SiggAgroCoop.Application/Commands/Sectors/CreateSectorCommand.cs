using MediatR;

namespace SiggAgroCoop.Application.Commands.Sectors;

public record CreateSectorCommand(string Name, Guid FarmId) : IRequest<Guid>;
