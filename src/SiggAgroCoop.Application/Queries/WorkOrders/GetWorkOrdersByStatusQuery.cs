using MediatR;
using SiggAgroCoop.Application.DTOs.WorkOrders;

namespace SiggAgroCoop.Application.Queries.WorkOrders;

public record GetWorkOrdersByStatusQuery(string Status) : IRequest<List<WorkOrderDto>>;
