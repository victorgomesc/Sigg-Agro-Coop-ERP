using MediatR;

namespace SiggAgroCoop.Application.Commands.Crops;

public record DeleteCropCommand(Guid Id) : IRequest<bool>;
