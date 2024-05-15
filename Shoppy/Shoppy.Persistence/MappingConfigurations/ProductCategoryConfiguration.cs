using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shoppy.Domain.Entities;

namespace Shoppy.Persistence.MappingConfigurations;

public class ProductCategoryConfiguration : IEntityTypeConfiguration<ProductCategory>
{
    public void Configure(EntityTypeBuilder<ProductCategory> builder)
    {
        // builder.ToTable("ProductCategories");

        builder.HasIndex(pc => pc.Name)
            .IsUnique(true);
    }
}