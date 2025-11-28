using MediatR;

namespace SiggAgroCoop.Application.Commands.Crops;

public record UpdateCropCommand(
    Guid Id,
    string Name,
    string Variety,
    string Season,
    Guid FarmId
) : IRequest<bool>;
