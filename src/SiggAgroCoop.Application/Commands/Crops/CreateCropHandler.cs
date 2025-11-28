using MediatR;
using SiggAgroCoop.Domain.Entities;
using SiggAgroCoop.Domain.Interfaces;

namespace SiggAgroCoop.Application.Commands.Crops;

public class CreateCropHandler : IRequestHandler<CreateCropCommand, Guid>
{
    private readonly ICropRepository _cropRepository;
    private readonly IFarmRepository _farmRepository;

    public CreateCropHandler(ICropRepository cropRepository, IFarmRepository farmRepository)
    {
        _cropRepository = cropRepository;
        _farmRepository = farmRepository;
    }

    public async Task<Guid> Handle(CreateCropCommand request, CancellationToken cancellationToken)
    {
        var farm = await _farmRepository.GetByIdAsync(request.FarmId);
        if (farm is null)
            throw new ArgumentException("Farm not found.");

        var crop = new Crop
        {
            Name = request.Name,
            Variety = request.Variety,
            Season = request.Season,
            FarmId = request.FarmId
        };

        await _cropRepository.AddAsync(crop);
        return crop.Id;
    }
}
