using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Shoppy.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TotalItem = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductCategories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PictureUrl = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Gender = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CartId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Carts_CartId",
                        column: x => x.CartId,
                        principalTable: "Carts",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductThumbUrl = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Sku = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    AuthorName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Publisher = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    NumberOfPage = table.Column<int>(type: "int", nullable: true),
                    DateOfPublication = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(12,2)", precision: 12, scale: 2, nullable: false),
                    AvgRate = table.Column<decimal>(type: "decimal(2,1)", precision: 2, scale: 1, nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    NumberOfSale = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_ProductCategories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "ProductCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true),
                    Detail = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Addresses_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AppUserIdentityRole<Guid>",
                columns: table => new
                {
                    AppUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdentityRoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserIdentityRole<Guid>", x => new { x.AppUserId, x.IdentityRoleId });
                    table.ForeignKey(
                        name: "FK_AppUserIdentityRole<Guid>_AspNetRoles_IdentityRoleId",
                        column: x => x.IdentityRoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppUserIdentityRole<Guid>_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(11,2)", precision: 11, scale: 2, nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CartItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CartId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CartItems_Carts_CartId",
                        column: x => x.CartId,
                        principalTable: "Carts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CartItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductRatings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RateValue = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductRatings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductRatings_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductRatings_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OrderItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RatingResources",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ResourceUrl = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    RatingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RatingResources", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RatingResources_ProductRatings_RatingId",
                        column: x => x.RatingId,
                        principalTable: "ProductRatings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("5fc71af5-0216-402b-a5cb-ba17701e2fa3"), null, "Admin", "ADMIN" },
                    { new Guid("8bbf66a4-da08-4b87-bdb2-1502e38562f3"), null, "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "CartId", "ConcurrencyStamp", "CreatedDateTime", "Email", "EmailConfirmed", "FullName", "Gender", "IsDelete", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PictureUrl", "SecurityStamp", "Status", "TwoFactorEnabled", "UpdatedDateTime", "UserName" },
                values: new object[,]
                {
                    { new Guid("021657c8-d4d0-4167-a1a6-b7bb840f33bf"), 0, null, "d5b81bc3-d196-42f6-9822-59c7be9473ed", new DateTime(2024, 5, 16, 6, 29, 5, 891, DateTimeKind.Utc).AddTicks(3865), "user1@gmail.com", false, "Jane Smith", 1, false, true, null, "USER1@GMAIL.COM", "USER1@GMAIL.COM", "AQAAAAIAAYagAAAAEEP+RunmLGLUm0HG5H3fhIGKZk1qK98YZXIhMOtCfr0WDMn9FpkZyBwGOlmCaegKNA==", null, false, "https://avatarfiles.alphacoders.com/151/thumb-151233.jpg", "13c99412-d399-4bf9-a394-74691b67c48c", 1, false, new DateTime(2024, 5, 16, 6, 29, 5, 891, DateTimeKind.Utc).AddTicks(3868), "user1@gmail.com" },
                    { new Guid("0cd66cfc-5d48-4f5e-b22d-5fa49234d192"), 0, null, "d98595f5-07d1-4a8a-b188-ed951c60cf90", new DateTime(2024, 5, 16, 6, 29, 7, 435, DateTimeKind.Utc).AddTicks(1708), "user16@gmail.com", false, "User 16", 2, false, true, null, "USER16@GMAIL.COM", "USER16@GMAIL.COM", "AQAAAAIAAYagAAAAEA2lM5xK2cucm0S+WwfbhYd4kjVeOikraR+XX4yEH16g8F5ZF3Hco6eCpMV3TnbsCg==", null, false, "https://avatarfiles.alphacoders.com/151/thumb-151233.jpg", "9c3fd252-3f97-4524-8b83-dee73b5ff1d9", 1, false, new DateTime(2024, 5, 16, 6, 29, 7, 435, DateTimeKind.Utc).AddTicks(1712), "user16@gmail.com" },
                    { new Guid("1d2b5cf5-0ad7-4c3a-b4b9-5fa49234d202"), 0, null, "4702ca0a-d3e9-42cf-b9aa-cc06679597e4", new DateTime(2024, 5, 16, 6, 29, 8, 332, DateTimeKind.Utc).AddTicks(6831), "user26@gmail.com", false, "User 26", 2, false, true, null, "USER26@GMAIL.COM", "USER26@GMAIL.COM", "AQAAAAIAAYagAAAAENfwWZ49jjjz9qYRjxAIIcyqbGmWcvMVtk/2TQNwc1bJK8bnU2cxJ5gS+YxqYtbMVQ==", null, false, "https://avatarfiles.alphacoders.com/151/thumb-151233.jpg", "75dd71a6-8b09-4326-8aa5-1fcec1f0ae5a", 1, false, new DateTime(2024, 5, 16, 6, 29, 8, 332, DateTimeKind.Utc).AddTicks(6834), "user26@gmail.com" },
                    { new Guid("296dbab2-62f2-4eb6-ae53-e4c7fffdaf34"), 0, null, "5e9717ee-4b86-43ea-b4da-1b68da65a158", new DateTime(2024, 5, 16, 6, 29, 9, 928, DateTimeKind.Utc).AddTicks(1180), "user43@gmail.com", false, "User 43", 2, false, true, null, "USER43@GMAIL.COM", "USER43@GMAIL.COM", "AQAAAAIAAYagAAAAEFCRanRlpFksB/XJKAN+np4Syvtk+GiNGbfAEp+8A+gEVf05YPRuh9Zf2IgAmshi8g==", null, false, "https://avatarfiles.alphacoders.com/151/thumb-151233.jpg", "7992c61f-9241-42cb-8bf4-de7cf7b4ff54", 1, false, new DateTime(2024, 5, 16, 6, 29, 9, 928, DateTimeKind.Utc).AddTicks(1183), "user43@gmail.com" },
                    { new Guid("2b844c01-c89e-4d24-a5d8-5fa49234d198"), 0, null, "c47b6db6-199d-4254-9a7b-f9db5881998e", new DateTime(2024, 5, 16, 6, 29, 7, 974, DateTimeKind.Utc).AddTicks(9167), "user22@gmail.com", false, "User 22", 2, false, true, null, "USER22@GMAIL.COM", "USER22@GMAIL.COM", "AQAAAAIAAYagAAAAELZWTeWPJuhRGuCyYemEAZ2dTMuXjQXv2kyscU7P5g4G9kUHvOrSyf7fFGfpHBZ5/Q==", null, false, "https://avatarfiles.alphacoders.com/151/thumb-151233.jpg", "936471ed-5a52-4a37-a005-7d593bbb8ae3", 1, false, new DateTime(2024, 5, 16, 6, 29, 7, 974, DateTimeKind.Utc).AddTicks(9171), "user22@gmail.com" },
                    { new Guid("2c44d375-c725-4279-b2d3-87ea4218f385"), 0, null, "25f3cb94-1502-4642-b895-6ec2f982cc88", new DateTime(2024, 5, 16, 6, 29, 8, 690, DateTimeKind.Utc).AddTicks(5589), "user30@gmail.com", false, "User 30", 2, false, true, null, "USER30@GMAIL.COM", "USER30@GMAIL.COM", "AQAAAAIAAYagAAAAEDbnFGHzgZbkd9aFcjJGJaWNbbPCiXlmT3c1FCO4CFt9oeSzYZ1fQ1kp5/jAw7ECHg==", null, false, "https://avatarfiles.alphacoders.com/151/thumb-151233.jpg", "d109ff6c-e6d6-406c-89e6-22bc3a43ddb9", 1, false, new DateTime(2024, 5, 16, 6, 29, 8, 690, DateTimeKind.Utc).AddTicks(5592), "user30@gmail.com" },
                    { new Guid("2c96fabb-f759-43ef-9a31-328c25d2eff5"), 0, null, "65dd3275-e1a8-49a4-abd2-55f1ab2d41b5", new DateTime(2024, 5, 16, 6, 29, 6, 1, DateTimeKind.Utc).AddTicks(1257), "user2@gmail.com", false, "Michael Johnson", 2, false, true, null, "USER2@GMAIL.COM", "USER2@GMAIL.COM", "AQAAAAIAAYagAAAAEJys5+mzSl1xbsUD0it52PdGk8bzI0PvoS3FqBrvWJGabENwEd5tN+5cx07LF2k1/g==", null, false, "https://avatarfiles.alphacoders.com/151/thumb-151233.jpg", "1f113070-4cec-4174-975c-e5d12049c0bf", 1, false, new DateTime(2024, 5, 16, 6, 29, 6, 1, DateTimeKind.Utc).AddTicks(1260), "user2@gmail.com" },
                    { new Guid("2d3d5b2d-b5a3-4b89-84b3-5fa49234d186"), 0, null, "f1193c69-876b-4aeb-a31e-8242c856624f", new DateTime(2024, 5, 16, 6, 29, 6, 896, DateTimeKind.Utc).AddTicks(3250), "user10@gmail.com", false, "User 10", 2, false, true, null, "USER10@GMAIL.COM", "USER10@GMAIL.COM", "AQAAAAIAAYagAAAAEOj0P/OEFSmolBBi9vtvOFRE2vyhaUB7182n9Mxe6Eb2IMx2UkuHghuKKWwlUIWAeg==", null, false, "https://avatarfiles.alphacoders.com/151/thumb-151233.jpg", "22735063-29fd-44a4-8a75-a54bcd2d78ff", 1, false, new DateTime(2024, 5, 16, 6, 29, 6, 896, DateTimeKind.Utc).AddTicks(3253), "user10@gmail.com" },
                    { new Guid("30a4345d-df2e-46ab-8c0e-d38a7933b591"), 0, null, "09d2bd2b-df45-4bb9-9596-ef848dd38a59", new DateTime(2024, 5, 16, 6, 29, 6, 105, DateTimeKind.Utc).AddTicks(5992), "user3@gmail.com", false, "Emily Davis", 2, false, true, null, "USER3@GMAIL.COM", "USER3@GMAIL.COM", "AQAAAAIAAYagAAAAEOsr8xUGZfgnU/V8kZ7QHK3+TaI7EMrhiq0TKvcJz8rWnpHeb9TCJzwCTvMaexPSMw==", null, false, "https://avatarfiles.alphacoders.com/151/thumb-151233.jpg", "94ed5325-caad-4ec4-8f5d-bd58a7f0c09f", 1, false, new DateTime(2024, 5, 16, 6, 29, 6, 105, DateTimeKind.Utc).AddTicks(5997), "user3@gmail.com" },
                    { new Guid("31e7a1a6-9a5d-4b4e-84eb-5fa49234d190"), 0, null, "b9f7f8b4-6ab2-4fd6-a516-9f94ab86c037", new DateTime(2024, 5, 16, 6, 29, 7, 253, DateTimeKind.Utc).AddTicks(7050), "user14@gmail.com", false, "User 14", 2, false, true, null, "USER14@GMAIL.COM", "USER14@GMAIL.COM", "AQAAAAIAAYagAAAAEDNXD2AEQELIt5t0Y90Ohsr5SO5/ofIG+FlrsGI/Pu4GRpe921IP9V6AyoyxrTgTAQ==", null, false, "https://avatarfiles.alphacoders.com/151/thumb-151233.jpg", "a7d03ae3-133e-4cb9-81aa-3e37b5df83be", 1, false, new DateTime(2024, 5, 16, 6, 29, 7, 253, DateTimeKind.Utc).AddTicks(7053), "user14@gmail.com" },
                    { new Guid("35d6cf06-f0ef-47a6-a4bd-5fa49234d196"), 0, null, "059acff1-10ef-4d20-bfdc-86609233f142", new DateTime(2024, 5, 16, 6, 29, 7, 796, DateTimeKind.Utc).AddTicks(6770), "user20@gmail.com", false, "User 20", 2, false, true, null, "USER20@GMAIL.COM", "USER20@GMAIL.COM", "AQAAAAIAAYagAAAAEINYHak6R4pRwH30eP1BwaH1qXW4IHV7961hy2OvevkkJ4Tix2jY5yJJ/mMBFn9T5A==", null, false, "https://avatarfiles.alphacoders.com/151/thumb-151233.jpg", "456abea4-1875-42a5-853a-81465c85113a", 1, false, new DateTime(2024, 5, 16, 6, 29, 7, 796, DateTimeKind.Utc).AddTicks(6773), "user20@gmail.com" },
                    { new Guid("3d77db7b-3b3e-4a38-a1d1-5fa49234d200"), 0, null, "868d0089-0f4a-49ca-8171-0aa485856d70", new DateTime(2024, 5, 16, 6, 29, 8, 154, DateTimeKind.Utc).AddTicks(1494), "user24@gmail.com", false, "User 24", 2, false, true, null, "USER24@GMAIL.COM", "USER24@GMAIL.COM", "AQAAAAIAAYagAAAAEFGZBJTRlhVEs9g3WV2UBNION0pNIsPv65xMGCypciDK9V1LjzMzdi682XdjcQj4bQ==", null, false, "https://avatarfiles.alphacoders.com/151/thumb-151233.jpg", "ece57a2b-eaa8-48d5-8b2a-465fc564431a", 1, false, new DateTime(2024, 5, 16, 6, 29, 8, 154, DateTimeKind.Utc).AddTicks(1497), "user24@gmail.com" },
                    { new Guid("4a8b3d09-78f2-43ad-bce6-5fa49234d189"), 0, null, "8662da30-a19b-4ba6-916c-95a13e0b075b", new DateTime(2024, 5, 16, 6, 29, 7, 164, DateTimeKind.Utc).AddTicks(6995), "user13@gmail.com", false, "User 13", 2, false, true, null, "USER13@GMAIL.COM", "USER13@GMAIL.COM", "AQAAAAIAAYagAAAAEKmwktVfYde+F4pEShc34fY/4OegG9u8KwOubU8EWmVjhOjuIZOKONrUADu6yUUNEw==", null, false, "https://avatarfiles.alphacoders.com/151/thumb-151233.jpg", "5f8c2865-d735-4d8e-815b-32d722a5b691", 1, false, new DateTime(2024, 5, 16, 6, 29, 7, 164, DateTimeKind.Utc).AddTicks(6998), "user13@gmail.com" },
                    { new Guid("50b95f41-7afa-4cda-aa7a-5fa49234d183"), 0, null, "9c38f8aa-4243-41c0-a4d5-784c2bd54408", new DateTime(2024, 5, 16, 6, 29, 6, 565, DateTimeKind.Utc).AddTicks(3461), "user7@gmail.com", false, "Lisa Nguyen", 2, false, true, null, "USER7@GMAIL.COM", "USER7@GMAIL.COM", "AQAAAAIAAYagAAAAEFTSKwMhr/+LVvUCKmUKvKt5K9teHQ5LkzDNB3et9LYakUkgEw7j4XJ6vNvoUlByxA==", null, false, "https://avatarfiles.alphacoders.com/151/thumb-151233.jpg", "42c93928-f743-4e80-a005-131c78dca62d", 1, false, new DateTime(2024, 5, 16, 6, 29, 6, 565, DateTimeKind.Utc).AddTicks(3464), "user7@gmail.com" },
                    { new Guid("50b95f41-7afa-4cda-aa7a-5fa49234d184"), 0, null, "9254d819-a417-4915-9fd1-6ba6462e2415", new DateTime(2024, 5, 16, 6, 29, 6, 675, DateTimeKind.Utc).AddTicks(5219), "user8@gmail.com", false, "User 8", 2, false, true, null, "USER8@GMAIL.COM", "USER8@GMAIL.COM", "AQAAAAIAAYagAAAAEGEYEywA2Iato5b3P6K5VybKKtwqmESpN+ynDR49haRgFdm8NFGh6y7cwK4ChaQV1g==", null, false, "https://avatarfiles.alphacoders.com/151/thumb-151233.jpg", "2492c9af-3f6e-4e8e-b952-5684088126e2", 1, false, new DateTime(2024, 5, 16, 6, 29, 6, 675, DateTimeKind.Utc).AddTicks(5223), "user8@gmail.com" },
                    { new Guid("56b2a1c9-a651-4fee-8f8e-5fa49234d199"), 0, null, "f2297755-49c1-42ac-9d15-073648c55dd3", new DateTime(2024, 5, 16, 6, 29, 8, 65, DateTimeKind.Utc).AddTicks(7955), "user23@gmail.com", false, "User 23", 2, false, true, null, "USER23@GMAIL.COM", "USER23@GMAIL.COM", "AQAAAAIAAYagAAAAEEhSq4HtUgBkVYyG43JlZtdVgfrpanFJSorOJbTBjC1sDGZ/uOCMHvEz6Ax7r/k+0g==", null, false, "https://avatarfiles.alphacoders.com/151/thumb-151233.jpg", "c447c1f9-3427-4a34-8757-eeec1090f81d", 1, false, new DateTime(2024, 5, 16, 6, 29, 8, 65, DateTimeKind.Utc).AddTicks(7959), "user23@gmail.com" },
                    { new Guid("594f8fe1-1cf1-4f5a-a8ae-6b9509fbf283"), 0, null, "9eab7330-7dfa-4bc1-be3e-9543a32c27c5", new DateTime(2024, 5, 16, 6, 29, 6, 236, DateTimeKind.Utc).AddTicks(6448), "user4@gmail.com", false, "David Lee", 1, false, true, null, "USER4@GMAIL.COM", "USER4@GMAIL.COM", "AQAAAAIAAYagAAAAEPLL8MV76WjTeRQ8c05/b2HvjRyj4JJMP8NuFfOt9Z8Cbkp20RSqesohxtPQx1pyHw==", null, false, "https://avatarfiles.alphacoders.com/151/thumb-151233.jpg", "37672a0f-42d9-48fc-a782-8db46a75dd95", 1, false, new DateTime(2024, 5, 16, 6, 29, 6, 236, DateTimeKind.Utc).AddTicks(6451), "user4@gmail.com" },
                    { new Guid("5aca3775-d37e-473c-8f3a-3926ed32e360"), 0, null, "48f3fe36-5153-482b-becd-fccdc4ca3f3e", new DateTime(2024, 5, 16, 6, 29, 8, 510, DateTimeKind.Utc).AddTicks(4138), "user28@gmail.com", false, "User 28", 2, false, true, null, "USER28@GMAIL.COM", "USER28@GMAIL.COM", "AQAAAAIAAYagAAAAEH3S2hKewOJuFkB3bgljBnYNUqvMy4w0nv2PEROomWL/YQTPkeDgF2s/v7ECWUYZRg==", null, false, "https://avatarfiles.alphacoders.com/151/thumb-151233.jpg", "05c52f13-aeeb-44e7-a5dc-b48ae7822e3b", 1, false, new DateTime(2024, 5, 16, 6, 29, 8, 510, DateTimeKind.Utc).AddTicks(4142), "user28@gmail.com" },
                    { new Guid("5c6a5f5e-3a11-4d42-bff8-5fa49234d188"), 0, null, "f4a831d7-6436-47f8-ab2e-668be6b39392", new DateTime(2024, 5, 16, 6, 29, 7, 74, DateTimeKind.Utc).AddTicks(5394), "user12@gmail.com", false, "User 12", 2, false, true, null, "USER12@GMAIL.COM", "USER12@GMAIL.COM", "AQAAAAIAAYagAAAAEL2CP7NDAbKvGfhoWYGgAoSRoFjw9wk1QDncd/k5KreWt0eMYlmO6oqZ5+fl8oVJyg==", null, false, "https://avatarfiles.alphacoders.com/151/thumb-151233.jpg", "3c48fcc5-8fc3-4c7e-96be-9736c84ce592", 1, false, new DateTime(2024, 5, 16, 6, 29, 7, 74, DateTimeKind.Utc).AddTicks(5398), "user12@gmail.com" },
                    { new Guid("60a119e1-610c-42fc-85c8-95a7e4d2119b"), 0, null, "7b2b17a0-fee5-45df-a86b-b5f57c1b40f1", new DateTime(2024, 5, 16, 6, 29, 9, 746, DateTimeKind.Utc).AddTicks(8733), "user41@gmail.com", false, "User 41", 2, false, true, null, "USER41@GMAIL.COM", "USER41@GMAIL.COM", "AQAAAAIAAYagAAAAELfJPa1Hc29vo6wPCnhKl+prcB0kysuQ454xriHgtkxW4Uc5X9vW/tPrGuGIEnhJ+g==", null, false, "https://avatarfiles.alphacoders.com/151/thumb-151233.jpg", "d28e46b4-34ce-4a0d-9dd2-c06cd010a723", 1, false, new DateTime(2024, 5, 16, 6, 29, 9, 746, DateTimeKind.Utc).AddTicks(8736), "user41@gmail.com" },
                    { new Guid("60b9f0cc-b3b4-4ac3-a9ce-5fa49234d193"), 0, null, "899a6ad4-1b05-4528-9e17-4568dd905815", new DateTime(2024, 5, 16, 6, 29, 7, 524, DateTimeKind.Utc).AddTicks(7870), "user17@gmail.com", false, "User 17", 2, false, true, null, "USER17@GMAIL.COM", "USER17@GMAIL.COM", "AQAAAAIAAYagAAAAEJylsw4TguGtfedovWlBM++vOzEH7Do2mRMu9otzv3DKacvJDuYO4OY+Xcts8PKnkg==", null, false, "https://avatarfiles.alphacoders.com/151/thumb-151233.jpg", "d6cbb040-ce01-4b44-9e7c-6b152c1d4761", 1, false, new DateTime(2024, 5, 16, 6, 29, 7, 524, DateTimeKind.Utc).AddTicks(7873), "user17@gmail.com" },
                    { new Guid("6c16a235-f928-4b8d-978f-5fa49234d194"), 0, null, "c90e8555-52f8-43a9-9f7d-85dc42a110ef", new DateTime(2024, 5, 16, 6, 29, 7, 613, DateTimeKind.Utc).AddTicks(7331), "user18@gmail.com", false, "User 18", 2, false, true, null, "USER18@GMAIL.COM", "USER18@GMAIL.COM", "AQAAAAIAAYagAAAAELfNjqZRbdEVXKKt+UcbnY7p0Zcj+zo77eIG5OyU8CeoJcvlfI3tSoJFVvcgiO4WrA==", null, false, "https://avatarfiles.alphacoders.com/151/thumb-151233.jpg", "3bc19a54-d3ea-4c2d-80ea-7536bdc55fd1", 1, false, new DateTime(2024, 5, 16, 6, 29, 7, 613, DateTimeKind.Utc).AddTicks(7334), "user18@gmail.com" },
                    { new Guid("6e2f7a2d-1994-419b-8c6d-b3d297cd7b06"), 0, null, "44044258-f625-4e38-b06e-a777859204a3", new DateTime(2024, 5, 16, 6, 29, 9, 568, DateTimeKind.Utc).AddTicks(1191), "user39@gmail.com", false, "User 39", 2, false, true, null, "USER39@GMAIL.COM", "USER39@GMAIL.COM", "AQAAAAIAAYagAAAAEOl4n4q4BwkvSDXQfdxbXz4D+xXVJS4riBhXGk2JnWg1pU4MGTIsbU6ME2E3OPD/rg==", null, false, "https://avatarfiles.alphacoders.com/151/thumb-151233.jpg", "f123adac-30a0-4b9f-b980-ccc685dd934b", 1, false, new DateTime(2024, 5, 16, 6, 29, 9, 568, DateTimeKind.Utc).AddTicks(1195), "user39@gmail.com" },
                    { new Guid("7db124bd-9953-4eb0-98f2-50b1be635544"), 0, null, "153e3891-e12f-41da-9d0d-4f2b79b19f02", new DateTime(2024, 5, 16, 6, 29, 6, 469, DateTimeKind.Utc).AddTicks(5527), "user6@gmail.com", false, "Robert Patel", 1, false, true, null, "USER6@GMAIL.COM", "USER6@GMAIL.COM", "AQAAAAIAAYagAAAAECRt57bqaGOfZ+o66Xhlr7Tye0cwyCPdlFWawdyu10rLAmXwfEAWsckcIWeNkWkQqw==", null, false, "https://avatarfiles.alphacoders.com/151/thumb-151233.jpg", "f61fc692-05f8-496a-b1e0-6e0a229ba7aa", 1, false, new DateTime(2024, 5, 16, 6, 29, 6, 469, DateTimeKind.Utc).AddTicks(5530), "user6@gmail.com" },
                    { new Guid("853988db-ad55-4a28-9782-90438c64b62d"), 0, null, "8967288b-8ea6-47cf-8081-aa6bec34f5ee", new DateTime(2024, 5, 16, 6, 29, 9, 657, DateTimeKind.Utc).AddTicks(6776), "user40@gmail.com", false, "User 40", 2, false, true, null, "USER40@GMAIL.COM", "USER40@GMAIL.COM", "AQAAAAIAAYagAAAAEIy31OS3jyVjSecsQ6Ef/zZw0Y9CGGRJYpf1ceoCml6DGFICF/5TdzGYNjW6NrVARQ==", null, false, "https://avatarfiles.alphacoders.com/151/thumb-151233.jpg", "25667df8-879e-4fad-9e21-30767733c9ad", 1, false, new DateTime(2024, 5, 16, 6, 29, 9, 657, DateTimeKind.Utc).AddTicks(6780), "user40@gmail.com" },
                    { new Guid("85d8a27f-9d32-4269-b5d0-844589d498d0"), 0, null, "4dc70e75-0212-47e6-aa0a-03c3bfe68d20", new DateTime(2024, 5, 16, 6, 29, 5, 781, DateTimeKind.Utc).AddTicks(3011), "admin@gmail.com", false, "John Doe", 1, false, true, null, "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAIAAYagAAAAEP6LEFr0udmDmo/SkmPd6RFEOcjNH8/O1oQAmKXFS4ZHejJ83XZxOwArdbARKLvNzg==", null, false, "https://avatarfiles.alphacoders.com/151/thumb-151233.jpg", "2811ec9d-4e42-48bc-9f9e-9cd047d2df9a", 1, false, new DateTime(2024, 5, 16, 6, 29, 5, 781, DateTimeKind.Utc).AddTicks(3014), "admin@gmail.com" },
                    { new Guid("870559eb-5fde-4764-ade7-392b0cf6b5ce"), 0, null, "3fa2455d-2e17-48a9-8de7-f1f54378877e", new DateTime(2024, 5, 16, 6, 29, 9, 837, DateTimeKind.Utc).AddTicks(6124), "user42@gmail.com", false, "User 42", 2, false, true, null, "USER42@GMAIL.COM", "USER42@GMAIL.COM", "AQAAAAIAAYagAAAAEGwrOzzD+uM472CNf4PBbC/84wSiEzZC4QYGH5NXZE3rHgngg3rv4smYopIWN2/Cag==", null, false, "https://avatarfiles.alphacoders.com/151/thumb-151233.jpg", "c986cd56-b030-4d71-acab-d44b4ad7f8a5", 1, false, new DateTime(2024, 5, 16, 6, 29, 9, 837, DateTimeKind.Utc).AddTicks(6128), "user42@gmail.com" },
                    { new Guid("87787f6e-729b-436b-bcc9-c7b48c45ba05"), 0, null, "0c75186a-a387-4406-b7cc-2bb3f197c381", new DateTime(2024, 5, 16, 6, 29, 9, 74, DateTimeKind.Utc).AddTicks(4259), "user34@gmail.com", false, "User 34", 2, false, true, null, "USER34@GMAIL.COM", "USER34@GMAIL.COM", "AQAAAAIAAYagAAAAENO2PHYarmZYLVa/TRso1XMJ39gY+Jt+mjQnZgoypElmCurIWMK8teaQWIZU2hM0ww==", null, false, "https://avatarfiles.alphacoders.com/151/thumb-151233.jpg", "82b4fc5b-4ac5-491e-a3d0-a8738cb772e3", 1, false, new DateTime(2024, 5, 16, 6, 29, 9, 74, DateTimeKind.Utc).AddTicks(4262), "user34@gmail.com" },
                    { new Guid("8c3b46b9-1321-4d97-a193-5fa49234d185"), 0, null, "e59fc8b0-f933-4e8b-94d0-70e5d8c2b099", new DateTime(2024, 5, 16, 6, 29, 6, 807, DateTimeKind.Utc).AddTicks(4329), "user9@gmail.com", false, "User 9", 2, false, true, null, "USER9@GMAIL.COM", "USER9@GMAIL.COM", "AQAAAAIAAYagAAAAELE3ay3IenkD0PmulwAk4V84zW5X7FdkT7+tqgYMz6ud7wEOQnsLhmiYoQWftIm3lg==", null, false, "https://avatarfiles.alphacoders.com/151/thumb-151233.jpg", "dfd6148f-7328-4966-b8bc-4b52d05cc5f3", 1, false, new DateTime(2024, 5, 16, 6, 29, 6, 807, DateTimeKind.Utc).AddTicks(4332), "user9@gmail.com" },
                    { new Guid("906f192a-96d3-433a-a7ea-288662b5f62d"), 0, null, "cc047fc0-895b-4edf-98b8-57a92e06091b", new DateTime(2024, 5, 16, 6, 29, 8, 779, DateTimeKind.Utc).AddTicks(248), "user31@gmail.com", false, "User 31", 2, false, true, null, "USER31@GMAIL.COM", "USER31@GMAIL.COM", "AQAAAAIAAYagAAAAENuj4f/BDFoQDinfs+W2VBJ5YQv9w93PTcyiBNUZVRPzBQFpMFu690f7SGO+WujIHg==", null, false, "https://avatarfiles.alphacoders.com/151/thumb-151233.jpg", "6098af1a-0c4f-4a0c-b9f2-4cdbf6f04c1c", 1, false, new DateTime(2024, 5, 16, 6, 29, 8, 779, DateTimeKind.Utc).AddTicks(251), "user31@gmail.com" },
                    { new Guid("91d0da1b-e147-4829-aa4e-7073c1a10d2c"), 0, null, "07cdce8f-164f-4dd6-88d8-98340e188615", new DateTime(2024, 5, 16, 6, 29, 9, 280, DateTimeKind.Utc).AddTicks(471), "user36@gmail.com", false, "User 36", 2, false, true, null, "USER36@GMAIL.COM", "USER36@GMAIL.COM", "AQAAAAIAAYagAAAAEJjs/TQ/R3F70uJEvHxD2MDpGta4k4rWirO6bYUisav0kHfwSAwA/kKqBzvvPbVIog==", null, false, "https://avatarfiles.alphacoders.com/151/thumb-151233.jpg", "265e629e-6384-4ebf-be6a-eee3bd59c4ea", 1, false, new DateTime(2024, 5, 16, 6, 29, 9, 280, DateTimeKind.Utc).AddTicks(474), "user36@gmail.com" },
                    { new Guid("9a4a34a4-4b12-4c8e-a52b-5fa49234d195"), 0, null, "2161a88a-411b-4c6a-8c7f-5b1d5b4de8b2", new DateTime(2024, 5, 16, 6, 29, 7, 707, DateTimeKind.Utc).AddTicks(671), "user19@gmail.com", false, "User 19", 2, false, true, null, "USER19@GMAIL.COM", "USER19@GMAIL.COM", "AQAAAAIAAYagAAAAEJV5KvLT9r1aYtMLoksqX482e4uT/WHC2mBPMAIvGD2Ix6fLlgou2R1v7w0fhzXdoQ==", null, false, "https://avatarfiles.alphacoders.com/151/thumb-151233.jpg", "b3948835-596b-4727-bf48-c1c1040f3ddc", 1, false, new DateTime(2024, 5, 16, 6, 29, 7, 707, DateTimeKind.Utc).AddTicks(675), "user19@gmail.com" },
                    { new Guid("9b8c6d7b-754f-420c-b574-4a63326bfc6a"), 0, null, "f052acd0-62c6-4a60-99bc-029a3783780c", new DateTime(2024, 5, 16, 6, 29, 9, 478, DateTimeKind.Utc).AddTicks(9308), "user38@gmail.com", false, "User 38", 2, false, true, null, "USER38@GMAIL.COM", "USER38@GMAIL.COM", "AQAAAAIAAYagAAAAEPi+O2ee2vTohOnPyFkCmy3s7Y11rzYmM4ZocxbWG31EvNo9D5dzYS1ouxHPAhwudQ==", null, false, "https://avatarfiles.alphacoders.com/151/thumb-151233.jpg", "df5a6034-32a8-4f77-9f51-3cf3817a8070", 1, false, new DateTime(2024, 5, 16, 6, 29, 9, 478, DateTimeKind.Utc).AddTicks(9311), "user38@gmail.com" },
                    { new Guid("9d36fef6-9c75-4f96-a951-5fa49234d203"), 0, null, "458dc101-768f-45be-8798-a370988259a4", new DateTime(2024, 5, 16, 6, 29, 8, 421, DateTimeKind.Utc).AddTicks(1800), "user27@gmail.com", false, "User 27", 2, false, true, null, "USER27@GMAIL.COM", "USER27@GMAIL.COM", "AQAAAAIAAYagAAAAEBbkxgK9iU/M3yG2FtPSiPI3VchnrxlMNAl1aEdR68zTFQORxS8Z0bQ2C9PKi91gdw==", null, false, "https://avatarfiles.alphacoders.com/151/thumb-151233.jpg", "e984de3c-7eb8-4935-b7d1-d176dc5ddc12", 1, false, new DateTime(2024, 5, 16, 6, 29, 8, 421, DateTimeKind.Utc).AddTicks(1803), "user27@gmail.com" },
                    { new Guid("b2687ce8-aad5-4d5f-849b-dcd2b402aff0"), 0, null, "39db2176-c2b8-452b-8cb5-4fab15e0e1cb", new DateTime(2024, 5, 16, 6, 29, 10, 17, DateTimeKind.Utc).AddTicks(9544), "user44@gmail.com", false, "User 44", 2, false, true, null, "USER44@GMAIL.COM", "USER44@GMAIL.COM", "AQAAAAIAAYagAAAAEIgOiR1hWxfXOaJL6JPHZiZRl/kaSE3+NNGeQRd9k0UVdmJGfwEF60sgDB2YRVTN2w==", null, false, "https://avatarfiles.alphacoders.com/151/thumb-151233.jpg", "bbdbbaa9-60f3-4d1c-b9b7-f084b009d858", 1, false, new DateTime(2024, 5, 16, 6, 29, 10, 17, DateTimeKind.Utc).AddTicks(9547), "user44@gmail.com" },
                    { new Guid("b6123f4e-3443-41ae-a1cb-5fa49234d187"), 0, null, "db8c20df-2b5f-48b6-9e65-b6016c438ec0", new DateTime(2024, 5, 16, 6, 29, 6, 985, DateTimeKind.Utc).AddTicks(4796), "user11@gmail.com", false, "User 11", 2, false, true, null, "USER11@GMAIL.COM", "USER11@GMAIL.COM", "AQAAAAIAAYagAAAAEGi5qb9bIEZ3BGbwXRPq4zUo3rB+nwBr8x4hBlaOmhq4rSdnjB7ZMRFa1Xy/U7QHCg==", null, false, "https://avatarfiles.alphacoders.com/151/thumb-151233.jpg", "62289524-515c-48e7-90ef-0fc4d142b5e8", 1, false, new DateTime(2024, 5, 16, 6, 29, 6, 985, DateTimeKind.Utc).AddTicks(4799), "user11@gmail.com" },
                    { new Guid("c0a7e4f4-d8d0-4c80-8e1c-5fa49234d201"), 0, null, "d7bebeef-caf5-4f1f-ae98-50777d87d359", new DateTime(2024, 5, 16, 6, 29, 8, 243, DateTimeKind.Utc).AddTicks(3072), "user25@gmail.com", false, "User 25", 2, false, true, null, "USER25@GMAIL.COM", "USER25@GMAIL.COM", "AQAAAAIAAYagAAAAEI3bXa6qKJxDZpYIqi3JavRBsWoiklamg4K/z07lgcdY6mnmBWAsoNWQaEqecFrKBA==", null, false, "https://avatarfiles.alphacoders.com/151/thumb-151233.jpg", "25b6b08b-1755-47cb-93cb-82f577ef62b2", 1, false, new DateTime(2024, 5, 16, 6, 29, 8, 243, DateTimeKind.Utc).AddTicks(3076), "user25@gmail.com" },
                    { new Guid("c55cdfd0-d1dd-4841-ae27-f2d621686756"), 0, null, "9659a62e-82e9-4d57-9991-176e25f38ca6", new DateTime(2024, 5, 16, 6, 29, 8, 870, DateTimeKind.Utc).AddTicks(3464), "user32@gmail.com", false, "User 32", 2, false, true, null, "USER32@GMAIL.COM", "USER32@GMAIL.COM", "AQAAAAIAAYagAAAAEP4ibrWRczlVRRLeZ6PAiexd9HGBmRckAIQ1/Q2wtVNzeIrMVKLMblPsNwRwa5M+fQ==", null, false, "https://avatarfiles.alphacoders.com/151/thumb-151233.jpg", "831e1a9d-5791-4317-a1ce-e9df8c1c6941", 1, false, new DateTime(2024, 5, 16, 6, 29, 8, 870, DateTimeKind.Utc).AddTicks(3467), "user32@gmail.com" },
                    { new Guid("d0e03a1a-21c2-4123-a75e-5fa49234d191"), 0, null, "8bee9b4c-67c5-4e79-96a6-eca768ed06b7", new DateTime(2024, 5, 16, 6, 29, 7, 343, DateTimeKind.Utc).AddTicks(8938), "user15@gmail.com", false, "User 15", 2, false, true, null, "USER15@GMAIL.COM", "USER15@GMAIL.COM", "AQAAAAIAAYagAAAAEKT8XXMpiACSW/wLzdE9tMOAGI1lcoGJuf1VUkQG/X5NaYcKmSzRHZ/yiKOjJ1jm3w==", null, false, "https://avatarfiles.alphacoders.com/151/thumb-151233.jpg", "f5e82304-fea1-4226-9a25-62a9febe3368", 1, false, new DateTime(2024, 5, 16, 6, 29, 7, 343, DateTimeKind.Utc).AddTicks(8941), "user15@gmail.com" },
                    { new Guid("d30fa796-5144-4467-a302-68dc64fd0d92"), 0, null, "17682c11-6e18-4fd8-8d3c-e01d4dff7b4c", new DateTime(2024, 5, 16, 6, 29, 9, 177, DateTimeKind.Utc).AddTicks(6415), "user35@gmail.com", false, "User 35", 2, false, true, null, "USER35@GMAIL.COM", "USER35@GMAIL.COM", "AQAAAAIAAYagAAAAEIcBKIOjoGGya31H2Nx9fl5ubL/xFo0Gf/1191rg2cZsYzH2H7P5y/i5mrJV39qEiQ==", null, false, "https://avatarfiles.alphacoders.com/151/thumb-151233.jpg", "ac7b0168-756c-4c1b-8059-04caa6de9b0c", 1, false, new DateTime(2024, 5, 16, 6, 29, 9, 177, DateTimeKind.Utc).AddTicks(6419), "user35@gmail.com" },
                    { new Guid("e92c6f32-859b-443b-bfb2-bd0674b5673a"), 0, null, "a2fbe980-fd73-479b-a9c9-169af4cbdf69", new DateTime(2024, 5, 16, 6, 29, 8, 601, DateTimeKind.Utc).AddTicks(5515), "user29@gmail.com", false, "User 29", 2, false, true, null, "USER29@GMAIL.COM", "USER29@GMAIL.COM", "AQAAAAIAAYagAAAAEPDycRgQ49TqB08xAg272nBGuGTQCuUERYBHNX5M7Al1/4c6pBFbQPYL4FHctmlSzQ==", null, false, "https://avatarfiles.alphacoders.com/151/thumb-151233.jpg", "60e42ad8-9bc2-45ed-8353-493c84e811a0", 1, false, new DateTime(2024, 5, 16, 6, 29, 8, 601, DateTimeKind.Utc).AddTicks(5518), "user29@gmail.com" },
                    { new Guid("eee6e626-9a26-4f38-bbe3-433d20440ce9"), 0, null, "cba2d0bb-a45a-4fa2-9a13-52682bb4124d", new DateTime(2024, 5, 16, 6, 29, 6, 357, DateTimeKind.Utc).AddTicks(3946), "user5@gmail.com", false, "Sarah Kim", 2, false, true, null, "USER5@GMAIL.COM", "USER5@GMAIL.COM", "AQAAAAIAAYagAAAAEHqIrTaAkxatO9+W5Mrr14kRklAInXAEsPP1U8hRTDI9Lz3T2qGZWYpeQ/jLoaJguw==", null, false, "https://avatarfiles.alphacoders.com/151/thumb-151233.jpg", "8e9cf4bc-6e56-47df-9832-d13bcec31f3b", 1, false, new DateTime(2024, 5, 16, 6, 29, 6, 357, DateTimeKind.Utc).AddTicks(3950), "user5@gmail.com" },
                    { new Guid("eeed5a4d-e83d-4032-8c3c-5fa49234d197"), 0, null, "e521f269-1a54-4c2e-a6fa-388fe6dfe830", new DateTime(2024, 5, 16, 6, 29, 7, 885, DateTimeKind.Utc).AddTicks(9341), "user21@gmail.com", false, "User 21", 2, false, true, null, "USER21@GMAIL.COM", "USER21@GMAIL.COM", "AQAAAAIAAYagAAAAEIPmHJbDh1JXllRtx87KVq6JpeYnGE3CdkNNw6EvPHQ2NTbLeD3aLpxTjFYQlkq0nQ==", null, false, "https://avatarfiles.alphacoders.com/151/thumb-151233.jpg", "ed51fe41-42cb-43b2-820e-19031af5560a", 1, false, new DateTime(2024, 5, 16, 6, 29, 7, 885, DateTimeKind.Utc).AddTicks(9344), "user21@gmail.com" },
                    { new Guid("f483fb9f-477c-4a3a-9f73-3b028b06ed49"), 0, null, "78816027-618d-461e-b58a-6c8e2967776b", new DateTime(2024, 5, 16, 6, 29, 8, 959, DateTimeKind.Utc).AddTicks(15), "user33@gmail.com", false, "User 33", 2, false, true, null, "USER33@GMAIL.COM", "USER33@GMAIL.COM", "AQAAAAIAAYagAAAAEF8vPGLxxb8xY2eKalY1Gwyxwf+eXAMaCI8otBBwi+HePX3gESsotZqDJFconjck0w==", null, false, "https://avatarfiles.alphacoders.com/151/thumb-151233.jpg", "1fdb6027-3720-4a17-8c47-18bd527594f4", 1, false, new DateTime(2024, 5, 16, 6, 29, 8, 959, DateTimeKind.Utc).AddTicks(21), "user33@gmail.com" },
                    { new Guid("fbd62259-a313-4d38-885e-1f6acdf9a30a"), 0, null, "d027a409-a5ac-49ec-a9de-50bcfdaad326", new DateTime(2024, 5, 16, 6, 29, 9, 385, DateTimeKind.Utc).AddTicks(2303), "user37@gmail.com", false, "User 37", 2, false, true, null, "USER37@GMAIL.COM", "USER37@GMAIL.COM", "AQAAAAIAAYagAAAAEFaeybjP2Bs+6HZA5IWuipEJzXqjjto/+bRiil/AcoWpUARrkhOJbN6TDqGaVRCVNw==", null, false, "https://avatarfiles.alphacoders.com/151/thumb-151233.jpg", "382966e0-3ef7-416e-af6b-391a389c270b", 1, false, new DateTime(2024, 5, 16, 6, 29, 9, 385, DateTimeKind.Utc).AddTicks(2306), "user37@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "ProductCategories",
                columns: new[] { "Id", "CreatedDateTime", "Description", "Name", "UpdatedDateTime" },
                values: new object[,]
                {
                    { new Guid("292c90a5-1a0a-45a4-8f3d-37f09b09b422"), new DateTime(2024, 5, 16, 6, 29, 10, 109, DateTimeKind.Utc).AddTicks(676), null, "History", new DateTime(2024, 5, 16, 6, 29, 10, 109, DateTimeKind.Utc).AddTicks(676) },
                    { new Guid("2baf4c50-c927-4b54-971e-3ff5f300e147"), new DateTime(2024, 5, 16, 6, 29, 10, 109, DateTimeKind.Utc).AddTicks(663), null, "Romance", new DateTime(2024, 5, 16, 6, 29, 10, 109, DateTimeKind.Utc).AddTicks(666) },
                    { new Guid("97cf6bd7-7290-449a-a61d-5ea2fdfcf8de"), new DateTime(2024, 5, 16, 6, 29, 10, 109, DateTimeKind.Utc).AddTicks(678), null, "Education and Teacher", new DateTime(2024, 5, 16, 6, 29, 10, 109, DateTimeKind.Utc).AddTicks(678) },
                    { new Guid("99ada3c1-eea5-4431-a529-b3114de224da"), new DateTime(2024, 5, 16, 6, 29, 10, 109, DateTimeKind.Utc).AddTicks(671), null, "Economic", new DateTime(2024, 5, 16, 6, 29, 10, 109, DateTimeKind.Utc).AddTicks(671) },
                    { new Guid("adf36edc-3e08-4a36-8e20-0d79747f0962"), new DateTime(2024, 5, 16, 6, 29, 10, 109, DateTimeKind.Utc).AddTicks(673), null, "Business and Money", new DateTime(2024, 5, 16, 6, 29, 10, 109, DateTimeKind.Utc).AddTicks(674) }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("8bbf66a4-da08-4b87-bdb2-1502e38562f3"), new Guid("021657c8-d4d0-4167-a1a6-b7bb840f33bf") },
                    { new Guid("8bbf66a4-da08-4b87-bdb2-1502e38562f3"), new Guid("0cd66cfc-5d48-4f5e-b22d-5fa49234d192") },
                    { new Guid("8bbf66a4-da08-4b87-bdb2-1502e38562f3"), new Guid("1d2b5cf5-0ad7-4c3a-b4b9-5fa49234d202") },
                    { new Guid("8bbf66a4-da08-4b87-bdb2-1502e38562f3"), new Guid("296dbab2-62f2-4eb6-ae53-e4c7fffdaf34") },
                    { new Guid("8bbf66a4-da08-4b87-bdb2-1502e38562f3"), new Guid("2b844c01-c89e-4d24-a5d8-5fa49234d198") },
                    { new Guid("8bbf66a4-da08-4b87-bdb2-1502e38562f3"), new Guid("2c44d375-c725-4279-b2d3-87ea4218f385") },
                    { new Guid("8bbf66a4-da08-4b87-bdb2-1502e38562f3"), new Guid("2c96fabb-f759-43ef-9a31-328c25d2eff5") },
                    { new Guid("8bbf66a4-da08-4b87-bdb2-1502e38562f3"), new Guid("2d3d5b2d-b5a3-4b89-84b3-5fa49234d186") },
                    { new Guid("8bbf66a4-da08-4b87-bdb2-1502e38562f3"), new Guid("30a4345d-df2e-46ab-8c0e-d38a7933b591") },
                    { new Guid("8bbf66a4-da08-4b87-bdb2-1502e38562f3"), new Guid("31e7a1a6-9a5d-4b4e-84eb-5fa49234d190") },
                    { new Guid("8bbf66a4-da08-4b87-bdb2-1502e38562f3"), new Guid("35d6cf06-f0ef-47a6-a4bd-5fa49234d196") },
                    { new Guid("8bbf66a4-da08-4b87-bdb2-1502e38562f3"), new Guid("3d77db7b-3b3e-4a38-a1d1-5fa49234d200") },
                    { new Guid("8bbf66a4-da08-4b87-bdb2-1502e38562f3"), new Guid("4a8b3d09-78f2-43ad-bce6-5fa49234d189") },
                    { new Guid("8bbf66a4-da08-4b87-bdb2-1502e38562f3"), new Guid("50b95f41-7afa-4cda-aa7a-5fa49234d183") },
                    { new Guid("8bbf66a4-da08-4b87-bdb2-1502e38562f3"), new Guid("50b95f41-7afa-4cda-aa7a-5fa49234d184") },
                    { new Guid("8bbf66a4-da08-4b87-bdb2-1502e38562f3"), new Guid("56b2a1c9-a651-4fee-8f8e-5fa49234d199") },
                    { new Guid("8bbf66a4-da08-4b87-bdb2-1502e38562f3"), new Guid("594f8fe1-1cf1-4f5a-a8ae-6b9509fbf283") },
                    { new Guid("8bbf66a4-da08-4b87-bdb2-1502e38562f3"), new Guid("5aca3775-d37e-473c-8f3a-3926ed32e360") },
                    { new Guid("8bbf66a4-da08-4b87-bdb2-1502e38562f3"), new Guid("5c6a5f5e-3a11-4d42-bff8-5fa49234d188") },
                    { new Guid("8bbf66a4-da08-4b87-bdb2-1502e38562f3"), new Guid("60a119e1-610c-42fc-85c8-95a7e4d2119b") },
                    { new Guid("8bbf66a4-da08-4b87-bdb2-1502e38562f3"), new Guid("60b9f0cc-b3b4-4ac3-a9ce-5fa49234d193") },
                    { new Guid("8bbf66a4-da08-4b87-bdb2-1502e38562f3"), new Guid("6c16a235-f928-4b8d-978f-5fa49234d194") },
                    { new Guid("8bbf66a4-da08-4b87-bdb2-1502e38562f3"), new Guid("6e2f7a2d-1994-419b-8c6d-b3d297cd7b06") },
                    { new Guid("8bbf66a4-da08-4b87-bdb2-1502e38562f3"), new Guid("7db124bd-9953-4eb0-98f2-50b1be635544") },
                    { new Guid("8bbf66a4-da08-4b87-bdb2-1502e38562f3"), new Guid("853988db-ad55-4a28-9782-90438c64b62d") },
                    { new Guid("5fc71af5-0216-402b-a5cb-ba17701e2fa3"), new Guid("85d8a27f-9d32-4269-b5d0-844589d498d0") },
                    { new Guid("8bbf66a4-da08-4b87-bdb2-1502e38562f3"), new Guid("870559eb-5fde-4764-ade7-392b0cf6b5ce") },
                    { new Guid("8bbf66a4-da08-4b87-bdb2-1502e38562f3"), new Guid("87787f6e-729b-436b-bcc9-c7b48c45ba05") },
                    { new Guid("8bbf66a4-da08-4b87-bdb2-1502e38562f3"), new Guid("8c3b46b9-1321-4d97-a193-5fa49234d185") },
                    { new Guid("8bbf66a4-da08-4b87-bdb2-1502e38562f3"), new Guid("906f192a-96d3-433a-a7ea-288662b5f62d") },
                    { new Guid("8bbf66a4-da08-4b87-bdb2-1502e38562f3"), new Guid("91d0da1b-e147-4829-aa4e-7073c1a10d2c") },
                    { new Guid("8bbf66a4-da08-4b87-bdb2-1502e38562f3"), new Guid("9a4a34a4-4b12-4c8e-a52b-5fa49234d195") },
                    { new Guid("8bbf66a4-da08-4b87-bdb2-1502e38562f3"), new Guid("9b8c6d7b-754f-420c-b574-4a63326bfc6a") },
                    { new Guid("8bbf66a4-da08-4b87-bdb2-1502e38562f3"), new Guid("9d36fef6-9c75-4f96-a951-5fa49234d203") },
                    { new Guid("8bbf66a4-da08-4b87-bdb2-1502e38562f3"), new Guid("b2687ce8-aad5-4d5f-849b-dcd2b402aff0") },
                    { new Guid("8bbf66a4-da08-4b87-bdb2-1502e38562f3"), new Guid("b6123f4e-3443-41ae-a1cb-5fa49234d187") },
                    { new Guid("8bbf66a4-da08-4b87-bdb2-1502e38562f3"), new Guid("c0a7e4f4-d8d0-4c80-8e1c-5fa49234d201") },
                    { new Guid("8bbf66a4-da08-4b87-bdb2-1502e38562f3"), new Guid("c55cdfd0-d1dd-4841-ae27-f2d621686756") },
                    { new Guid("8bbf66a4-da08-4b87-bdb2-1502e38562f3"), new Guid("d0e03a1a-21c2-4123-a75e-5fa49234d191") },
                    { new Guid("8bbf66a4-da08-4b87-bdb2-1502e38562f3"), new Guid("d30fa796-5144-4467-a302-68dc64fd0d92") },
                    { new Guid("8bbf66a4-da08-4b87-bdb2-1502e38562f3"), new Guid("e92c6f32-859b-443b-bfb2-bd0674b5673a") },
                    { new Guid("8bbf66a4-da08-4b87-bdb2-1502e38562f3"), new Guid("eee6e626-9a26-4f38-bbe3-433d20440ce9") },
                    { new Guid("8bbf66a4-da08-4b87-bdb2-1502e38562f3"), new Guid("eeed5a4d-e83d-4032-8c3c-5fa49234d197") },
                    { new Guid("8bbf66a4-da08-4b87-bdb2-1502e38562f3"), new Guid("f483fb9f-477c-4a3a-9f73-3b028b06ed49") },
                    { new Guid("8bbf66a4-da08-4b87-bdb2-1502e38562f3"), new Guid("fbd62259-a313-4d38-885e-1f6acdf9a30a") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_UserId",
                table: "Addresses",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AppUserIdentityRole<Guid>_IdentityRoleId",
                table: "AppUserIdentityRole<Guid>",
                column: "IdentityRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_CartId",
                table: "AspNetUsers",
                column: "CartId",
                unique: true,
                filter: "[CartId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_Email",
                table: "AspNetUsers",
                column: "Email");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_FullName",
                table: "AspNetUsers",
                column: "FullName");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_Gender",
                table: "AspNetUsers",
                column: "Gender");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_IsDelete_NormalizedEmail",
                table: "AspNetUsers",
                columns: new[] { "IsDelete", "NormalizedEmail" });

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_CartId",
                table: "CartItems",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_ProductId",
                table: "CartItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItems",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_ProductId",
                table: "OrderItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategories_Name",
                table: "ProductCategories",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductRatings_ProductId",
                table: "ProductRatings",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductRatings_UserId",
                table: "ProductRatings",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_IsDelete",
                table: "Products",
                column: "IsDelete");

            migrationBuilder.CreateIndex(
                name: "IX_Products_Name",
                table: "Products",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Products_Sku",
                table: "Products",
                column: "Sku",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RatingResources_RatingId",
                table: "RatingResources",
                column: "RatingId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "AppUserIdentityRole<Guid>");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "CartItems");

            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "RatingResources");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "ProductRatings");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "ProductCategories");
        }
    }
}
