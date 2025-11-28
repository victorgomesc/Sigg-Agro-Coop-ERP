using MediatR;
using SiggAgroCoop.Domain.Interfaces;

namespace SiggAgroCoop.Application.Commands.Farms;

public class DeleteFarmHandler(IFarmRepository farmRepository) 
    : IRequestHandler<DeleteFarmCommand, bool>
{
    private readonly IFarmRepository _farmRepository = farmRepository;

    public async Task<bool> Handle(DeleteFarmCommand request, CancellationToken cancellationToken)
    {
        var farm = await _farmRepository.GetByIdAsync(request.Id);
        if (farm is null)
            return false;

        await _farmRepository.DeleteAsync(request.Id);
        return true;
    }
}
