using MediatR;
using SiggAgroCoop.Application.DTOs.WorkOrders;

namespace SiggAgroCoop.Application.Queries.WorkOrders;

public record GetWorkOrdersByEmployeeQuery(Guid EmployeeId) 
    : IRequest<IEnumerable<WorkOrderDto>>;
