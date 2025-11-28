using SiggAgroCoop.Domain.Common;

namespace SiggAgroCoop.Domain.Entities;

public class Crop : BaseEntity
{
    public string Name { get; set; } = default!;
    public string Variety { get; set; } = default!;
    public string Season { get; set; } = default!;

    // Relationship: A Crop belongs to a Farm
    public Guid FarmId { get; set; }
    public Farm Farm { get; set; } = default!;
}
