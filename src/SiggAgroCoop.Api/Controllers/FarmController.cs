using MediatR;
using Microsoft.AspNetCore.Mvc;
using SiggAgroCoop.Application.Commands.Farms;
using SiggAgroCoop.Application.Queries.Farms;

namespace SiggAgroCoop.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FarmController : ControllerBase
{
    private readonly IMediator _mediator;

    public FarmController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CreateFarm(CreateFarmCommand command)
    {
        var id = await _mediator.Send(command);
        return Ok(new { Id = id });
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var farms = await _mediator.Send(new GetAllFarmsQuery());
        return Ok(farms);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateFarmCommand command)
    {
        if (id != command.Id)
            return BadRequest("Route ID and body ID mismatch.");

        var success = await _mediator.Send(command);
        return success ? Ok() : NotFound();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var success = await _mediator.Send(new DeleteFarmCommand(id));
        return success ? Ok() : NotFound();
    }

}
