using SiggAgroCoop.Domain.Common;

namespace SiggAgroCoop.Domain.Entities;

public class Planting : BaseEntity
{
    // Which field is being planted
    public Guid FieldId { get; set; }
    public Field Field { get; set; } = default!;

    // Which crop is being planted
    public Guid CropId { get; set; }
    public Crop Crop { get; set; } = default!;

    public DateTime PlantingDate { get; set; }
    public DateTime? ExpectedHarvestDate { get; set; }

    // Agronomic details (you can expand later)
    public double SeedDensityKgPerHectare { get; set; }
    public string? Notes { get; set; }
}
