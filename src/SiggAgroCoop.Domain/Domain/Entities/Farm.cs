using SiggAgroCoop.Domain.Common;

namespace SiggAgroCoop.Domain.Entities;

public class Farm : BaseEntity
{
    public string Name { get; set; } = default!;
    public string Location { get; set; } = default!;
    public List<Sector> Sectors { get; set; } = new();
    public List<Crop> Crops { get; set; } = new();
}
