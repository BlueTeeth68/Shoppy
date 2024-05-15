using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Shoppy.Persistence.MappingConfigurations;

public class UserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<Guid>>
{
    public void Configure(EntityTypeBuilder<IdentityUserRole<Guid>> builder)
    {
        
        //seed data
        var userRoles = new List<IdentityUserRole<Guid>>()
        {
            new IdentityUserRole<Guid>()
            {
                RoleId = new Guid("5fc71af5-0216-402b-a5cb-ba17701e2fa3"),
                UserId = new Guid("85d8a27f-9d32-4269-b5d0-844589d498d0"),
            },

            new IdentityUserRole<Guid>()
            {
                RoleId = new Guid("8bbf66a4-da08-4b87-bdb2-1502e38562f3"),
                UserId = new Guid("021657c8-d4d0-4167-a1a6-b7bb840f33bf"),
            },

            new IdentityUserRole<Guid>()
            {
                RoleId = new Guid("8bbf66a4-da08-4b87-bdb2-1502e38562f3"),
                UserId = new Guid("2c96fabb-f759-43ef-9a31-328c25d2eff5"),
            },
            new IdentityUserRole<Guid>()
            {
                RoleId = new Guid("8bbf66a4-da08-4b87-bdb2-1502e38562f3"),
                UserId = new Guid("30a4345d-df2e-46ab-8c0e-d38a7933b591"),
            },
            new IdentityUserRole<Guid>()
            {
                RoleId = new Guid("8bbf66a4-da08-4b87-bdb2-1502e38562f3"),
                UserId = new Guid("594f8fe1-1cf1-4f5a-a8ae-6b9509fbf283"),
            },
        };

        builder.HasData(userRoles);
    }
}