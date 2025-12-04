using SiggAgroCoop.Domain.Entities;

namespace SiggAgroCoop.Domain.Interfaces;

public interface IPlantingRepository
{
    Task AddAsync(Planting planting);
    Task<IEnumerable<Planting>> GetByFieldAsync(Guid fieldId);
}
