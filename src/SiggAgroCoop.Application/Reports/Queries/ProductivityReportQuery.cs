using MediatR;
using SiggAgroCoop.Application.Reports.DTOs;

namespace SiggAgroCoop.Application.Reports.Queries;

public record ProductivityReportQuery(Guid? FieldId = null) 
    : IRequest<IEnumerable<ProductivityReportDto>>;
