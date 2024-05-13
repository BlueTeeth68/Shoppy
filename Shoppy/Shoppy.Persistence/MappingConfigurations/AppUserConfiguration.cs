using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shoppy.Domain.Entities;
using Shoppy.Persistence.Identity;

namespace Shoppy.Persistence.MappingConfigurations;

public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
{
    public void Configure(EntityTypeBuilder<AppUser> builder)
    {
        builder.ToTable("AspNetUsers");

        builder.HasMany<Address>()
            .WithOne()
            .HasForeignKey(a => a.UserId);

        builder.HasOne<Cart>(u => u.Cart)
            .WithOne();

        builder.HasMany<ProductRating>()
            .WithOne()
            .HasForeignKey(pr => pr.UserId);

        builder.HasMany<Order>()
            .WithOne()
            .HasForeignKey(o => o.UserId);
    }
}