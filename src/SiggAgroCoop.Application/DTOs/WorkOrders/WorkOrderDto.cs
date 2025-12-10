using SiggAgroCoop.Domain.Entities;

namespace SiggAgroCoop.Application.DTOs.WorkOrders;

public class WorkOrderDto
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public Guid EmployeeId { get; set; }
    public Guid? FieldId { get; set; }
    public DateTime CreatedAt { get; set; }
    public IEnumerable<Guid> ToolIds { get; set; } = Enumerable.Empty<Guid>();

    public static WorkOrderDto FromEntity(WorkOrder entity)
    {
        return new WorkOrderDto
        {
            Id = entity.Id,
            Title = entity.Title,
            Description = entity.Description,
            Status = entity.Status.ToString(),
            EmployeeId = entity.EmployeeId,
            FieldId = entity.FieldId,
            CreatedAt = entity.CreatedAt,
            ToolIds = entity.Tools.Select(t => t.ToolId)
        };
    }
}
