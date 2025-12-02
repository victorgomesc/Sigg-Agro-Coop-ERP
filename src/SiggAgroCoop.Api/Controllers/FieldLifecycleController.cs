using MediatR;
using Microsoft.AspNetCore.Mvc;
using SiggAgroCoop.Application.Commands.FieldLifecycle;

namespace SiggAgroCoop.Api.Controllers;

[ApiController]
[Route("api/field-lifecycle")]
public class FieldLifecycleController : ControllerBase
{
    private readonly IMediator _mediator;

    public FieldLifecycleController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("start-planting")]
    public async Task<IActionResult> StartPlanting(StartPlantingCommand command)
    {
        var ok = await _mediator.Send(command);
        return ok ? Ok() : NotFound();
    }

    [HttpPost("finish-planting")]
    public async Task<IActionResult> FinishPlanting(FinishPlantingCommand command)
    {
        var ok = await _mediator.Send(command);
        return ok ? Ok() : NotFound();
    }

    [HttpPost("start-harvest")]
    public async Task<IActionResult> StartHarvest(StartHarvestCommand command)
    {
        var ok = await _mediator.Send(command);
        return ok ? Ok() : NotFound();
    }

    [HttpPost("finish-harvest")]
    public async Task<IActionResult> FinishHarvest(FinishHarvestCommand command)
    {
        var ok = await _mediator.Send(command);
        return ok ? Ok() : NotFound();
    }
}
