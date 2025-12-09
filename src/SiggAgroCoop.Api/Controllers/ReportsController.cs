using MediatR;
using Microsoft.AspNetCore.Mvc;
using SiggAgroCoop.Application.Reports.Queries;

namespace SiggAgroCoop.Api.Controllers;

[ApiController]
[Route("api/reports")]
public class ReportsController : ControllerBase
{
    private readonly IMediator _mediator;

    public ReportsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("productivity")]
    public async Task<IActionResult> Productivity([FromQuery] Guid? fieldId)
        => Ok(await _mediator.Send(new ProductivityReportQuery(fieldId)));

    [HttpGet("tools")]
    public async Task<IActionResult> Tools()
        => Ok(await _mediator.Send(new ToolUsageReportQuery()));

    [HttpGet("employees")]
    public async Task<IActionResult> Employees([FromQuery] Guid? employeeId)
        => Ok(await _mediator.Send(new EmployeePerformanceReportQuery(employeeId)));

    [HttpGet("workorders")]
    public async Task<IActionResult> WorkOrders()
        => Ok(await _mediator.Send(new WorkOrderStatusReportQuery()));

    [HttpGet("fields")]
    public async Task<IActionResult> Fields()
        => Ok(await _mediator.Send(new FieldOperationalReportQuery()));
}
