using MediatR;
using SiggAgroCoop.Application.DTOs.Fields;
using SiggAgroCoop.Domain.Interfaces;

namespace SiggAgroCoop.Application.Queries.Fields;

public class GetFieldByIdHandler : IRequestHandler<GetFieldByIdQuery, FieldDto?>
{
    private readonly IFieldRepository _fieldRepository;

    public GetFieldByIdHandler(IFieldRepository fieldRepository)
    {
        _fieldRepository = fieldRepository;
    }

    public async Task<FieldDto?> Handle(GetFieldByIdQuery request, CancellationToken cancellationToken)
    {
        var field = await _fieldRepository.GetByIdAsync(request.Id);
        if (field is null)
            return null;

        return new FieldDto(field.Id, field.Name, field.AreaInHectares, field.SectorId);
    }
}
