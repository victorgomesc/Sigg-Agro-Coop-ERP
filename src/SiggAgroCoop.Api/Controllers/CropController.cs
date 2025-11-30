using MediatR;
using Microsoft.AspNetCore.Mvc;
using SiggAgroCoop.Application.Commands.Crops;
using SiggAgroCoop.Application.Queries.Crops;

namespace SiggAgroCoop.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CropController : ControllerBase
{
    private readonly IMediator _mediator;

    public CropController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateCropCommand command)
    {
        var id = await _mediator.Send(command);
        return Ok(new { Id = id });
    }

    [HttpGet("by-farm/{farmId:guid}")]
    public async Task<IActionResult> GetByFarm(Guid farmId)
    {
        var result = await _mediator.Send(new GetCropsByFarmQuery(farmId));
        return Ok(result);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await _mediator.Send(new GetCropByIdQuery(id));
        return result is null ? NotFound() : Ok(result);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, UpdateCropCommand command)
    {
        if (id != command.Id)
            return BadRequest("Route ID and body ID mismatch.");

        var ok = await _mediator.Send(command);
        return ok ? Ok() : NotFound();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var ok = await _mediator.Send(new DeleteCropCommand(id));
        return ok ? Ok() : NotFound();
    }
}
