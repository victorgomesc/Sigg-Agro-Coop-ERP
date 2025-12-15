using SiggAgroCoop.Domain.Enums;

namespace SiggAgroCoop.Application.Inventory.DTOs;

public class InventoryMovementDto
{
    public Guid Id { get; set; }
    public InventoryMovementType MovementType { get; set; }
    public decimal Quantity { get; set; }
    public DateTime MovementDate { get; set; }
    public string ProductName { get; set; } = null!;
    public string? Supplier { get; set; }
    public string? Notes { get; set; }
    public Guid PerformedByUserId { get; set; }
}
