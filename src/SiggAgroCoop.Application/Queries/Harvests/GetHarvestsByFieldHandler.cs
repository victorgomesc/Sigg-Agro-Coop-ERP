using MediatR;
using SiggAgroCoop.Application.DTOs.Harvests;
using SiggAgroCoop.Domain.Interfaces;

namespace SiggAgroCoop.Application.Queries.Harvests;

public class GetHarvestsByFieldHandler 
    : IRequestHandler<GetHarvestsByFieldQuery, IEnumerable<HarvestHistoryDto>>
{
    private readonly IHarvestRepository _harvestRepository;

    public GetHarvestsByFieldHandler(IHarvestRepository harvestRepository)
    {
        _harvestRepository = harvestRepository;
    }

    public async Task<IEnumerable<HarvestHistoryDto>> Handle(
        GetHarvestsByFieldQuery request, 
        CancellationToken cancellationToken)
    {
        var harvests = await _harvestRepository.GetByFieldAsync(request.FieldId);

        return harvests.Select(h => new HarvestHistoryDto(
            h.Id,
            h.FieldId,
            h.CropId,
            h.HarvestDate,
            h.YieldQuantity,
            h.YieldUnit,
            h.MoisturePercentage,
            h.Notes
        ));
    }
}
