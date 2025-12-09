using MediatR;
using SiggAgroCoop.Application.Interfaces.Reporting;
using SiggAgroCoop.Application.Reports.DTOs;
using SiggAgroCoop.Application.Reports.Queries;

namespace SiggAgroCoop.Application.Reports.Handlers;

public class FieldOperationalReportHandler :
    IRequestHandler<FieldOperationalReportQuery, IEnumerable<FieldOperationalReportDto>>
{
    private readonly IReportingDbContext _context;

    public FieldOperationalReportHandler(IReportingDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<FieldOperationalReportDto>> Handle(
        FieldOperationalReportQuery request,
        CancellationToken cancellationToken)
    {
        var fields = await _context.Fields.ToListAsync();
        var result = new List<FieldOperationalReportDto>();

        foreach (var field in fields)
        {
            var plantings = await _context.Plantings
                .Where(p => p.FieldId == field.Id)
                .ToListAsync();

            var harvests = await _context.Harvests
                .Where(h => h.FieldId == field.Id)
                .ToListAsync();

            result.Add(new FieldOperationalReportDto(
                field.Id,
                field.Name,
                field.Status,
                plantings.Count,
                harvests.Count,
                plantings.OrderByDescending(p => p.PlantingDate).FirstOrDefault()?.PlantingDate,
                harvests.OrderByDescending(h => h.HarvestDate).FirstOrDefault()?.HarvestDate
            ));
        }

        return result;
    }
}
