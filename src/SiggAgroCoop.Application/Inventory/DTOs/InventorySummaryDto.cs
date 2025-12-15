namespace SiggAgroCoop.Application.Inventory.DTOs;

public class InventorySummaryDto
{
    public Guid ProductId { get; set; }
    public string Product { get; set; } = null!;
    public string Category { get; set; } = null!;
    public decimal Stock { get; set; }
}
