using MediatR;
using SiggAgroCoop.Application.DTOs.Sectors;

namespace SiggAgroCoop.Application.Queries.Sectors;

public record GetSectorByIdQuery(Guid Id) : IRequest<SectorDto?>;
