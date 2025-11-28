using MediatR;
using SiggAgroCoop.Domain.Interfaces;

namespace SiggAgroCoop.Application.Commands.Crops;

public class UpdateCropHandler : IRequestHandler<UpdateCropCommand, bool>
{
    private readonly ICropRepository _cropRepository;
    private readonly IFarmRepository _farmRepository;

    public UpdateCropHandler(ICropRepository cropRepository, IFarmRepository farmRepository)
    {
        _cropRepository = cropRepository;
        _farmRepository = farmRepository;
    }

    public async Task<bool> Handle(UpdateCropCommand request, CancellationToken cancellationToken)
    {
        var crop = await _cropRepository.GetByIdAsync(request.Id);
        if (crop is null)
            return false;

        var farm = await _farmRepository.GetByIdAsync(request.FarmId);
        if (farm is null)
            return false;

        crop.Name = request.Name;
        crop.Variety = request.Variety;
        crop.Season = request.Season;
        crop.FarmId = request.FarmId;
        crop.SetUpdatedNow();

        await _cropRepository.UpdateAsync(crop);
        return true;
    }
}
