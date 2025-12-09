using SiggAgroCoop.Domain.Enums;

namespace SiggAgroCoop.Application.Reports.DTOs;

public record FieldOperationalReportDto(
    Guid FieldId,
    string FieldName,
    FieldStatus Status,
    int TotalPlantings,
    int TotalHarvests,
    DateTime? LastPlantingDate,
    DateTime? LastHarvestDate
);
