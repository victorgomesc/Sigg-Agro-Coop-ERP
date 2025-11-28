using Microsoft.EntityFrameworkCore;
using SiggAgroCoop.Domain.Entities;
using SiggAgroCoop.Domain.Interfaces;
using SiggAgroCoop.Infrastructure.Context;

namespace SiggAgroCoop.Infrastructure.Repositories;

public class CropRepository : ICropRepository
{
    private readonly AppDbContext _context;

    public CropRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Crop crop)
    {
        _context.Crops.Add(crop);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var entity = await _context.Crops.FindAsync(id);
        if (entity != null)
        {
            _context.Crops.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<IEnumerable<Crop>> GetAllByFarmAsync(Guid farmId)
    {
        return await _context.Crops
            .Where(c => c.FarmId == farmId)
            .ToListAsync();
    }

    public async Task<Crop?> GetByIdAsync(Guid id)
    {
        return await _context.Crops
            .FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task UpdateAsync(Crop crop)
    {
        _context.Crops.Update(crop);
        await _context.SaveChangesAsync();
    }
}
