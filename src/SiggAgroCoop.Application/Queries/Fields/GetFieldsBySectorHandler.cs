using MediatR;
using SiggAgroCoop.Application.DTOs.Fields;
using SiggAgroCoop.Domain.Interfaces;

namespace SiggAgroCoop.Application.Queries.Fields;

public class GetFieldsBySectorHandler : IRequestHandler<GetFieldsBySectorQuery, IEnumerable<FieldDto>>
{
    private readonly IFieldRepository _fieldRepository;

    public GetFieldsBySectorHandler(IFieldRepository fieldRepository)
    {
        _fieldRepository = fieldRepository;
    }

    public async Task<IEnumerable<FieldDto>> Handle(GetFieldsBySectorQuery request, CancellationToken cancellationToken)
    {
        var fields = await _fieldRepository.GetAllBySectorAsync(request.SectorId);

        return fields.Select(f => new FieldDto(f.Id, f.Name, f.AreaInHectares, f.SectorId));
    }
}
