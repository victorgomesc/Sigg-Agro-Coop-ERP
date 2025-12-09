using MediatR;
using SiggAgroCoop.Application.Interfaces.Reporting;
using SiggAgroCoop.Application.Reports.DTOs;
using SiggAgroCoop.Application.Reports.Queries;

namespace SiggAgroCoop.Application.Reports.Handlers;

public class ToolUsageReportHandler 
    : IRequestHandler<ToolUsageReportQuery, IEnumerable<ToolUsageReportDto>>
{
    private readonly IReportingDbContext _context;

    public ToolUsageReportHandler(IReportingDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<ToolUsageReportDto>> Handle(
        ToolUsageReportQuery request, 
        CancellationToken cancellationToken)
    {
        return await _context.Tools
            .Select(tool => new ToolUsageReportDto(
                tool.Id,
                tool.Name,
                _context.WorkOrderTools.Count(w => w.ToolId == tool.Id),
                _context.WorkOrderTools
                    .Where(w => w.ToolId == tool.Id)
                    .Select(w => w.WorkOrder.Employee.Name)
                    .Distinct()
                    .ToList()
            ))
            .ToListAsync();
    }
}
