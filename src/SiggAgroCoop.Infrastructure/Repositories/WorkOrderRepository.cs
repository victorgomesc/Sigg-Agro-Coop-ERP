using Microsoft.EntityFrameworkCore;
using SiggAgroCoop.Domain.Entities;
using SiggAgroCoop.Domain.Enums;
using SiggAgroCoop.Domain.Interfaces;
using SiggAgroCoop.Infrastructure.Context;

namespace SiggAgroCoop.Infrastructure.Repositories;

public class WorkOrderRepository : IWorkOrderRepository
{
    private readonly AppDbContext _context;

    public WorkOrderRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(WorkOrder workOrder)
    {
        _context.WorkOrders.Add(workOrder);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var w = await _context.WorkOrders.FindAsync(id);
        if (w != null)
        {
            _context.WorkOrders.Remove(w);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<IEnumerable<WorkOrder>> GetAllAsync()
    {
        return await _context.WorkOrders
            .Include(w => w.Employee)
            .Include(w => w.Tools).ThenInclude(t => t.Tool)
            .Include(w => w.Field)
            .ToListAsync();
    }

    public async Task<WorkOrder?> GetByIdAsync(Guid id)
    {
        return await _context.WorkOrders
            .Include(w => w.Employee)
            .Include(w => w.Tools).ThenInclude(t => t.Tool)
            .Include(w => w.Field)
            .FirstOrDefaultAsync(w => w.Id == id);
    }

    public async Task<IEnumerable<WorkOrder>> GetByEmployeeAsync(Guid employeeId)
    {
        return await _context.WorkOrders
            .Where(w => w.EmployeeId == employeeId)
            .Include(w => w.Tools).ThenInclude(t => t.Tool)
            .ToListAsync();
    }

    public async Task<IEnumerable<WorkOrder>> GetByFieldAsync(Guid fieldId)
    {
        return await _context.WorkOrders
            .Where(w => w.FieldId == fieldId)
            .ToListAsync();
    }

    public async Task<IEnumerable<WorkOrder>> GetByStatusAsync(WorkOrderStatus status)
    {
        return await _context.WorkOrders
            .Where(w => w.Status == status)
            .ToListAsync();
    }

    public async Task UpdateAsync(WorkOrder workOrder)
    {
        _context.WorkOrders.Update(workOrder);
        await _context.SaveChangesAsync();
    }
}
