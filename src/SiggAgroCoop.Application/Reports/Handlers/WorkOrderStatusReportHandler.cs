using MediatR;
using SiggAgroCoop.Application.Interfaces.Reporting;
using SiggAgroCoop.Application.Reports.DTOs;
using SiggAgroCoop.Application.Reports.Queries;
using SiggAgroCoop.Domain.Enums;

namespace SiggAgroCoop.Application.Reports.Handlers;

public class WorkOrderStatusReportHandler :
    IRequestHandler<WorkOrderStatusReportQuery, IEnumerable<WorkOrderStatusReportDto>>
{
    private readonly IReportingDbContext _context;

    public WorkOrderStatusReportHandler(IReportingDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<WorkOrderStatusReportDto>> Handle(
        WorkOrderStatusReportQuery request, 
        CancellationToken cancellationToken)
    {
        int total = await _context.WorkOrders.CountAsync();

        var list = new List<WorkOrderStatusReportDto>();

        foreach (WorkOrderStatus status in Enum.GetValues(typeof(WorkOrderStatus)))
        {
            int count = await _context.WorkOrders.CountAsync(w => w.Status == status);
            double pct = total > 0 ? (count / (double)total) * 100 : 0;

            list.Add(new WorkOrderStatusReportDto(status, count, pct));
        }

        return list;
    }
}
