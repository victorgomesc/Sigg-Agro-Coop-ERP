namespace SiggAgroCoop.Application.DTOs.Fields;

public record FieldDto(Guid Id, string Name, double AreaInHectares, Guid SectorId);
