using SiggAgroCoop.Domain.Entities;

namespace SiggAgroCoop.Domain.Interfaces;

public interface IHarvestRepository
{
    Task AddAsync(Harvest harvest);
    Task<IEnumerable<Harvest>> GetByFieldAsync(Guid fieldId);
}
