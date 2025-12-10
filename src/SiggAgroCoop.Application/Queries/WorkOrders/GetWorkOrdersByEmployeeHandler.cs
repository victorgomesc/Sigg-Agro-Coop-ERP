using MediatR;
using Microsoft.EntityFrameworkCore;
using SiggAgroCoop.Application.DTOs.WorkOrders;
using SiggAgroCoop.Domain.Interfaces;

namespace SiggAgroCoop.Application.Queries.WorkOrders;

public class GetWorkOrdersByEmployeeHandler 
    : IRequestHandler<GetWorkOrdersByEmployeeQuery, List<WorkOrderDto>>
{
    private readonly IWorkOrderRepository _repository;

    public GetWorkOrdersByEmployeeHandler(IWorkOrderRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<WorkOrderDto>> Handle(GetWorkOrdersByEmployeeQuery request, CancellationToken cancellationToken)
    {
        var list = await _repository.Query()
            .Where(o => o.EmployeeId == request.EmployeeId)
            .ToListAsync(cancellationToken);

        return list.Select(WorkOrderDto.FromEntity).ToList();
    }
}
