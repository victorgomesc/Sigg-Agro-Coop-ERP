namespace SiggAgroCoop.Application.Reports.DTOs;

public record ProductivityReportDto(
    Guid FieldId,
    string FieldName,
    int TotalPlantings,
    int TotalHarvests,
    double TotalYieldKg,
    double AverageYieldPerHectare
);
