using MediatR;

namespace SiggAgroCoop.Application.Commands.FieldLifecycle;

public record StartPlantingCommand(
    Guid FieldId,
    Guid CropId,
    DateTime PlantingDate,
    DateTime? ExpectedHarvestDate,
    double SeedDensityKgPerHectare,
    string? Notes
) : IRequest<bool>;
