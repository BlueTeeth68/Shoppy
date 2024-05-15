using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shoppy.Domain.Entities;

namespace Shoppy.Persistence.MappingConfigurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        // builder.ToTable("Products");
        
        #region Relation mapping

        builder.Property(p => p.Price)
            .HasPrecision(12, 2);

        builder.Property(p => p.AvgRate)
            .HasPrecision(2, 1);

        #endregion

        #region Create index

        builder.HasIndex(p => p.Sku)
            .IsUnique(true);

        builder.HasIndex(p => p.IsDelete);

        builder.HasIndex(p => p.Name);

        #endregion
        
        builder.HasQueryFilter(p => p.IsDelete);
    }
}