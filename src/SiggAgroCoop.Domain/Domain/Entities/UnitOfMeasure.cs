namespace SiggAgroCoop.Domain.Entities;

public class UnitOfMeasure : BaseEntity
{
    public string Name { get; set; } = null!;      // Ex: "Quilograma", "Saco"
    public string Symbol { get; set; } = null!;    // Ex: "kg", "sc"

    public ICollection<Product> Products { get; set; } = new List<Product>();
}
