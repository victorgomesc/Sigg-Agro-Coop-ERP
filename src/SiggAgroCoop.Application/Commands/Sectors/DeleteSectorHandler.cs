using MediatR;
using SiggAgroCoop.Domain.Interfaces;

namespace SiggAgroCoop.Application.Commands.Sectors;

public class DeleteSectorHandler : IRequestHandler<DeleteSectorCommand, bool>
{
    private readonly ISectorRepository _sectorRepository;

    public DeleteSectorHandler(ISectorRepository sectorRepository)
    {
        _sectorRepository = sectorRepository;
    }

    public async Task<bool> Handle(DeleteSectorCommand request, CancellationToken cancellationToken)
    {
        var sector = await _sectorRepository.GetByIdAsync(request.Id);
        if (sector is null)
            return false;

        await _sectorRepository.DeleteAsync(request.Id);
        return true;
    }
}
