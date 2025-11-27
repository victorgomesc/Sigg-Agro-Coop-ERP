using MediatR;
using SiggAgroCoop.Application.DTOs.Sectors;
using SiggAgroCoop.Domain.Interfaces;

namespace SiggAgroCoop.Application.Queries.Sectors;

public class GetSectorByIdHandler : IRequestHandler<GetSectorByIdQuery, SectorDto?>
{
    private readonly ISectorRepository _sectorRepository;

    public GetSectorByIdHandler(ISectorRepository sectorRepository)
    {
        _sectorRepository = sectorRepository;
    }

    public async Task<SectorDto?> Handle(GetSectorByIdQuery request, CancellationToken cancellationToken)
    {
        var sector = await _sectorRepository.GetByIdAsync(request.Id);
        if (sector is null)
            return null;

        return new SectorDto(sector.Id, sector.Name, sector.FarmId);
    }
}
