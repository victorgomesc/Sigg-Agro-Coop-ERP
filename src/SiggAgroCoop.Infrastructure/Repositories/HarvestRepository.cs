using SiggAgroCoop.Domain.Entities;
using SiggAgroCoop.Domain.Interfaces;
using SiggAgroCoop.Infrastructure.Context;

namespace SiggAgroCoop.Infrastructure.Repositories;

public class HarvestRepository : IHarvestRepository
{
    private readonly AppDbContext _context;

    public HarvestRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Harvest harvest)
    {
        _context.Harvests.Add(harvest);
        await _context.SaveChangesAsync();
    }
}
