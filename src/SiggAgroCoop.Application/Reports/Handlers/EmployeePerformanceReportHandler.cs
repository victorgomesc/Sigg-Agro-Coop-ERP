using MediatR;

using SiggAgroCoop.Application.Reports.DTOs;
using SiggAgroCoop.Application.Reports.Queries;
using SiggAgroCoop.Domain.Enums;

namespace SiggAgroCoop.Application.Reports.Handlers;

public class EmployeePerformanceReportHandler :
    IRequestHandler<EmployeePerformanceReportQuery, IEnumerable<EmployeePerformanceDto>>
{
    private readonly AppDb _context;

    public EmployeePerformanceReportHandler(IReportingDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<EmployeePerformanceDto>> Handle(
        EmployeePerformanceReportQuery request,
        CancellationToken cancellationToken)
    {
        var employees = _context.Employees.AsQueryable();

        if (request.EmployeeId.HasValue)
            employees = employees.Where(e => e.Id == request.EmployeeId.Value);

        var result = new List<EmployeePerformanceDto>();

        foreach (var emp in employees)
        {
            var completed = await _context.WorkOrders
                .Where(w => w.EmployeeId == emp.Id && w.Status == WorkOrderStatus.Completed)
                .ToListAsync();

            double avgHours = completed.Any()
                ? completed.Average(c => (c.UpdatedAt - c.CreatedAt).TotalHours)
                : 0;

            var tools = await _context.WorkOrderTools
                .Where(w => w.WorkOrder.EmployeeId == emp.Id)
                .Select(w => w.Tool.Name)
                .Distinct()
                .ToListAsync();

            result.Add(new EmployeePerformanceDto(
                emp.Id,
                emp.Name,
                completed.Count,
                avgHours,
                tools
            ));
        }

        return result;
    }
}
