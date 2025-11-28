using MediatR;
using SiggAgroCoop.Domain.Interfaces;

namespace SiggAgroCoop.Application.Commands.Crops;

public class DeleteCropHandler : IRequestHandler<DeleteCropCommand, bool>
{
    private readonly ICropRepository _cropRepository;

    public DeleteCropHandler(ICropRepository cropRepository)
    {
        _cropRepository = cropRepository;
    }

    public async Task<bool> Handle(DeleteCropCommand request, CancellationToken cancellationToken)
    {
        var crop = await _cropRepository.GetByIdAsync(request.Id);
        if (crop is null)
            return false;

        await _cropRepository.DeleteAsync(request.Id);
        return true;
    }
}
