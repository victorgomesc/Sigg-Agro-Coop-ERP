using MediatR;

namespace SiggAgroCoop.Application.Commands.Sectors;

public record DeleteSectorCommand(Guid Id) : IRequest<bool>;
