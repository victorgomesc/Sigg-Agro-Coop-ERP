using SiggAgroCoop.Domain.Entities;

namespace SiggAgroCoop.Domain.Interfaces;

public interface ICropRepository
{
    Task<Crop?> GetByIdAsync(Guid id);
    Task<IEnumerable<Crop>> GetAllByFarmAsync(Guid farmId);
    Task AddAsync(Crop crop);
    Task UpdateAsync(Crop crop);
    Task DeleteAsync(Guid id);
}
