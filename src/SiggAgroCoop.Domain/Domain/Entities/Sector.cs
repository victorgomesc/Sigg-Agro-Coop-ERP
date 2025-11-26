using SiggAgroCoop.Domain.Common;

namespace SiggAgroCoop.Domain.Entities;

public class Sector : BaseEntity
{
    public string Name { get; set; } = default!;
    public Guid FarmId { get; set; }
    public Farm Farm { get; set; } = default!;
    public List<Field> Fields { get; set; } = new();
}
