using MediatR;
using SiggAgroCoop.Application.Reports.DTOs;

namespace SiggAgroCoop.Application.Reports.Queries;

public record EmployeePerformanceReportQuery(Guid? EmployeeId = null)
    : IRequest<IEnumerable<EmployeePerformanceDto>>;
