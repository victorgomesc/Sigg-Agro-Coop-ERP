using MediatR;
using SiggAgroCoop.Domain.Entities;
using SiggAgroCoop.Domain.Interfaces;

namespace SiggAgroCoop.Application.Commands.Sectors;

public class CreateSectorHandler : IRequestHandler<CreateSectorCommand, Guid>
{
    private readonly ISectorRepository _sectorRepository;
    private readonly IFarmRepository _farmRepository;

    public CreateSectorHandler(ISectorRepository sectorRepository, IFarmRepository farmRepository)
    {
        _sectorRepository = sectorRepository;
        _farmRepository = farmRepository;
    }

    public async Task<Guid> Handle(CreateSectorCommand request, CancellationToken cancellationToken)
    {
        // Optional: validate if farm exists
        var farm = await _farmRepository.GetByIdAsync(request.FarmId);
        if (farm is null)
            throw new ArgumentException("Farm not found");

        var sector = new Sector
        {
            Name = request.Name,
            FarmId = request.FarmId
        };

        await _sectorRepository.AddAsync(sector);

        return sector.Id;
    }
}
