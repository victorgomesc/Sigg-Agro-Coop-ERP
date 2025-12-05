using Microsoft.EntityFrameworkCore;
using SiggAgroCoop.Domain.Entities;
using SiggAgroCoop.Domain.Interfaces;
using SiggAgroCoop.Infrastructure.Context;

namespace SiggAgroCoop.Infrastructure.Repositories;

public class ToolRepository : IToolRepository
{
    private readonly AppDbContext _context;

    public ToolRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Tool tool)
    {
        _context.Tools.Add(tool);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var tool = await _context.Tools.FindAsync(id);
        if (tool != null)
        {
            _context.Tools.Remove(tool);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<IEnumerable<Tool>> GetAllAsync()
    {
        return await _context.Tools
            .Include(t => t.Employee)
            .ToListAsync();
    }

    public async Task<Tool?> GetByIdAsync(Guid id)
    {
        return await _context.Tools
            .Include(t => t.Employee)
            .FirstOrDefaultAsync(t => t.Id == id);
    }

    public async Task<IEnumerable<Tool>> GetByEmployeeAsync(Guid employeeId)
    {
        return await _context.Tools
            .Where(t => t.EmployeeId == employeeId)
            .Include(t => t.Employee)
            .ToListAsync();
    }

    public async Task UpdateAsync(Tool tool)
    {
        _context.Tools.Update(tool);
        await _context.SaveChangesAsync();
    }
}
