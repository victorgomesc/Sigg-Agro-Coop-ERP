using MediatR;
using Microsoft.EntityFrameworkCore;
using SiggAgroCoop.Application.DTOs.WorkOrders;
using SiggAgroCoop.Application.Queries.WorkOrders;
using SiggAgroCoop.Domain.Interfaces;

namespace SiggAgroCoop.Application.Queries.WorkOrders;

public class GetAllWorkOrdersHandler : IRequestHandler<GetAllWorkOrdersQuery, List<WorkOrderDto>>
{
    private readonly IWorkOrderRepository _repository;

    public GetAllWorkOrdersHandler(IWorkOrderRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<WorkOrderDto>> Handle(GetAllWorkOrdersQuery request, CancellationToken cancellationToken)
    {
        var orders = await _repository.Query().ToListAsync(cancellationToken);

        return orders.Select(WorkOrderDto.FromEntity).ToList();
    }
}
