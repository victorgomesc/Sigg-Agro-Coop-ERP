using SiggAgroCoop.Domain.Entities;

namespace SiggAgroCoop.Domain.Interfaces;

public interface IFarmRepository
{
    Task<Farm?> GetByIdAsync(Guid id);
    Task<IEnumerable<Farm>> GetAllAsync();
    Task AddAsync(Farm farm);
    Task UpdateAsync(Farm farm);
    Task DeleteAsync(Guid id);
}
