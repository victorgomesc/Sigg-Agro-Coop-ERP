using SiggAgroCoop.Domain.Enums;

namespace SiggAgroCoop.Application.DTOs.WorkOrders;

public record WorkOrderDto(
    Guid Id,
    string Title,
    string Description,
    WorkOrderStatus Status,
    Guid EmployeeId,
    Guid? FieldId,
    IEnumerable<Guid> ToolIds
);
