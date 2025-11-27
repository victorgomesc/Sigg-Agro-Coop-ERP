using MediatR;
using SiggAgroCoop.Domain.Entities;
using SiggAgroCoop.Domain.Interfaces;

namespace SiggAgroCoop.Application.Commands.Fields;

public class CreateFieldHandler : IRequestHandler<CreateFieldCommand, Guid>
{
    private readonly IFieldRepository _fieldRepository;
    private readonly ISectorRepository _sectorRepository;

    public CreateFieldHandler(IFieldRepository fieldRepository, ISectorRepository sectorRepository)
    {
        _fieldRepository = fieldRepository;
        _sectorRepository = sectorRepository;
    }

    public async Task<Guid> Handle(CreateFieldCommand request, CancellationToken cancellationToken)
    {
        // Optional: validate if sector exists
        var sector = await _sectorRepository.GetByIdAsync(request.SectorId);
        if (sector is null)
            throw new ArgumentException("Sector not found");

        var field = new Field
        {
            Name = request.Name,
            AreaInHectares = request.AreaInHectares,
            SectorId = request.SectorId
        };

        await _fieldRepository.AddAsync(field);

        return field.Id;
    }
}
