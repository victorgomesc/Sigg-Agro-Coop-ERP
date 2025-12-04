using MediatR;
using Microsoft.AspNetCore.Mvc;
using SiggAgroCoop.Application.Commands.FieldLifecycle;
using SiggAgroCoop.Application.Queries.Plantings;
using SiggAgroCoop.Application.Queries.Harvests;

namespace SiggAgroCoop.Api.Controllers;

[ApiController]
[Route("api/field-lifecycle")]
public class FieldLifecycleController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator;

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

    [HttpGet("history/plantings/{fieldId:guid}")]
    public async Task<IActionResult> GetPlantingsHistory(Guid fieldId)
    {
        var result = await _mediator.Send(new GetPlantingsByFieldQuery(fieldId));
        return Ok(result);
    }

    [HttpGet("history/harvests/{fieldId:guid}")]
    public async Task<IActionResult> GetHarvestsHistory(Guid fieldId)
    {
        var result = await _mediator.Send(new GetHarvestsByFieldQuery(fieldId));
        return Ok(result);
    }
}
