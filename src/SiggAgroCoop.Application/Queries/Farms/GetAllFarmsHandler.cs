using MediatR;
using SiggAgroCoop.Application.DTOs.Farms;
using SiggAgroCoop.Domain.Interfaces;

namespace SiggAgroCoop.Application.Queries.Farms;

public class GetAllFarmsHandler : IRequestHandler<GetAllFarmsQuery, IEnumerable<FarmDto>>
{
    private readonly IFarmRepository _farmRepo;

    public GetAllFarmsHandler(IFarmRepository farmRepo)
    {
        _farmRepo = farmRepo;
    }

    public async Task<IEnumerable<FarmDto>> Handle(GetAllFarmsQuery request, CancellationToken cancellationToken)
    {
        var farms = await _farmRepo.GetAllAsync();
        return farms.Select(f => new FarmDto(f.Id, f.Name, f.Location));
    }
}
