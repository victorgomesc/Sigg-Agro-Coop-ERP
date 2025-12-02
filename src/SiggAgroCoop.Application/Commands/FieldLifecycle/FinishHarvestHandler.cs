using MediatR;
using SiggAgroCoop.Domain.Enums;
using SiggAgroCoop.Domain.Interfaces;

namespace SiggAgroCoop.Application.Commands.FieldLifecycle;

public class FinishHarvestHandler : IRequestHandler<FinishHarvestCommand, bool>
{
    private readonly IFieldRepository _fieldRepository;

    public FinishHarvestHandler(IFieldRepository fieldRepository)
    {
        _fieldRepository = fieldRepository;
    }

    public async Task<bool> Handle(FinishHarvestCommand request, CancellationToken cancellationToken)
    {
        var field = await _fieldRepository.GetByIdAsync(request.FieldId);
        if (field is null) return false;

        field.Status = FieldStatus.Idle;
        field.SetUpdatedNow();

        await _fieldRepository.UpdateAsync(field);

        return true;
    }
}
