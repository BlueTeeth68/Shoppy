using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shoppy.Domain.Constants.Enums;
using Shoppy.Domain.Entities;
using Shoppy.Persistence.Identity;

namespace Shoppy.Persistence.MappingConfigurations;

public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
{
    private const string DefaultUserPassword = "User@123456";
    private const string DefaultAdminPassword = "Admin@123456";

    public void Configure(EntityTypeBuilder<AppUser> builder)
    {
        // builder.ToTable("AspNetUsers");

        #region relation mapping

        builder.HasMany<Address>()
            .WithOne()
            .HasForeignKey(a => a.UserId);

        builder.HasOne<Cart>(u => u.Cart)
            .WithOne()
            .IsRequired(false);

        builder.HasMany<ProductRating>()
            .WithOne()
            .HasForeignKey(pr => pr.UserId);

        builder.HasMany<Order>()
            .WithOne()
            .HasForeignKey(o => o.UserId);

        #endregion

        #region define index

        builder.HasIndex(u => u.FullName);
        builder.HasIndex(u => u.Gender);
        builder.HasIndex(u => u.Email);
        builder.HasIndex(u => new { u.IsDelete, u.NormalizedEmail });

        #endregion

        builder.HasQueryFilter(u => !u.IsDelete);

        #region Data seeding

        //Data seeding
        var passwordHasher = new PasswordHasher<AppUser>();

        var users = new List<AppUser>()
        {
            CreateSeedUser("85d8a27f-9d32-4269-b5d0-844589d498d0",
                "admin@gmail.com",
                "John Doe",
                "https://avatarfiles.alphacoders.com/151/thumb-151233.jpg",
                Gender.Male,
                DefaultAdminPassword,
                passwordHasher),

            CreateSeedUser("021657c8-d4d0-4167-a1a6-b7bb840f33bf",
                "user1@gmail.com",
                "Jane Smith",
                "https://avatarfiles.alphacoders.com/151/thumb-151233.jpg",
                Gender.Male,
                DefaultUserPassword,
                passwordHasher),

            CreateSeedUser("2c96fabb-f759-43ef-9a31-328c25d2eff5",
                "user2@gmail.com",
                "Michael Johnson",
                "https://avatarfiles.alphacoders.com/151/thumb-151233.jpg",
                Gender.Female,
                DefaultUserPassword,
                passwordHasher),

            CreateSeedUser("30a4345d-df2e-46ab-8c0e-d38a7933b591",
                "user3@gmail.com",
                "Emily Davis",
                "https://avatarfiles.alphacoders.com/151/thumb-151233.jpg",
                Gender.Female,
                DefaultUserPassword,
                passwordHasher),

            CreateSeedUser("594f8fe1-1cf1-4f5a-a8ae-6b9509fbf283",
                "user4@gmail.com",
                "David Lee",
                "https://avatarfiles.alphacoders.com/151/thumb-151233.jpg",
                Gender.Male,
                DefaultUserPassword,
                passwordHasher),
        };

        builder.HasData(users);

        #endregion
    }

    private static AppUser CreateSeedUser
    (string guidString,
        string email,
        string fullName,
        string pictureUrl,
        Gender? gender,
        string password,
        IPasswordHasher<AppUser> passwordHasher)
    {
        var user = new AppUser()
        {
            Id = new Guid(guidString),
            UserName = email,
            NormalizedUserName = email.ToUpper(),
            Email = email,
            NormalizedEmail = email.ToUpper(),
            LockoutEnabled = true,
            SecurityStamp = Guid.NewGuid().ToString(),
            FullName = fullName,
            PictureUrl = pictureUrl,
            Gender = gender,
            Status = UserStatus.Active,
            CreatedDateTime = DateTime.UtcNow,
            UpdatedDateTime = DateTime.UtcNow
        };

        user.PasswordHash = passwordHasher.HashPassword(user, password);

        return user;
    }
}