using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shoppy.Domain.Entities;

namespace Shoppy.Persistence.MappingConfigurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        // builder.ToTable("Products");
        builder.HasIndex(p => p.Sku)
            .IsUnique(true);

        builder.HasIndex(p => p.Name);

        builder.Property(p => p.Price)
            .HasPrecision(12, 2);

        builder.Property(p => p.AvgRate)
            .HasPrecision(2, 1);
    }
}