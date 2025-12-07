using MediatR;
using SiggAgroCoop.Domain.Entities;
using SiggAgroCoop.Domain.Enums;
using SiggAgroCoop.Domain.Interfaces;

namespace SiggAgroCoop.Application.Commands.WorkOrders;

public class CreateWorkOrderHandler : IRequestHandler<CreateWorkOrderCommand, Guid>
{
    private readonly IWorkOrderRepository _workRepo;
    private readonly IEmployeeRepository _empRepo;
    private readonly IToolRepository _toolRepo;

    public CreateWorkOrderHandler(
        IWorkOrderRepository workRepo,
        IEmployeeRepository empRepo,
        IToolRepository toolRepo)
    {
        _workRepo = workRepo;
        _empRepo = empRepo;
        _toolRepo = toolRepo;
    }

    public async Task<Guid> Handle(CreateWorkOrderCommand request, CancellationToken cancellationToken)
    {
        var employee = await _empRepo.GetByIdAsync(request.EmployeeId);
        if (employee is null)
            throw new ArgumentException("Employee not found");

        var workOrder = new WorkOrder
        {
            Title = request.Title,
            Description = request.Description,
            EmployeeId = request.EmployeeId,
            FieldId = request.FieldId,
            Status = WorkOrderStatus.Open
        };

        foreach (var toolId in request.ToolIds)
        {
            workOrder.Tools.Add(new WorkOrderTool
            {
                ToolId = toolId,
                WorkOrderId = workOrder.Id
            });
        }

        await _workRepo.AddAsync(workOrder);
        return workOrder.Id;
    }
}
