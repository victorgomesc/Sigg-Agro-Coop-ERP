using SiggAgroCoop.Domain.Enums;

namespace SiggAgroCoop.Domain.Entities;

public class InventoryMovement : BaseEntity
{
    public Guid ProductId { get; set; }
    public Product Product { get; set; } = null!;

    public InventoryMovementType MovementType { get; set; }

    public decimal Quantity { get; set; }

    public DateTime MovementDate { get; set; }

    public Guid? SupplierId { get; set; }
    public Supplier? Supplier { get; set; }

    public string? Notes { get; set; }

    // Auditoria
    public Guid PerformedByUserId { get; set; }
}
