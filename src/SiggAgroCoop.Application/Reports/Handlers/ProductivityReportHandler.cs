using MediatR;
using SiggAgroCoop.Application.Interfaces.Reporting;
using SiggAgroCoop.Application.Reports.DTOs;
using SiggAgroCoop.Application.Reports.Queries;


namespace SiggAgroCoop.Application.Reports.Handlers;

public class ProductivityReportHandler 
    : IRequestHandler<ProductivityReportQuery, IEnumerable<ProductivityReportDto>>
{
    private readonly IReportingDbContext _context;

    public ProductivityReportHandler(IReportingDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<ProductivityReportDto>> Handle(
        ProductivityReportQuery request, 
        CancellationToken cancellationToken)
    {
        var fields = _context.Fields.AsQueryable();

        if (request.FieldId.HasValue)
            fields = fields.Where(f => f.Id == request.FieldId.Value);

        var result = new List<ProductivityReportDto>();

        foreach (var field in fields)
        {
            var plantings = await _context.Plantings
                .Where(p => p.FieldId == field.Id)
                .ToListAsync();

            var harvests = await _context.Harvests
                .Where(h => h.FieldId == field.Id)
                .ToListAsync();

            double totalYieldKg = harvests.Sum(h => h.YieldQuantity);

            double avgYield = field.AreaHectares > 0
                ? totalYieldKg / field.AreaHectares
                : 0;

            result.Add(new ProductivityReportDto(
                field.Id,
                field.Name,
                plantings.Count,
                harvests.Count,
                totalYieldKg,
                avgYield
            ));
        }

        return result;
    }
}
