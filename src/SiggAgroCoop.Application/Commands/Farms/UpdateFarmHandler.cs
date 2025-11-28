using MediatR;
using SiggAgroCoop.Domain.Interfaces;

namespace SiggAgroCoop.Application.Commands.Farms;

public class UpdateFarmHandler : IRequestHandler<UpdateFarmCommand, bool>
{
    private readonly IFarmRepository _farmRepository;

    public UpdateFarmHandler(IFarmRepository farmRepository)
    {
        _farmRepository = farmRepository;
    }

    public async Task<bool> Handle(UpdateFarmCommand request, CancellationToken cancellationToken)
    {
        var farm = await _farmRepository.GetByIdAsync(request.Id);
        if (farm is null)
            return false;

        farm.Name = request.Name;
        farm.Location = request.Location;
        farm.SetUpdatedNow();

        await _farmRepository.UpdateAsync(farm);
        return true;
    }
}
