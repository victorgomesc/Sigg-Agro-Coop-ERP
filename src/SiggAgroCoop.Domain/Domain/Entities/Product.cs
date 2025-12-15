namespace SiggAgroCoop.Domain.Entities;

public class Product : BaseEntity
{
    public string Name { get; set; } = null!;
    public string? Description { get; set; }

    public Guid CategoryId { get; set; }
    public Category Category { get; set; } = null!;

    public Guid UnitOfMeasureId { get; set; }
    public UnitOfMeasure UnitOfMeasure { get; set; } = null!;

    public Guid? DefaultSupplierId { get; set; }
    public Supplier? DefaultSupplier { get; set; }

    // Estoque atual – vamos manter para consulta rápida
    public decimal CurrentStock { get; set; }
}
