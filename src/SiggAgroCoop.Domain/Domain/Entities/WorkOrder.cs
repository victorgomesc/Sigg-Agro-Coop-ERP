using SiggAgroCoop.Domain.Common;
using SiggAgroCoop.Domain.Enums;

namespace SiggAgroCoop.Domain.Entities;

public class WorkOrder : BaseEntity
{
    public string Title { get; set; } = default!;
    public string Description { get; set; } = default!;
    
    public WorkOrderStatus Status { get; set; } = WorkOrderStatus.Open;

    // Assigned employee
    public Guid EmployeeId { get; set; }
    public Employee Employee { get; set; } = default!;

    // Optionally related to a field (ex: realizar colheita no talhão 7)
    public Guid? FieldId { get; set; }
    public Field? Field { get; set; }

    // Tools used in this work order (many-to-many)
    public List<WorkOrderTool> Tools { get; set; } = new();
}
