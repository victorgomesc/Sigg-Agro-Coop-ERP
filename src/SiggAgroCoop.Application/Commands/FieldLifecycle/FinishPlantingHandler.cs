using MediatR;
using SiggAgroCoop.Domain.Enums;
using SiggAgroCoop.Domain.Interfaces;

namespace SiggAgroCoop.Application.Commands.FieldLifecycle;

public class FinishPlantingHandler : IRequestHandler<FinishPlantingCommand, bool>
{
    private readonly IFieldRepository _fieldRepository;

    public FinishPlantingHandler(IFieldRepository fieldRepository)
    {
        _fieldRepository = fieldRepository;
    }

    public async Task<bool> Handle(FinishPlantingCommand request, CancellationToken cancellationToken)
    {
        var field = await _fieldRepository.GetByIdAsync(request.FieldId);
        if (field is null) return false;

        field.Status = FieldStatus.Growing;
        field.SetUpdatedNow();

        await _fieldRepository.UpdateAsync(field);

        return true;
    }
}
