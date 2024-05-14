using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shoppy.Domain.Constants;

namespace Shoppy.Persistence.MappingConfigurations;

public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole<Guid>>
{
    public void Configure(EntityTypeBuilder<IdentityRole<Guid>> builder)
    {
        builder.ToTable("AspNetRoles");
        builder.HasData(
            new IdentityRole<Guid>
            {
                Id = new Guid("8bbf66a4-da08-4b87-bdb2-1502e38562f3"),
                Name = RoleConstant.UserRole,
                NormalizedName = RoleConstant.UserRole.ToUpper()
            },
            new IdentityRole<Guid>
            {
                Id = new Guid("5fc71af5-0216-402b-a5cb-ba17701e2fa3"),
                Name = RoleConstant.AdminRole,
                NormalizedName = RoleConstant.AdminRole.ToUpper()
            });
    }
}