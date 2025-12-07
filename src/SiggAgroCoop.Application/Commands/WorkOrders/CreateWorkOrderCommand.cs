using MediatR;

namespace SiggAgroCoop.Application.Commands.WorkOrders;

public record CreateWorkOrderCommand(
    string Title,
    string Description,
    Guid EmployeeId,
    Guid? FieldId,
    IEnumerable<Guid> ToolIds
) : IRequest<Guid>;
