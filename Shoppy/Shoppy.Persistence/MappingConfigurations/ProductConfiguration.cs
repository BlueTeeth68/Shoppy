using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shoppy.Domain.Constants.Enums;
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

        builder.HasMany(p => p.Images)
            .WithOne()
            .HasForeignKey(i => i.ProductId);

        #endregion

        #region Create index

        builder.HasIndex(p => new {p.IsDelete, p.Name});

        #endregion

        builder.HasQueryFilter(p => !p.IsDelete);

        #region Data Seeding

        var products = new List<Product>()
        {
            new Product()
            {
                Id = new Guid("9243d741-a350-4067-bb29-395e9becf57e"),
                Name = "Economix",
                CreatedDateTime = DateTime.UtcNow,
                Price = 10,
                Quantity = 1000,
                NumberOfPage = 310,
                Status = ProductStatus.Active,
                ProductThumbUrl =
                    "https://bizweb.dktcdn.net/thumb/1024x1024/100/363/455/products/economix01.jpg?v=1705552583773",
                AuthorName = "Michael Goodwin",
                CategoryId = new Guid("99ada3c1-eea5-4431-a529-b3114de224da")
            },
            new Product()
            {
                Id = new Guid("e21f3a87-20d5-420e-ba33-9108df996747"),
                Name = "Outliers",
                CreatedDateTime = DateTime.UtcNow,
                Price = 10,
                Quantity = 1000,
                NumberOfPage = 416,
                Status = ProductStatus.Active,
                ProductThumbUrl =
                    "https://bizweb.dktcdn.net/thumb/large/100/197/269/products/nhung-ke-xuat-chung.jpg?v=1526893051653",
                AuthorName = "Malcolm Gladwell",
                CategoryId = new Guid("99ada3c1-eea5-4431-a529-b3114de224da")
            }
        };

        builder.HasData(products);

        #endregion
    }
}