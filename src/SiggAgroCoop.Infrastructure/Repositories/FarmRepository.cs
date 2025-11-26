using Microsoft.EntityFrameworkCore;
using SiggAgroCoop.Domain.Entities;
using SiggAgroCoop.Domain.Interfaces;
using SiggAgroCoop.Infrastructure.Context;

namespace SiggAgroCoop.Infrastructure.Repositories;

public class FarmRepository : IFarmRepository
{
    private readonly AppDbContext _context;

    public FarmRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Farm farm)
    {
        _context.Farms.Add(farm);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var entity = await _context.Farms.FindAsync(id);
        if (entity != null)
        {
            _context.Farms.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<IEnumerable<Farm>> GetAllAsync()
    {
        return await _context.Farms
            .Include(f => f.Sectors)
            .ToListAsync();
    }

    public async Task<Farm?> GetByIdAsync(Guid id)
    {
        return await _context.Farms
            .Include(f => f.Sectors)
            .FirstOrDefaultAsync(f => f.Id == id);
    }

    public async Task UpdateAsync(Farm farm)
    {
        _context.Farms.Update(farm);
        await _context.SaveChangesAsync();
    }
}
