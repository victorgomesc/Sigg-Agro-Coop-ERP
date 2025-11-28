using MediatR;
using SiggAgroCoop.Domain.Interfaces;

namespace SiggAgroCoop.Application.Commands.Sectors;

public class UpdateSectorHandler : IRequestHandler<UpdateSectorCommand, bool>
{
    private readonly ISectorRepository _sectorRepository;
    private readonly IFarmRepository _farmRepository;

    public UpdateSectorHandler(ISectorRepository sectorRepository, IFarmRepository farmRepository)
    {
        _sectorRepository = sectorRepository;
        _farmRepository = farmRepository;
    }

    public async Task<bool> Handle(UpdateSectorCommand request, CancellationToken cancellationToken)
    {
        var sector = await _sectorRepository.GetByIdAsync(request.Id);
        if (sector is null)
            return false;

        // Validate Farm exists
        var farm = await _farmRepository.GetByIdAsync(request.FarmId);
        if (farm is null)
            return false;

        sector.Name = request.Name;
        sector.FarmId = request.FarmId;
        sector.SetUpdatedNow();

        await _sectorRepository.UpdateAsync(sector);
        return true;
    }
}
