using MediatR;
using SiggAgroCoop.Application.DTOs.WorkOrders;

namespace SiggAgroCoop.Application.Queries.WorkOrders;

public record GetWorkOrderByIdQuery(Guid Id) : IRequest<WorkOrderDto?>;
