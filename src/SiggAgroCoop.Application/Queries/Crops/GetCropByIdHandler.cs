using MediatR;
using SiggAgroCoop.Application.DTOs.Crops;
using SiggAgroCoop.Domain.Interfaces;

namespace SiggAgroCoop.Application.Queries.Crops;

public class GetCropByIdHandler : IRequestHandler<GetCropByIdQuery, CropDto?>
{
    private readonly ICropRepository _cropRepository;

    public GetCropByIdHandler(ICropRepository cropRepository)
    {
        _cropRepository = cropRepository;
    }

    public async Task<CropDto?> Handle(GetCropByIdQuery request, CancellationToken cancellationToken)
    {
        var crop = await _cropRepository.GetByIdAsync(request.Id);
        if (crop is null)
            return null;

        return new CropDto(crop.Id, crop.Name, crop.Variety, crop.Season, crop.FarmId);
    }
}
