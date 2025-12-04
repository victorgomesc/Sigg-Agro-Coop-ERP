namespace SiggAgroCoop.Application.DTOs.Plantings;

public record PlantingHistoryDto(
    Guid Id,
    Guid FieldId,
    Guid CropId,
    DateTime PlantingDate,
    DateTime? ExpectedHarvestDate,
    double SeedDensityKgPerHectare,
    string? Notes
);
