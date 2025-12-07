namespace SiggAgroCoop.Domain.Entities;

public class WorkOrderTool
{
    public Guid WorkOrderId { get; set; }
    public WorkOrder WorkOrder { get; set; } = default!;

    public Guid ToolId { get; set; }
    public Tool Tool { get; set; } = default!;
}
