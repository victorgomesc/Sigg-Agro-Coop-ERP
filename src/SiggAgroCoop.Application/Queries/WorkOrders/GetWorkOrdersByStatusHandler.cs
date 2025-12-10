using MediatR;
using Microsoft.EntityFrameworkCore;
using SiggAgroCoop.Application.DTOs.WorkOrders;
using SiggAgroCoop.Domain.Enums;
using SiggAgroCoop.Domain.Interfaces;

namespace SiggAgroCoop.Application.Queries.WorkOrders;

public class GetWorkOrdersByStatusHandler 
    : IRequestHandler<GetWorkOrdersByStatusQuery, List<WorkOrderDto>>
{
    private readonly IWorkOrderRepository _repository;

    public GetWorkOrdersByStatusHandler(IWorkOrderRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<WorkOrderDto>> Handle(GetWorkOrdersByStatusQuery request, CancellationToken cancellationToken)
    {
        var list = await _repository.Query()
            .Where(o => o.Status == WorkOrderStatus.Open)
            .ToListAsync(cancellationToken);

        return list.Select(WorkOrderDto.FromEntity).ToList();
    }
}
