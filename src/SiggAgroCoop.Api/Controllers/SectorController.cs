using MediatR;
using Microsoft.AspNetCore.Mvc;
using SiggAgroCoop.Application.Commands.Sectors;
using SiggAgroCoop.Application.Queries.Sectors;

namespace SiggAgroCoop.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SectorController : ControllerBase
{
    private readonly IMediator _mediator;

    public SectorController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CreateSector([FromBody] CreateSectorCommand command)
    {
        var id = await _mediator.Send(command);
        return Ok(new { Id = id });
    }

    [HttpGet("by-farm/{farmId:guid}")]
    public async Task<IActionResult> GetByFarm(Guid farmId)
    {
        var sectors = await _mediator.Send(new GetSectorsByFarmQuery(farmId));
        return Ok(sectors);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var sector = await _mediator.Send(new GetSectorByIdQuery(id));
        if (sector is null)
            return NotFound();

        return Ok(sector);
    }
}
