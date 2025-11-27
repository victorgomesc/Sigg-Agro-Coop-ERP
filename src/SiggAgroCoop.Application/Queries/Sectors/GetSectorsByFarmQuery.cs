using MediatR;
using SiggAgroCoop.Application.DTOs.Sectors;

namespace SiggAgroCoop.Application.Queries.Sectors;

public record GetSectorsByFarmQuery(Guid FarmId) : IRequest<IEnumerable<SectorDto>>;
