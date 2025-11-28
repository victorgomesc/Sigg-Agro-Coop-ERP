using MediatR;
using SiggAgroCoop.Domain.Interfaces;

namespace SiggAgroCoop.Application.Commands.Fields;

public class DeleteFieldHandler(IFieldRepository fieldRepository) : IRequestHandler<DeleteFieldCommand, bool>
{
    private readonly IFieldRepository _fieldRepository = fieldRepository;

    public async Task<bool> Handle(DeleteFieldCommand request, CancellationToken cancellationToken)
    {
        var field = await _fieldRepository.GetByIdAsync(request.Id);
        if (field is null)
            return false;

        await _fieldRepository.DeleteAsync(request.Id);
        return true;
    }
}
