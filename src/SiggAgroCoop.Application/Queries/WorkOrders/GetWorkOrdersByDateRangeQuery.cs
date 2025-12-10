using MediatR;
using SiggAgroCoop.Application.DTOs.WorkOrders;

namespace SiggAgroCoop.Application.Queries.WorkOrders;

public record GetWorkOrdersByDateRangeQuery(DateTime Start, DateTime End)
    : IRequest<List<WorkOrderDto>>;
