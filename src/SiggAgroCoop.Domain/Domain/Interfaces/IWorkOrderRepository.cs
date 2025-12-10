using SiggAgroCoop.Domain.Entities;
using SiggAgroCoop.Domain.Enums;

namespace SiggAgroCoop.Domain.Interfaces;

public interface IWorkOrderRepository
{
    Task<WorkOrder?> GetByIdAsync(Guid id);
    Task<IEnumerable<WorkOrder>> GetAllAsync();
    Task<IEnumerable<WorkOrder>> GetByEmployeeAsync(Guid employeeId);
    Task<IEnumerable<WorkOrder>> GetByFieldAsync(Guid fieldId);
    Task<IEnumerable<WorkOrder>> GetByStatusAsync(WorkOrderStatus status);

    Task AddAsync(WorkOrder workOrder);
    Task UpdateAsync(WorkOrder workOrder);
    Task DeleteAsync(Guid id);
    IQueryable<WorkOrder> Query();
}
