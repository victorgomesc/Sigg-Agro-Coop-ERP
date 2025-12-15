namespace SiggAgroCoop.Domain.Entities;

public class Supplier : BaseEntity
{
    public string Name { get; set; } = null!;
    public string? DocumentNumber { get; set; }  // CNPJ/CPF
    public string? Email { get; set; }
    public string? Phone { get; set; }

    public ICollection<Product> Products { get; set; } = new List<Product>();
    public ICollection<InventoryMovement> InventoryMovements { get; set; } = new List<InventoryMovement>();
}
