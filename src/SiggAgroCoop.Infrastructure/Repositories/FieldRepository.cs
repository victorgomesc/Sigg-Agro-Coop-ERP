using Microsoft.EntityFrameworkCore;
using SiggAgroCoop.Domain.Entities;
using SiggAgroCoop.Domain.Interfaces;
using SiggAgroCoop.Infrastructure.Context;

namespace SiggAgroCoop.Infrastructure.Repositories;

public class FieldRepository : IFieldRepository
{
    private readonly AppDbContext _context;

    public FieldRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Field field)
    {
        _context.Fields.Add(field);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var entity = await _context.Fields.FindAsync(id);
        if (entity != null)
        {
            _context.Fields.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<IEnumerable<Field>> GetAllBySectorAsync(Guid sectorId)
    {
        return await _context.Fields
            .Where(f => f.SectorId == sectorId)
            .ToListAsync();
    }

    public async Task<Field?> GetByIdAsync(Guid id)
    {
        return await _context.Fields
            .FirstOrDefaultAsync(f => f.Id == id);
    }

    public async Task UpdateAsync(Field field)
    {
        _context.Fields.Update(field);
        await _context.SaveChangesAsync();
    }
}
