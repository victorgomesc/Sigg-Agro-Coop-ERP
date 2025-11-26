using Microsoft.EntityFrameworkCore;
using SiggAgroCoop.Domain.Entities;
using SiggAgroCoop.Domain.Interfaces;
using SiggAgroCoop.Infrastructure.Context;

namespace SiggAgroCoop.Infrastructure.Repositories;

public class SectorRepository : ISectorRepository
{
    private readonly AppDbContext _context;

    public SectorRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Sector sector)
    {
        _context.Sectors.Add(sector);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var entity = await _context.Sectors.FindAsync(id);
        if (entity != null)
        {
            _context.Sectors.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<IEnumerable<Sector>> GetAllByFarmAsync(Guid farmId)
    {
        return await _context.Sectors
            .Where(s => s.FarmId == farmId)
            .Include(s => s.Fields)
            .ToListAsync();
    }

    public async Task<Sector?> GetByIdAsync(Guid id)
    {
        return await _context.Sectors
            .Include(s => s.Fields)
            .FirstOrDefaultAsync(s => s.Id == id);
    }

    public async Task UpdateAsync(Sector sector)
    {
        _context.Sectors.Update(sector);
        await _context.SaveChangesAsync();
    }
}
