using SiggAgroCoop.Domain.Entities;

namespace SiggAgroCoop.Domain.Interfaces;

public interface IFieldRepository
{
    Task<Field?> GetByIdAsync(Guid id);
    Task<IEnumerable<Field>> GetAllBySectorAsync(Guid sectorId);
    Task AddAsync(Field field);
    Task UpdateAsync(Field field);
    Task DeleteAsync(Guid id);
}
