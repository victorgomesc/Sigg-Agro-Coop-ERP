using MediatR;
using SiggAgroCoop.Application.DTOs.Fields;

namespace SiggAgroCoop.Application.Queries.Fields;

public record GetFieldsBySectorQuery(Guid SectorId) : IRequest<IEnumerable<FieldDto>>;
