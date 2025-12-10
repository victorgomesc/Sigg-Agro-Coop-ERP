using Microsoft.EntityFrameworkCore;
using SiggAgroCoop.Domain.Entities;


namespace SiggAgroCoop.Infrastructure.Context;

public class AppDbContext : DbContext
{
    public DbSet<Farm> Farms { get; set; } = default!;
    public DbSet<Sector> Sectors { get; set; } = default!;
    public DbSet<Field> Fields { get; set; } = default!;
    public DbSet<Crop> Crops { get; set; } = default!;
    public DbSet<Planting> Plantings { get; set; } = default!;
    public DbSet<Harvest> Harvests { get; set; } = default!;
    public DbSet<Employee> Employees { get; set; } = default!;
    public DbSet<Tool> Tools { get; set; } = default!;
    public DbSet<WorkOrder> WorkOrders { get; set; } = default!;
    public DbSet<WorkOrderTool> WorkOrderTools { get; set; } = default!;



    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Field -> Sector
        modelBuilder.Entity<Field>()
            .HasOne(f => f.Sector)
            .WithMany(s => s.Fields)
            .HasForeignKey(f => f.SectorId);

        // Field -> Plantings (1:N)
        modelBuilder.Entity<Planting>()
            .HasOne(p => p.Field)
            .WithMany(f => f.Plantings)
            .HasForeignKey(p => p.FieldId);

        // Field -> Harvests (1:N)
        modelBuilder.Entity<Harvest>()
            .HasOne(h => h.Field)
            .WithMany(f => f.Harvests)
            .HasForeignKey(h => h.FieldId);

        // Crop -> Plantings (1:N)
        modelBuilder.Entity<Planting>()
            .HasOne(p => p.Crop)
            .WithMany(c => c.Plantings)
            .HasForeignKey(p => p.CropId);

        // Crop -> Harvests (1:N)
        modelBuilder.Entity<Harvest>()
            .HasOne(h => h.Crop)
            .WithMany(c => c.Harvests)
            .HasForeignKey(h => h.CropId);

        modelBuilder.Entity<Tool>()
            .HasOne(t => t.Employee)
            .WithMany(e => e.Tools)
            .HasForeignKey(t => t.EmployeeId);
        
        modelBuilder.Entity<WorkOrderTool>()
            .HasKey(wt => new { wt.WorkOrderId, wt.ToolId });

        modelBuilder.Entity<WorkOrderTool>()
            .HasOne(wt => wt.WorkOrder)
            .WithMany(w => w.Tools)
            .HasForeignKey(wt => wt.WorkOrderId);

        modelBuilder.Entity<WorkOrderTool>()
            .HasOne(wt => wt.Tool)
            .WithMany()
            .HasForeignKey(wt => wt.ToolId);


    }
}
