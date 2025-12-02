using MediatR;
using SiggAgroCoop.Domain.Enums;
using SiggAgroCoop.Domain.Interfaces;
using SiggAgroCoop.Domain.Entities;

namespace SiggAgroCoop.Application.Commands.FieldLifecycle;

public class StartPlantingHandler : IRequestHandler<StartPlantingCommand, bool>
{
    private readonly IFieldRepository _fieldRepository;
    private readonly ICropRepository _cropRepository;
    private readonly IPlantingRepository _plantingRepository;

    public StartPlantingHandler(
        IFieldRepository fieldRepository,
        ICropRepository cropRepository,
        IPlantingRepository plantingRepository)
    {
        _fieldRepository = fieldRepository;
        _cropRepository = cropRepository;
        _plantingRepository = plantingRepository;
    }

    public async Task<bool> Handle(StartPlantingCommand request, CancellationToken cancellationToken)
    {
        var field = await _fieldRepository.GetByIdAsync(request.FieldId);
        if (field is null) return false;

        var crop = await _cropRepository.GetByIdAsync(request.CropId);
        if (crop is null) return false;

        // Coloca em status "Planting"
        field.Status = FieldStatus.Planting;
        field.SetUpdatedNow();
        await _fieldRepository.UpdateAsync(field);

        var planting = new Planting
        {
            FieldId = request.FieldId,
            CropId = request.CropId,
            PlantingDate = request.PlantingDate,
            ExpectedHarvestDate = request.ExpectedHarvestDate,
            SeedDensityKgPerHectare = request.SeedDensityKgPerHectare,
            Notes = request.Notes
        };

        await _plantingRepository.AddAsync(planting);

        return true;
    }
}
