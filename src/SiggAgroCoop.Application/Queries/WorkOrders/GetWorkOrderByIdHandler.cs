using MediatR;
using Microsoft.EntityFrameworkCore;
using SiggAgroCoop.Application.DTOs.WorkOrders;
using SiggAgroCoop.Domain.Interfaces;

namespace SiggAgroCoop.Application.Queries.WorkOrders;

public class GetWorkOrderByIdHandler : IRequestHandler<GetWorkOrderByIdQuery, WorkOrderDto?>
{
    private readonly IWorkOrderRepository _repository;

    public GetWorkOrderByIdHandler(IWorkOrderRepository repository)
    {
        _repository = repository;
    }

    public async Task<WorkOrderDto?> Handle(GetWorkOrderByIdQuery request, CancellationToken cancellationToken)
    {
        var order = await _repository.Query()
            .FirstOrDefaultAsync(o => o.Id == request.Id, cancellationToken);

        return order is null ? null : WorkOrderDto.FromEntity(order);
    }
}
