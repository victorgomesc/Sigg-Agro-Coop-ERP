namespace SiggAgroCoop.Application.Inventory.DTOs;

public class ProductDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public decimal CurrentStock { get; set; }
    public string CategoryName { get; set; } = null!;
    public string UnitSymbol { get; set; } = null!;
}
