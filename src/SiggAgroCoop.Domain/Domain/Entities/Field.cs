using SiggAgroCoop.Domain.Common;

namespace SiggAgroCoop.Domain.Entities;

public class Field : BaseEntity
{
    public string Name { get; set; } = default!;
    public double AreaInHectares { get; set; }
    public Guid SectorId { get; set; }
    public Sector Sector { get; set; } = default!;
}
