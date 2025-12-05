using MediatR;
using Microsoft.AspNetCore.Mvc;
using SiggAgroCoop.Application.Commands.Tools;
using SiggAgroCoop.Application.Queries.Tools;

namespace SiggAgroCoop.Api.Controllers;

[ApiController]
[Route("api/tools")]
public class ToolController : ControllerBase
{
    private readonly IMediator _mediator;

    public ToolController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateToolCommand command)
        => Ok(new { Id = await _mediator.Send(command) });

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, UpdateToolCommand command)
    {
        if (id != command.Id) return BadRequest("Route ID mismatch.");
        return await _mediator.Send(command) ? Ok() : NotFound();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
        => await _mediator.Send(new DeleteToolCommand(id)) ? Ok() : NotFound();

    [HttpGet]
    public async Task<IActionResult> GetAll()
        => Ok(await _mediator.Send(new GetAllToolsQuery()));

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
        => Ok(await _mediator.Send(new GetToolByIdQuery(id)));

    [HttpGet("by-employee/{employeeId:guid}")]
    public async Task<IActionResult> GetByEmployee(Guid employeeId)
        => Ok(await _mediator.Send(new GetToolsByEmployeeQuery(employeeId)));
}
