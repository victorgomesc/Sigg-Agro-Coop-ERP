using MediatR;
using SiggAgroCoop.Application.DTOs.Sectors;
using SiggAgroCoop.Domain.Interfaces;

namespace SiggAgroCoop.Application.Queries.Sectors;

public class GetSectorsByFarmHandler : IRequestHandler<GetSectorsByFarmQuery, IEnumerable<SectorDto>>
{
    private readonly ISectorRepository _sectorRepository;

    public GetSectorsByFarmHandler(ISectorRepository sectorRepository)
    {
        _sectorRepository = sectorRepository;
    }

    public async Task<IEnumerable<SectorDto>> Handle(GetSectorsByFarmQuery request, CancellationToken cancellationToken)
    {
        var sectors = await _sectorRepository.GetAllByFarmAsync(request.FarmId);

        return sectors.Select(s => new SectorDto(s.Id, s.Name, s.FarmId));
    }
}
