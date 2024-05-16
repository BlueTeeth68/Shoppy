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

            CreateSeedUser("eee6e626-9a26-4f38-bbe3-433d20440ce9",
                "user5@gmail.com",
                "Sarah Kim",
                "https://avatarfiles.alphacoders.com/151/thumb-151233.jpg",
                Gender.Female,
                DefaultUserPassword,
                passwordHasher),

            CreateSeedUser("7db124bd-9953-4eb0-98f2-50b1be635544",
                "user6@gmail.com",
                "Robert Patel",
                "https://avatarfiles.alphacoders.com/151/thumb-151233.jpg",
                Gender.Male,
                DefaultUserPassword,
                passwordHasher),

            CreateSeedUser("50b95f41-7afa-4cda-aa7a-5fa49234d183",
                "user7@gmail.com",
                "Lisa Nguyen",
                "https://avatarfiles.alphacoders.com/151/thumb-151233.jpg",
                Gender.Female,
                DefaultUserPassword,
                passwordHasher)
        };

        string[] guids =
        {
            "50b95f41-7afa-4cda-aa7a-5fa49234d184",
            "8c3b46b9-1321-4d97-a193-5fa49234d185",
            "2d3d5b2d-b5a3-4b89-84b3-5fa49234d186",
            "b6123f4e-3443-41ae-a1cb-5fa49234d187",
            "5c6a5f5e-3a11-4d42-bff8-5fa49234d188",
            "4a8b3d09-78f2-43ad-bce6-5fa49234d189",
            "31e7a1a6-9a5d-4b4e-84eb-5fa49234d190",
            "d0e03a1a-21c2-4123-a75e-5fa49234d191",
            "0cd66cfc-5d48-4f5e-b22d-5fa49234d192",
            "60b9f0cc-b3b4-4ac3-a9ce-5fa49234d193",
            "6c16a235-f928-4b8d-978f-5fa49234d194",
            "9a4a34a4-4b12-4c8e-a52b-5fa49234d195",
            "35d6cf06-f0ef-47a6-a4bd-5fa49234d196",
            "eeed5a4d-e83d-4032-8c3c-5fa49234d197",
            "2b844c01-c89e-4d24-a5d8-5fa49234d198",
            "56b2a1c9-a651-4fee-8f8e-5fa49234d199",
            "3d77db7b-3b3e-4a38-a1d1-5fa49234d200",
            "c0a7e4f4-d8d0-4c80-8e1c-5fa49234d201",
            "1d2b5cf5-0ad7-4c3a-b4b9-5fa49234d202",
            "9d36fef6-9c75-4f96-a951-5fa49234d203",
            "5aca3775-d37e-473c-8f3a-3926ed32e360",
            "e92c6f32-859b-443b-bfb2-bd0674b5673a",
            "2c44d375-c725-4279-b2d3-87ea4218f385",
            "906f192a-96d3-433a-a7ea-288662b5f62d",
            "c55cdfd0-d1dd-4841-ae27-f2d621686756",
            "f483fb9f-477c-4a3a-9f73-3b028b06ed49",
            "87787f6e-729b-436b-bcc9-c7b48c45ba05",
            "d30fa796-5144-4467-a302-68dc64fd0d92",
            "91d0da1b-e147-4829-aa4e-7073c1a10d2c",
            "fbd62259-a313-4d38-885e-1f6acdf9a30a",
            "9b8c6d7b-754f-420c-b574-4a63326bfc6a",
            "6e2f7a2d-1994-419b-8c6d-b3d297cd7b06",
            "853988db-ad55-4a28-9782-90438c64b62d",
            "60a119e1-610c-42fc-85c8-95a7e4d2119b",
            "870559eb-5fde-4764-ade7-392b0cf6b5ce",
            "296dbab2-62f2-4eb6-ae53-e4c7fffdaf34",
            "b2687ce8-aad5-4d5f-849b-dcd2b402aff0"
        };

        for (var i = 0; i < guids.Length; i++)
        {
            var email = $"user{i + 8}@gmail.com";
            var fullName = $"User {i + 8}";
            var pictureUrl = "https://avatarfiles.alphacoders.com/151/thumb-151233.jpg";
            var gender = Gender.Female;
            var password = DefaultUserPassword;

            var user = CreateSeedUser(guids[i], email, fullName, pictureUrl, gender, password, passwordHasher);
            users.Add(user);
        }

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