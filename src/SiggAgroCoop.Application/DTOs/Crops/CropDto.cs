namespace SiggAgroCoop.Application.DTOs.Crops;

public record CropDto(
    Guid Id,
    string Name,
    string Variety,
    string Season,
    Guid FarmId
);
