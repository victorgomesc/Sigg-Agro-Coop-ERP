using SiggAgroCoop.Domain.Entities;

namespace SiggAgroCoop.Domain.Interfaces;

public interface IToolRepository
{
    Task<Tool?> GetByIdAsync(Guid id);
    Task<IEnumerable<Tool>> GetAllAsync();
    Task<IEnumerable<Tool>> GetByEmployeeAsync(Guid employeeId);
    Task AddAsync(Tool tool);
    Task UpdateAsync(Tool tool);
    Task DeleteAsync(Guid id);
}
