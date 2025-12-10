using MediatR;
using Microsoft.EntityFrameworkCore;
using SiggAgroCoop.Application.DTOs.WorkOrders;
using SiggAgroCoop.Domain.Interfaces;

namespace SiggAgroCoop.Application.Queries.WorkOrders;

public class GetWorkOrdersByDateRangeHandler 
    : IRequestHandler<GetWorkOrdersByDateRangeQuery, List<WorkOrderDto>>
{
    private readonly IWorkOrderRepository _repository;

    public GetWorkOrdersByDateRangeHandler(IWorkOrderRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<WorkOrderDto>> Handle(GetWorkOrdersByDateRangeQuery request, CancellationToken cancellationToken)
    {
        var list = await _repository.Query()
            .Where(o => o.CreatedAt >= request.Start && o.CreatedAt <= request.End)
            .ToListAsync(cancellationToken);

        return list.Select(WorkOrderDto.FromEntity).ToList();
    }
}
