using MediatR;

namespace SiggAgroCoop.Application.Commands.Crops;

public record CreateCropCommand(
    string Name,
    string Variety,
    string Season,
    Guid FarmId
) : IRequest<Guid>;
