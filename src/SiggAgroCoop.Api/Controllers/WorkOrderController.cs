using MediatR;
using Microsoft.AspNetCore.Mvc;
using SiggAgroCoop.Application.Commands.WorkOrders;
using SiggAgroCoop.Application.Queries.WorkOrders;

namespace SiggAgroCoop.Api.Controllers;

[ApiController]
[Route("api/work-orders")]
public class WorkOrderController : ControllerBase
{
    private readonly IMediator _mediator;

    public WorkOrderController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateWorkOrderCommand command)
        => Ok(await _mediator.Send(command));

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, UpdateWorkOrderCommand command)
    {
        if (id != command.Id) return BadRequest();
        return Ok(await _mediator.Send(command));
    }

    [HttpPost("{id:guid}/close")]
    public async Task<IActionResult> Close(Guid id)
        => Ok(await _mediator.Send(new CloseWorkOrderCommand(id)));

    [HttpPost("{id:guid}/cancel")]
    public async Task<IActionResult> Cancel(Guid id)
        => Ok(await _mediator.Send(new CancelWorkOrderCommand(id)));

    [HttpGet]
    public async Task<IActionResult> GetAll()
        => Ok(await _mediator.Send(new GetAllWorkOrdersQuery()));

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
        => Ok(await _mediator.Send(new GetWorkOrderByIdQuery(id)));

    [HttpGet("by-employee/{employeeId:guid}")]
    public async Task<IActionResult> GetByEmployee(Guid employeeId)
        => Ok(await _mediator.Send(new GetWorkOrdersByEmployeeQuery(employeeId)));
}
