using MediatR;

namespace SiggAgroCoop.Application.Commands.Sectors;

public record UpdateSectorCommand(Guid Id, string Name, Guid FarmId) : IRequest<bool>;
