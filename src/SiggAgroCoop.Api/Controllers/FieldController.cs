using MediatR;
using Microsoft.AspNetCore.Mvc;
using SiggAgroCoop.Application.Commands.Fields;
using SiggAgroCoop.Application.Queries.Fields;

namespace SiggAgroCoop.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FieldController : ControllerBase
{
    private readonly IMediator _mediator;

    public FieldController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CreateField([FromBody] CreateFieldCommand command)
    {
        var id = await _mediator.Send(command);
        return Ok(new { Id = id });
    }

    [HttpGet("by-sector/{sectorId:guid}")]
    public async Task<IActionResult> GetBySector(Guid sectorId)
    {
        var fields = await _mediator.Send(new GetFieldsBySectorQuery(sectorId));
        return Ok(fields);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var field = await _mediator.Send(new GetFieldByIdQuery(id));
        if (field is null)
            return NotFound();

        return Ok(field);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateFieldCommand command)
    {
        if (id != command.Id)
            return BadRequest("Route ID and body ID mismatch.");

        var success = await _mediator.Send(command);
        return success ? Ok() : NotFound();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var success = await _mediator.Send(new DeleteFieldCommand(id));
        return success ? Ok() : NotFound();
    }

}
