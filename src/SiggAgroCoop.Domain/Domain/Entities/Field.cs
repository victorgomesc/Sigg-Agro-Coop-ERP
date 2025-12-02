using SiggAgroCoop.Domain.Common;
using SiggAgroCoop.Domain.Enums;

namespace SiggAgroCoop.Domain.Entities;

public class Field : BaseEntity
{
    public string Name { get; set; } = default!;
    public double AreaInHectares { get; set; }
    public Guid SectorId { get; set; }
    public Sector Sector { get; set; } = default!;
    public FieldStatus Status { get; set; } = FieldStatus.Idle;
    public List<Planting> Plantings { get; set; } = new();
    public List<Harvest> Harvests { get; set; } = new();
}
