using MediatR;
using SiggAgroCoop.Application.Reports.DTOs;

namespace SiggAgroCoop.Application.Reports.Queries;

public record ToolUsageReportQuery() : IRequest<IEnumerable<ToolUsageReportDto>>;
