using MediatR;

namespace SiggAgroCoop.Application.Commands.WorkOrders;

public record UpdateWorkOrderCommand(
    Guid Id,
    string Title,
    string Description,
    Guid EmployeeId,
    Guid? FieldId,
    IEnumerable<Guid> ToolIds
) : IRequest<bool>;
