using MediatR;
using SiggAgroCoop.Application.Reports.DTOs;

namespace SiggAgroCoop.Application.Reports.Queries;

public record FieldOperationalReportQuery() 
    : IRequest<IEnumerable<FieldOperationalReportDto>>;
