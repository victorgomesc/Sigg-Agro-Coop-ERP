using MediatR;

namespace SiggAgroCoop.Application.Commands.Tools;

public record DeleteToolCommand(Guid Id) : IRequest<bool>;
