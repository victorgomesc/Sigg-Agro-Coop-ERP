using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SiggAgroCoop.Domain.Entities;

namespace SiggAgroCoop.Infrastructure.Configurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Products");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(x => x.CurrentStock)
            .HasColumnType("decimal(18,2)");

        builder.HasOne(x => x.Category)
            .WithMany(c => c.Products)
            .HasForeignKey(x => x.CategoryId);

        builder.HasOne(x => x.UnitOfMeasure)
            .WithMany(u => u.Products)
            .HasForeignKey(x => x.UnitOfMeasureId);

        builder.HasOne(x => x.DefaultSupplier)
            .WithMany(s => s.Products)
            .HasForeignKey(x => x.DefaultSupplierId)
            .OnDelete(DeleteBehavior.SetNull);
    }
}
