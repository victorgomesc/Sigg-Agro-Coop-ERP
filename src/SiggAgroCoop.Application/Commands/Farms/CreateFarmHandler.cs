using MediatR;
using SiggAgroCoop.Domain.Entities;
using SiggAgroCoop.Domain.Interfaces;

namespace SiggAgroCoop.Application.Commands.Farms;

public class CreateFarmHandler : IRequestHandler<CreateFarmCommand, Guid>
{
    private readonly IFarmRepository _farmRepo;

    public CreateFarmHandler(IFarmRepository farmRepo)
    {
        _farmRepo = farmRepo;
    }

    public async Task<Guid> Handle(CreateFarmCommand request, CancellationToken cancellationToken)
    {
        var farm = new Farm
        {
            Name = request.Name,
            Location = request.Location
        };

        await _farmRepo.AddAsync(farm);

        return farm.Id;
    }
}
