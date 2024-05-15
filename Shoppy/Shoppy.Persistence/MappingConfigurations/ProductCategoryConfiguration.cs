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
        
        //Seeding
        builder.HasData(
            new ProductCategory()
            {
                Id = new Guid("2baf4c50-c927-4b54-971e-3ff5f300e147"),
                CreatedDateTime = DateTime.UtcNow,
                UpdatedDateTime = DateTime.UtcNow,
                Name = "Romance"
            },
            new ProductCategory()
            {
                Id = new Guid("99ada3c1-eea5-4431-a529-b3114de224da"),
                CreatedDateTime = DateTime.UtcNow,
                UpdatedDateTime = DateTime.UtcNow,
                Name = "Economic"
            },
            new ProductCategory()
            {
                Id = new Guid("adf36edc-3e08-4a36-8e20-0d79747f0962"),
                CreatedDateTime = DateTime.UtcNow,
                UpdatedDateTime = DateTime.UtcNow,
                Name = "Business and Money"
            },
            new ProductCategory()
            {
                Id = new Guid("292c90a5-1a0a-45a4-8f3d-37f09b09b422"),
                CreatedDateTime = DateTime.UtcNow,
                UpdatedDateTime = DateTime.UtcNow,
                Name = "History"
            },
            new ProductCategory()
            {
                Id = new Guid("97cf6bd7-7290-449a-a61d-5ea2fdfcf8de"),
                CreatedDateTime = DateTime.UtcNow,
                UpdatedDateTime = DateTime.UtcNow,
                Name = "Education and Teacher"
            }
        );
    }
}