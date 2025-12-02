using MediatR;
using SiggAgroCoop.Domain.Enums;
using SiggAgroCoop.Domain.Interfaces;
using SiggAgroCoop.Domain.Entities;

namespace SiggAgroCoop.Application.Commands.FieldLifecycle;

public class StartHarvestHandler : IRequestHandler<StartHarvestCommand, bool>
{
    private readonly IFieldRepository _fieldRepository;
    private readonly ICropRepository _cropRepository;
    private readonly IHarvestRepository _harvestRepository;

    public StartHarvestHandler(
        IFieldRepository fieldRepository,
        ICropRepository cropRepository,
        IHarvestRepository harvestRepository)
    {
        _fieldRepository = fieldRepository;
        _cropRepository = cropRepository;
        _harvestRepository = harvestRepository;
    }

    public async Task<bool> Handle(StartHarvestCommand request, CancellationToken cancellationToken)
    {
        var field = await _fieldRepository.GetByIdAsync(request.FieldId);
        if (field is null) return false;

        var crop = await _cropRepository.GetByIdAsync(request.CropId);
        if (crop is null) return false;

        // Status mudando para "Harvest"
        field.Status = FieldStatus.Harvest;
        field.SetUpdatedNow();
        await _fieldRepository.UpdateAsync(field);

        var harvest = new Harvest
        {
            FieldId = request.FieldId,
            CropId = request.CropId,
            HarvestDate = request.HarvestDate,
            MoisturePercentage = request.MoisturePercentage,
            Notes = request.Notes,
            YieldUnit = "kg",   // padrão
            YieldQuantity = 0   // será atualizado depois
        };

        await _harvestRepository.AddAsync(harvest);

        return true;
    }
}
