using MediatR;

namespace SiggAgroCoop.Application.Commands.Fields;

public record DeleteFieldCommand(Guid Id) : IRequest<bool>;
