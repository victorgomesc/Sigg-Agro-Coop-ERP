using SiggAgroCoop.Domain.Entities;

namespace SiggAgroCoop.Domain.Interfaces;

public interface ISectorRepository
{
    Task<Sector?> GetByIdAsync(Guid id);
    Task<IEnumerable<Sector>> GetAllByFarmAsync(Guid farmId);
    Task AddAsync(Sector sector);
    Task UpdateAsync(Sector sector);
    Task DeleteAsync(Guid id);
}
