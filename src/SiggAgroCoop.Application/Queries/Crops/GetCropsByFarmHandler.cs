using MediatR;
using SiggAgroCoop.Application.DTOs.Crops;
using SiggAgroCoop.Domain.Interfaces;

namespace SiggAgroCoop.Application.Queries.Crops;

public class GetCropsByFarmHandler : IRequestHandler<GetCropsByFarmQuery, IEnumerable<CropDto>>
{
    private readonly ICropRepository _cropRepository;

    public GetCropsByFarmHandler(ICropRepository cropRepository)
    {
        _cropRepository = cropRepository;
    }

    public async Task<IEnumerable<CropDto>> Handle(GetCropsByFarmQuery request, CancellationToken cancellationToken)
    {
        var crops = await _cropRepository.GetAllByFarmAsync(request.FarmId);
        return crops.Select(c => new CropDto(c.Id, c.Name, c.Variety, c.Season, c.FarmId));
    }
}
