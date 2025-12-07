using MediatR;
using SiggAgroCoop.Application.DTOs.WorkOrders;

namespace SiggAgroCoop.Application.Queries.WorkOrders;

public record GetAllWorkOrdersQuery() : IRequest<IEnumerable<WorkOrderDto>>;
