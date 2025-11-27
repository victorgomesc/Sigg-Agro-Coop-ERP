using MediatR;
using SiggAgroCoop.Application.DTOs.Fields;

namespace SiggAgroCoop.Application.Queries.Fields;

public record GetFieldByIdQuery(Guid Id) : IRequest<FieldDto?>;
