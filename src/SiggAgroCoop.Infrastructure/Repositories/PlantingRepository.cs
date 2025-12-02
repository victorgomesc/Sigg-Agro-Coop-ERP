using SiggAgroCoop.Domain.Entities;
using SiggAgroCoop.Domain.Interfaces;
using SiggAgroCoop.Infrastructure.Context;

namespace SiggAgroCoop.Infrastructure.Repositories;

public class PlantingRepository : IPlantingRepository
{
    private readonly AppDbContext _context;

    public PlantingRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Planting planting)
    {
        _context.Plantings.Add(planting);
        await _context.SaveChangesAsync();
    }
}
