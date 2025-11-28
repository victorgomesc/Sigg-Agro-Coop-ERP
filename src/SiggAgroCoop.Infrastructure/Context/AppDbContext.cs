using Microsoft.EntityFrameworkCore;
using SiggAgroCoop.Domain.Entities;

namespace SiggAgroCoop.Infrastructure.Context;

public class AppDbContext : DbContext
{
    public DbSet<Farm> Farms { get; set; } = default!;
    public DbSet<Sector> Sectors { get; set; } = default!;
    public DbSet<Field> Fields { get; set; } = default!;
    public DbSet<Crop> Crops { get; set; } = default!;

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Example: relationships
        modelBuilder.Entity<Sector>()
            .HasOne(s => s.Farm)
            .WithMany(f => f.Sectors)
            .HasForeignKey(s => s.FarmId);

        modelBuilder.Entity<Field>()
            .HasOne(f => f.Sector)
            .WithMany(s => s.Fields)
            .HasForeignKey(f => f.SectorId);

        modelBuilder.Entity<Crop>()
            .HasOne(c => c.Farm)
            .WithMany(f => f.Crops)
            .HasForeignKey(c => c.FarmId);
    }
}
