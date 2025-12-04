using MediatR;
using SiggAgroCoop.Application.DTOs.Plantings;
using SiggAgroCoop.Domain.Interfaces;

namespace SiggAgroCoop.Application.Queries.Plantings;

public class GetPlantingsByFieldHandler 
    : IRequestHandler<GetPlantingsByFieldQuery, IEnumerable<PlantingHistoryDto>>
{
    private readonly IPlantingRepository _plantingRepository;

    public GetPlantingsByFieldHandler(IPlantingRepository plantingRepository)
    {
        _plantingRepository = plantingRepository;
    }

    public async Task<IEnumerable<PlantingHistoryDto>> Handle(
        GetPlantingsByFieldQuery request, 
        CancellationToken cancellationToken)
    {
        var plantings = await _plantingRepository.GetByFieldAsync(request.FieldId);

        return plantings.Select(p => new PlantingHistoryDto(
            p.Id,
            p.FieldId,
            p.CropId,
            p.PlantingDate,
            p.ExpectedHarvestDate,
            p.SeedDensityKgPerHectare,
            p.Notes
        ));
    }
}
