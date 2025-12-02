using SiggAgroCoop.Domain.Common;

namespace SiggAgroCoop.Domain.Entities;

public class Harvest : BaseEntity
{
    // Which field is being harvested
    public Guid FieldId { get; set; }
    public Field Field { get; set; } = default!;

    // Which crop is being harvested
    public Guid CropId { get; set; }
    public Crop Crop { get; set; } = default!;

    public DateTime HarvestDate { get; set; }

    // Production information
    public double YieldQuantity { get; set; }          // ex: 5000
    public string YieldUnit { get; set; } = "kg";      // ex: kg, bags, tons

    public double? MoisturePercentage { get; set; }    // ex: 13.5%
    public string? Notes { get; set; }
}
