using MediatR;
using SiggAgroCoop.Domain.Interfaces;

namespace SiggAgroCoop.Application.Commands.Fields;

public class UpdateFieldHandler(IFieldRepository fieldRepository, ISectorRepository sectorRepository) : IRequestHandler<UpdateFieldCommand, bool>
{
    private readonly IFieldRepository _fieldRepository = fieldRepository;
    private readonly ISectorRepository _sectorRepository = sectorRepository;

    public async Task<bool> Handle(UpdateFieldCommand request, CancellationToken cancellationToken)
    {
        var field = await _fieldRepository.GetByIdAsync(request.Id);
        if (field is null)
            return false;

        // Validate sector exists
        var sector = await _sectorRepository.GetByIdAsync(request.SectorId);
        if (sector is null)
            return false;

        field.Name = request.Name;
        field.AreaInHectares = request.AreaInHectares;
        field.SectorId = request.SectorId;
        field.SetUpdatedNow();

        await _fieldRepository.UpdateAsync(field);
        return true;
    }
}
