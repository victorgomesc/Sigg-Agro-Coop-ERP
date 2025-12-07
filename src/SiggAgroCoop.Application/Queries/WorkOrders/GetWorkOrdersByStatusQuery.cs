using MediatR;
using SiggAgroCoop.Domain.Enums;
using SiggAgroCoop.Application.DTOs.WorkOrders;

namespace SiggAgroCoop.Application.Queries.WorkOrders;

public record GetWorkOrdersByStatusQuery(WorkOrderStatus Status) 
    : IRequest<IEnumerable<WorkOrderDto>>;
