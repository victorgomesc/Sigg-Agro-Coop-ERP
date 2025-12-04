namespace SiggAgroCoop.Application.DTOs.Harvests;

public record HarvestHistoryDto(
    Guid Id,
    Guid FieldId,
    Guid CropId,
    DateTime HarvestDate,
    double YieldQuantity,
    string YieldUnit,
    double? MoisturePercentage,
    string? Notes
);
