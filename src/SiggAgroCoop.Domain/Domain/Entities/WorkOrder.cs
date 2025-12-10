using SiggAgroCoop.Domain.Common;
using SiggAgroCoop.Domain.Enums;

namespace SiggAgroCoop.Domain.Entities;

public class WorkOrder : BaseEntity
{
    public string Title { get; set; } = default!;
    public string Description { get; set; } = default!;
    public WorkOrderStatus Status { get; set; } = WorkOrderStatus.Open;
    public Guid EmployeeId { get; set; }
    public Employee Employee { get; set; } = default!;
    public Guid? FieldId { get; set; }
    public Field? Field { get; set; }
    public List<WorkOrderTool> Tools { get; set; } = new();
}
