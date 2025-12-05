using MediatR;
using Microsoft.AspNetCore.Mvc;
using SiggAgroCoop.Application.Commands.Employees;
using SiggAgroCoop.Application.Queries.Employees;

namespace SiggAgroCoop.Api.Controllers;

[ApiController]
[Route("api/employees")]
public class EmployeeController : ControllerBase
{
    private readonly IMediator _mediator;

    public EmployeeController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateEmployeeCommand command)
        => Ok(new { Id = await _mediator.Send(command) });

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, UpdateEmployeeCommand command)
    {
        if (id != command.Id) return BadRequest("Route ID mismatch.");
        return await _mediator.Send(command) ? Ok() : NotFound();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
        => await _mediator.Send(new DeleteEmployeeCommand(id)) ? Ok() : NotFound();

    [HttpGet]
    public async Task<IActionResult> GetAll()
        => Ok(await _mediator.Send(new GetAllEmployeesQuery()));

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
        => Ok(await _mediator.Send(new GetEmployeeByIdQuery(id)));
}
