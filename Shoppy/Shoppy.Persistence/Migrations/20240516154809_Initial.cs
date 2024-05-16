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
                name: "ProductImages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false),
                    ResourceUrl = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductImages_Products_ProductId",
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
                    { new Guid("021657c8-d4d0-4167-a1a6-b7bb840f33bf"), 0, null, "29d8a2a2-7f33-439b-8c2d-4b844edff675", new DateTime(2024, 5, 16, 15, 48, 3, 231, DateTimeKind.Utc).AddTicks(5977), "user1@gmail.com", false, "Jane Smith", 1, false, true, null, "USER1@GMAIL.COM", "USER1@GMAIL.COM", "AQAAAAIAAYagAAAAEJVaeVNRZaHYvaAm2C+yvtxLZpmcbp/X+RLx7cQgrv8x3rZSsV8IgPSxPGuJXMYJ9A==", null, false, "https://avatarfiles.alphacoders.com/151/thumb-151233.jpg", "876afdf9-9307-4e88-8f7d-5d445ca1b50a", 1, false, new DateTime(2024, 5, 16, 15, 48, 3, 231, DateTimeKind.Utc).AddTicks(5984), "user1@gmail.com" },
                    { new Guid("0cd66cfc-5d48-4f5e-b22d-5fa49234d192"), 0, null, "c069b003-2dd3-46e8-82d0-5fae49738b3f", new DateTime(2024, 5, 16, 15, 48, 5, 7, DateTimeKind.Utc).AddTicks(933), "user16@gmail.com", false, "User 16", 2, false, true, null, "USER16@GMAIL.COM", "USER16@GMAIL.COM", "AQAAAAIAAYagAAAAED2KZQuxEz9X/SP0cdFjyXgqCrkpr9fJ/taUZBH1Q+TR5P3zQ+QUaj5jMDpSUXhL+g==", null, false, "https://avatarfiles.alphacoders.com/151/thumb-151233.jpg", "5072180a-f2f9-4aa7-9856-50ce64000931", 1, false, new DateTime(2024, 5, 16, 15, 48, 5, 7, DateTimeKind.Utc).AddTicks(936), "user16@gmail.com" },
                    { new Guid("1d2b5cf5-0ad7-4c3a-b4b9-5fa49234d202"), 0, null, "29c26204-71c3-4e2c-b476-abdc9cd80bb0", new DateTime(2024, 5, 16, 15, 48, 6, 88, DateTimeKind.Utc).AddTicks(5693), "user26@gmail.com", false, "User 26", 2, false, true, null, "USER26@GMAIL.COM", "USER26@GMAIL.COM", "AQAAAAIAAYagAAAAEIm1Vf9/1u5F6VxqhF+GyTVT3Dx7UaGt89pAjzcchspfsz6Nnkjys05BKAPZJ8WqHw==", null, false, "https://avatarfiles.alphacoders.com/151/thumb-151233.jpg", "68145281-74c4-4d14-978d-793d763482be", 1, false, new DateTime(2024, 5, 16, 15, 48, 6, 88, DateTimeKind.Utc).AddTicks(5695), "user26@gmail.com" },
                    { new Guid("296dbab2-62f2-4eb6-ae53-e4c7fffdaf34"), 0, null, "93f69e3a-728a-436e-98bc-237ae8ae4355", new DateTime(2024, 5, 16, 15, 48, 7, 758, DateTimeKind.Utc).AddTicks(939), "user43@gmail.com", false, "User 43", 2, false, true, null, "USER43@GMAIL.COM", "USER43@GMAIL.COM", "AQAAAAIAAYagAAAAEF9CxTN0Y2OrWWyHdOfX1D8hkHGyDJhGc/j/4qw594mG2DUjG9OF4znbDSvVXrxR7A==", null, false, "https://avatarfiles.alphacoders.com/151/thumb-151233.jpg", "26972e0f-5ea9-49a4-84da-1bc6c9db463a", 1, false, new DateTime(2024, 5, 16, 15, 48, 7, 758, DateTimeKind.Utc).AddTicks(941), "user43@gmail.com" },
                    { new Guid("2b844c01-c89e-4d24-a5d8-5fa49234d198"), 0, null, "a1e1aa09-3321-41eb-a202-348b6ed52e12", new DateTime(2024, 5, 16, 15, 48, 5, 719, DateTimeKind.Utc).AddTicks(6946), "user22@gmail.com", false, "User 22", 2, false, true, null, "USER22@GMAIL.COM", "USER22@GMAIL.COM", "AQAAAAIAAYagAAAAEAUAQvzZ1eOIzmtdWiTbP3mdYtmyJjP7AxafDDIEaHq5Rkbypfjw52o5NsYvtgiWhQ==", null, false, "https://avatarfiles.alphacoders.com/151/thumb-151233.jpg", "f9038fa9-f589-4c92-a34f-e929ed19f0d0", 1, false, new DateTime(2024, 5, 16, 15, 48, 5, 719, DateTimeKind.Utc).AddTicks(6950), "user22@gmail.com" },
                    { new Guid("2c44d375-c725-4279-b2d3-87ea4218f385"), 0, null, "e3735e7d-7d95-4157-a751-5a4a0c1518d9", new DateTime(2024, 5, 16, 15, 48, 6, 451, DateTimeKind.Utc).AddTicks(2668), "user30@gmail.com", false, "User 30", 2, false, true, null, "USER30@GMAIL.COM", "USER30@GMAIL.COM", "AQAAAAIAAYagAAAAEN9lRwW94a15dDlX3+RkZMVjlXfwLENhNFFZtRcBAHoOW4DGElUiop9bvX3dXVDSJQ==", null, false, "https://avatarfiles.alphacoders.com/151/thumb-151233.jpg", "aa9728da-8028-458b-ad69-f8a6dbc35f52", 1, false, new DateTime(2024, 5, 16, 15, 48, 6, 451, DateTimeKind.Utc).AddTicks(2671), "user30@gmail.com" },
                    { new Guid("2c96fabb-f759-43ef-9a31-328c25d2eff5"), 0, null, "1d90a092-eb48-4d0c-aeda-0b61b86c20bf", new DateTime(2024, 5, 16, 15, 48, 3, 414, DateTimeKind.Utc).AddTicks(3717), "user2@gmail.com", false, "Michael Johnson", 2, false, true, null, "USER2@GMAIL.COM", "USER2@GMAIL.COM", "AQAAAAIAAYagAAAAEGzyZujwiCXHu2T9P2nhwbJK5LsvgFd95QbftgaCw19IkTrGz42j5g3rW+wXI2s5ZA==", null, false, "https://avatarfiles.alphacoders.com/151/thumb-151233.jpg", "956984a5-329a-47d0-927e-7fd7b12cdb5a", 1, false, new DateTime(2024, 5, 16, 15, 48, 3, 414, DateTimeKind.Utc).AddTicks(3719), "user2@gmail.com" },
                    { new Guid("2d3d5b2d-b5a3-4b89-84b3-5fa49234d186"), 0, null, "8af5119e-33d1-4287-990b-d9982e944587", new DateTime(2024, 5, 16, 15, 48, 4, 328, DateTimeKind.Utc).AddTicks(2771), "user10@gmail.com", false, "User 10", 2, false, true, null, "USER10@GMAIL.COM", "USER10@GMAIL.COM", "AQAAAAIAAYagAAAAEHa+5aweWPlcPyaczPbjSDxHD0/kspVPmtt2GQ1UVXhCyTXwxToZ1i+1NnM8XPVTEA==", null, false, "https://avatarfiles.alphacoders.com/151/thumb-151233.jpg", "9fadee71-76cd-4015-b116-6d0fdc31c694", 1, false, new DateTime(2024, 5, 16, 15, 48, 4, 328, DateTimeKind.Utc).AddTicks(2773), "user10@gmail.com" },
                    { new Guid("30a4345d-df2e-46ab-8c0e-d38a7933b591"), 0, null, "4dbcf81b-b826-42be-88f9-92850cf07de1", new DateTime(2024, 5, 16, 15, 48, 3, 554, DateTimeKind.Utc).AddTicks(6085), "user3@gmail.com", false, "Emily Davis", 2, false, true, null, "USER3@GMAIL.COM", "USER3@GMAIL.COM", "AQAAAAIAAYagAAAAEHacJbV5lgzZy1t0289Nuy5/6YbwyQunvsM6aw2KzgUcUhTbynpVA4QEjN5LrK6gjQ==", null, false, "https://avatarfiles.alphacoders.com/151/thumb-151233.jpg", "7aa08661-312f-4327-8b3c-b264dc94ba61", 1, false, new DateTime(2024, 5, 16, 15, 48, 3, 554, DateTimeKind.Utc).AddTicks(6087), "user3@gmail.com" },
                    { new Guid("31e7a1a6-9a5d-4b4e-84eb-5fa49234d190"), 0, null, "46e22cfa-994a-4e13-8442-06e75ff25130", new DateTime(2024, 5, 16, 15, 48, 4, 724, DateTimeKind.Utc).AddTicks(2243), "user14@gmail.com", false, "User 14", 2, false, true, null, "USER14@GMAIL.COM", "USER14@GMAIL.COM", "AQAAAAIAAYagAAAAEMZSfc31bVfkmNHuUShZBf7OlBKIV6ZxATom9rkeSXDU8wORJRzy16R73sh8Mjx1nw==", null, false, "https://avatarfiles.alphacoders.com/151/thumb-151233.jpg", "717530dd-bf66-4726-9205-0002fddc1e4c", 1, false, new DateTime(2024, 5, 16, 15, 48, 4, 724, DateTimeKind.Utc).AddTicks(2245), "user14@gmail.com" },
                    { new Guid("35d6cf06-f0ef-47a6-a4bd-5fa49234d196"), 0, null, "60799f45-08f2-4347-a64e-830492b934b4", new DateTime(2024, 5, 16, 15, 48, 5, 480, DateTimeKind.Utc).AddTicks(164), "user20@gmail.com", false, "User 20", 2, false, true, null, "USER20@GMAIL.COM", "USER20@GMAIL.COM", "AQAAAAIAAYagAAAAEBLu4m0mrkjmWDMgDufwLMZ3DKArtswZ5aLf3NUPJd3eyy5A4ygDQDkY/G/ySGmUNw==", null, false, "https://avatarfiles.alphacoders.com/151/thumb-151233.jpg", "c9dbb0b0-ef02-47cd-a4bf-2623b4196995", 1, false, new DateTime(2024, 5, 16, 15, 48, 5, 480, DateTimeKind.Utc).AddTicks(166), "user20@gmail.com" },
                    { new Guid("3d77db7b-3b3e-4a38-a1d1-5fa49234d200"), 0, null, "6583c2dc-849c-456d-9ebc-3c793e060a87", new DateTime(2024, 5, 16, 15, 48, 5, 902, DateTimeKind.Utc).AddTicks(8035), "user24@gmail.com", false, "User 24", 2, false, true, null, "USER24@GMAIL.COM", "USER24@GMAIL.COM", "AQAAAAIAAYagAAAAEHiPTHYNkqUYfuWcAYbK4oFoZHdMYQ0c3+lQ9nCDLDJEkuY0aAn7hOy6jfxo6zEqBA==", null, false, "https://avatarfiles.alphacoders.com/151/thumb-151233.jpg", "7acd2408-b750-476e-83c2-145b4c1f3ed1", 1, false, new DateTime(2024, 5, 16, 15, 48, 5, 902, DateTimeKind.Utc).AddTicks(8037), "user24@gmail.com" },
                    { new Guid("4a8b3d09-78f2-43ad-bce6-5fa49234d189"), 0, null, "02ba10df-82b6-4a61-9175-0251ade4e8af", new DateTime(2024, 5, 16, 15, 48, 4, 634, DateTimeKind.Utc).AddTicks(2476), "user13@gmail.com", false, "User 13", 2, false, true, null, "USER13@GMAIL.COM", "USER13@GMAIL.COM", "AQAAAAIAAYagAAAAEM9Aj8IQfHBqyBdq1ReLSaczKmM4xC3pj3pXqUjl5SEHrbR40oNBMQ0J2Qnkqw16dA==", null, false, "https://avatarfiles.alphacoders.com/151/thumb-151233.jpg", "f2bedd8f-258e-4925-9df4-71bbe50e41e4", 1, false, new DateTime(2024, 5, 16, 15, 48, 4, 634, DateTimeKind.Utc).AddTicks(2479), "user13@gmail.com" },
                    { new Guid("50b95f41-7afa-4cda-aa7a-5fa49234d183"), 0, null, "e9edeab2-8d97-4b16-8d12-0065d2673a84", new DateTime(2024, 5, 16, 15, 48, 4, 20, DateTimeKind.Utc).AddTicks(643), "user7@gmail.com", false, "Lisa Nguyen", 2, false, true, null, "USER7@GMAIL.COM", "USER7@GMAIL.COM", "AQAAAAIAAYagAAAAEGkUmNGjffBO/VYXx9liqxclbfGpbSPk8fvjnICa4muHidK58KoKnyx7+RpmMBi1/Q==", null, false, "https://avatarfiles.alphacoders.com/151/thumb-151233.jpg", "ed552d91-b2dd-4247-9796-d2edee04caea", 1, false, new DateTime(2024, 5, 16, 15, 48, 4, 20, DateTimeKind.Utc).AddTicks(645), "user7@gmail.com" },
                    { new Guid("50b95f41-7afa-4cda-aa7a-5fa49234d184"), 0, null, "d68b83b5-659f-49ab-bd74-328ed814774e", new DateTime(2024, 5, 16, 15, 48, 4, 118, DateTimeKind.Utc).AddTicks(655), "user8@gmail.com", false, "User 8", 2, false, true, null, "USER8@GMAIL.COM", "USER8@GMAIL.COM", "AQAAAAIAAYagAAAAEDFS0d9waiHp4bx/OjXsAwg6CogtaqN0Qrzj5zWHwgGv7xbJ2AdDtu1PNVuS60qBGw==", null, false, "https://avatarfiles.alphacoders.com/151/thumb-151233.jpg", "6d122aa1-8456-498e-8927-a72e909923a2", 1, false, new DateTime(2024, 5, 16, 15, 48, 4, 118, DateTimeKind.Utc).AddTicks(658), "user8@gmail.com" },
                    { new Guid("56b2a1c9-a651-4fee-8f8e-5fa49234d199"), 0, null, "415c9942-88fd-4eb6-9a76-6157b2f5d12d", new DateTime(2024, 5, 16, 15, 48, 5, 810, DateTimeKind.Utc).AddTicks(2301), "user23@gmail.com", false, "User 23", 2, false, true, null, "USER23@GMAIL.COM", "USER23@GMAIL.COM", "AQAAAAIAAYagAAAAEM4C8ZuKnxNBy54uhNuwSkUdt5+DL0cN4IhiLoZW3LhQbCC5bWNJFAsJtaSGpaYMvg==", null, false, "https://avatarfiles.alphacoders.com/151/thumb-151233.jpg", "0671c679-06c7-4a22-893a-17d0654c4766", 1, false, new DateTime(2024, 5, 16, 15, 48, 5, 810, DateTimeKind.Utc).AddTicks(2305), "user23@gmail.com" },
                    { new Guid("594f8fe1-1cf1-4f5a-a8ae-6b9509fbf283"), 0, null, "14e6dee6-71c3-46bc-97cc-374bf518b6ba", new DateTime(2024, 5, 16, 15, 48, 3, 665, DateTimeKind.Utc).AddTicks(3205), "user4@gmail.com", false, "David Lee", 1, false, true, null, "USER4@GMAIL.COM", "USER4@GMAIL.COM", "AQAAAAIAAYagAAAAEC+OaqVQ9ybj+zhlMMTMOO2gKzbxTKa3tkV6IAidU9MBPNwtbM3JbsUBnl3qiJuSfQ==", null, false, "https://avatarfiles.alphacoders.com/151/thumb-151233.jpg", "de190c89-5293-47ae-9bc5-0247dcfece1c", 1, false, new DateTime(2024, 5, 16, 15, 48, 3, 665, DateTimeKind.Utc).AddTicks(3207), "user4@gmail.com" },
                    { new Guid("5aca3775-d37e-473c-8f3a-3926ed32e360"), 0, null, "82499e12-d42a-4ed4-9d4c-5440debeb777", new DateTime(2024, 5, 16, 15, 48, 6, 269, DateTimeKind.Utc).AddTicks(3041), "user28@gmail.com", false, "User 28", 2, false, true, null, "USER28@GMAIL.COM", "USER28@GMAIL.COM", "AQAAAAIAAYagAAAAECawHzVFnwRQdUfUCnYoK9bilGR2z5mRRfrfwLGyQxvUPomlOwstKaSkxBN013+ImA==", null, false, "https://avatarfiles.alphacoders.com/151/thumb-151233.jpg", "452b40b4-28b9-40e6-8001-6361adc1778d", 1, false, new DateTime(2024, 5, 16, 15, 48, 6, 269, DateTimeKind.Utc).AddTicks(3044), "user28@gmail.com" },
                    { new Guid("5c6a5f5e-3a11-4d42-bff8-5fa49234d188"), 0, null, "6b1bf79a-7c1e-4f12-b8f4-ec46c3950909", new DateTime(2024, 5, 16, 15, 48, 4, 544, DateTimeKind.Utc).AddTicks(5574), "user12@gmail.com", false, "User 12", 2, false, true, null, "USER12@GMAIL.COM", "USER12@GMAIL.COM", "AQAAAAIAAYagAAAAEDDLn1ute7Bq/f85z7U1Q1wLJwi5FdgIMlkr4wyY/hE5ZuxEfGXvUoPhrPmVuSMtdg==", null, false, "https://avatarfiles.alphacoders.com/151/thumb-151233.jpg", "3a4cf827-ec39-49e4-b120-66d2c1cbae87", 1, false, new DateTime(2024, 5, 16, 15, 48, 4, 544, DateTimeKind.Utc).AddTicks(5577), "user12@gmail.com" },
                    { new Guid("60a119e1-610c-42fc-85c8-95a7e4d2119b"), 0, null, "1284da79-cbba-4744-acbe-f7bb50d7ed66", new DateTime(2024, 5, 16, 15, 48, 7, 561, DateTimeKind.Utc).AddTicks(985), "user41@gmail.com", false, "User 41", 2, false, true, null, "USER41@GMAIL.COM", "USER41@GMAIL.COM", "AQAAAAIAAYagAAAAEC/SnudtWiZzv84EO1StN833Gga2FdrX8ntX6DCzzA4oh4+ko0/b7sMI0O3j4taC5A==", null, false, "https://avatarfiles.alphacoders.com/151/thumb-151233.jpg", "92e5aad3-d685-4e18-842d-e569148dadf4", 1, false, new DateTime(2024, 5, 16, 15, 48, 7, 561, DateTimeKind.Utc).AddTicks(988), "user41@gmail.com" },
                    { new Guid("60b9f0cc-b3b4-4ac3-a9ce-5fa49234d193"), 0, null, "655cdccb-82d7-4992-8337-d0065b93cb86", new DateTime(2024, 5, 16, 15, 48, 5, 122, DateTimeKind.Utc).AddTicks(3871), "user17@gmail.com", false, "User 17", 2, false, true, null, "USER17@GMAIL.COM", "USER17@GMAIL.COM", "AQAAAAIAAYagAAAAEMi3E09XUX0lBKaItMDfEqhLVPgzGEPfNsazZrJ7iMO1YOKwBwaG4UXQGVib3Ns+mQ==", null, false, "https://avatarfiles.alphacoders.com/151/thumb-151233.jpg", "a0216501-31a8-4b8b-a266-3e0effedd823", 1, false, new DateTime(2024, 5, 16, 15, 48, 5, 122, DateTimeKind.Utc).AddTicks(3874), "user17@gmail.com" },
                    { new Guid("6c16a235-f928-4b8d-978f-5fa49234d194"), 0, null, "bea3d00a-2c2d-4fa8-95ce-d83b9fdb427b", new DateTime(2024, 5, 16, 15, 48, 5, 257, DateTimeKind.Utc).AddTicks(5599), "user18@gmail.com", false, "User 18", 2, false, true, null, "USER18@GMAIL.COM", "USER18@GMAIL.COM", "AQAAAAIAAYagAAAAEA2ZcZ96RWOap1vcrmfuIaWpRHV5Obt0cw1FxnGefS0tWXHS6+PRlJgLvQWsGyohog==", null, false, "https://avatarfiles.alphacoders.com/151/thumb-151233.jpg", "5b99efb2-cb3e-4019-a512-3e33518b1d22", 1, false, new DateTime(2024, 5, 16, 15, 48, 5, 257, DateTimeKind.Utc).AddTicks(5601), "user18@gmail.com" },
                    { new Guid("6e2f7a2d-1994-419b-8c6d-b3d297cd7b06"), 0, null, "928bf84d-09ef-4c75-9b6f-0f786fa95bd3", new DateTime(2024, 5, 16, 15, 48, 7, 324, DateTimeKind.Utc).AddTicks(4796), "user39@gmail.com", false, "User 39", 2, false, true, null, "USER39@GMAIL.COM", "USER39@GMAIL.COM", "AQAAAAIAAYagAAAAECU2jCWqzJhl7LRGhaDjubQ4QL31P2+62iVTQ/75XyhUJD89LYUdX4/NMUyOqA2Leg==", null, false, "https://avatarfiles.alphacoders.com/151/thumb-151233.jpg", "f12d492a-c000-4434-9d6a-dd09952beadc", 1, false, new DateTime(2024, 5, 16, 15, 48, 7, 324, DateTimeKind.Utc).AddTicks(4800), "user39@gmail.com" },
                    { new Guid("7db124bd-9953-4eb0-98f2-50b1be635544"), 0, null, "775c41f4-b4aa-40a0-99e1-2f1bd8e26a1a", new DateTime(2024, 5, 16, 15, 48, 3, 905, DateTimeKind.Utc).AddTicks(3956), "user6@gmail.com", false, "Robert Patel", 1, false, true, null, "USER6@GMAIL.COM", "USER6@GMAIL.COM", "AQAAAAIAAYagAAAAEAcPyvP5m3xHxIlowAONmVwUYkbdYVq1MgZdTJmNEepEaIVT3IHWU14TWNbOgzpkjA==", null, false, "https://avatarfiles.alphacoders.com/151/thumb-151233.jpg", "f5a4bcf9-3509-41b3-9810-ba8b13d5c50f", 1, false, new DateTime(2024, 5, 16, 15, 48, 3, 905, DateTimeKind.Utc).AddTicks(3959), "user6@gmail.com" },
                    { new Guid("853988db-ad55-4a28-9782-90438c64b62d"), 0, null, "fbc3664c-5735-4152-93b8-39e3c410939b", new DateTime(2024, 5, 16, 15, 48, 7, 451, DateTimeKind.Utc).AddTicks(5707), "user40@gmail.com", false, "User 40", 2, false, true, null, "USER40@GMAIL.COM", "USER40@GMAIL.COM", "AQAAAAIAAYagAAAAEEy+E95fDNK6Sqcqkp075DbvJQSx9Ee9Hi+kWXlwi+70Vj9Ed5qXueiCSjOVCSzN8g==", null, false, "https://avatarfiles.alphacoders.com/151/thumb-151233.jpg", "3e8ab264-79e7-447e-8b0a-d9c5e6c0d755", 1, false, new DateTime(2024, 5, 16, 15, 48, 7, 451, DateTimeKind.Utc).AddTicks(5711), "user40@gmail.com" },
                    { new Guid("85d8a27f-9d32-4269-b5d0-844589d498d0"), 0, null, "d4525dc2-4678-4fce-83fa-4c95a0619aa2", new DateTime(2024, 5, 16, 15, 48, 3, 58, DateTimeKind.Utc).AddTicks(6179), "admin@gmail.com", false, "John Doe", 1, false, true, null, "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAIAAYagAAAAENgi98+4PbHl9Ac2kd9p7XFJScTFZCnRD8u409IHvSEDQuJUYU1GcJcUWqU6g9eI7g==", null, false, "https://avatarfiles.alphacoders.com/151/thumb-151233.jpg", "5e1df2ed-5c9e-4cf0-af92-b66a23719cca", 1, false, new DateTime(2024, 5, 16, 15, 48, 3, 58, DateTimeKind.Utc).AddTicks(6182), "admin@gmail.com" },
                    { new Guid("870559eb-5fde-4764-ade7-392b0cf6b5ce"), 0, null, "c5e318f1-e001-419b-b423-4ed42f0f0e5a", new DateTime(2024, 5, 16, 15, 48, 7, 664, DateTimeKind.Utc).AddTicks(1434), "user42@gmail.com", false, "User 42", 2, false, true, null, "USER42@GMAIL.COM", "USER42@GMAIL.COM", "AQAAAAIAAYagAAAAEJJe7N0R+WJ4mEDqBp0YOmXo/3go/GLHbGpJ3VcfwIFQQJogiqdhnwCdzMjsd6i55A==", null, false, "https://avatarfiles.alphacoders.com/151/thumb-151233.jpg", "11ad84c7-e8fc-4201-bdc6-a5500633554c", 1, false, new DateTime(2024, 5, 16, 15, 48, 7, 664, DateTimeKind.Utc).AddTicks(1437), "user42@gmail.com" },
                    { new Guid("87787f6e-729b-436b-bcc9-c7b48c45ba05"), 0, null, "c4e374e8-156b-4333-822b-1683d3dadf1c", new DateTime(2024, 5, 16, 15, 48, 6, 817, DateTimeKind.Utc).AddTicks(9713), "user34@gmail.com", false, "User 34", 2, false, true, null, "USER34@GMAIL.COM", "USER34@GMAIL.COM", "AQAAAAIAAYagAAAAELjWDXGVK3d9lyhCiQ88oDGBvbGyZwZgf2F/zRmr2M1oBDxQQHAHLqR4lIYOgR3zYQ==", null, false, "https://avatarfiles.alphacoders.com/151/thumb-151233.jpg", "c52f8082-ad21-4a3b-9bc3-292ccca5789c", 1, false, new DateTime(2024, 5, 16, 15, 48, 6, 817, DateTimeKind.Utc).AddTicks(9716), "user34@gmail.com" },
                    { new Guid("8c3b46b9-1321-4d97-a193-5fa49234d185"), 0, null, "6a48f788-4b4b-4c6c-943f-caaf9155c5dc", new DateTime(2024, 5, 16, 15, 48, 4, 220, DateTimeKind.Utc).AddTicks(579), "user9@gmail.com", false, "User 9", 2, false, true, null, "USER9@GMAIL.COM", "USER9@GMAIL.COM", "AQAAAAIAAYagAAAAEFfhhdl/TtzbDHOpbPLI4SzjR5jy6679gPyFrs6DrV5OlLSn1M8aQiIL6JbY65+gfQ==", null, false, "https://avatarfiles.alphacoders.com/151/thumb-151233.jpg", "de5086fb-6e48-4848-9a11-f3e5352644bb", 1, false, new DateTime(2024, 5, 16, 15, 48, 4, 220, DateTimeKind.Utc).AddTicks(581), "user9@gmail.com" },
                    { new Guid("906f192a-96d3-433a-a7ea-288662b5f62d"), 0, null, "92cde726-80bd-4f55-8676-e2bc72f74597", new DateTime(2024, 5, 16, 15, 48, 6, 542, DateTimeKind.Utc).AddTicks(7518), "user31@gmail.com", false, "User 31", 2, false, true, null, "USER31@GMAIL.COM", "USER31@GMAIL.COM", "AQAAAAIAAYagAAAAEKsXEd6I1kLX83GPqYLQC7TSTsf006TdPXJlg3c7F88m33lydiTKd+OlMPKzSoRoQA==", null, false, "https://avatarfiles.alphacoders.com/151/thumb-151233.jpg", "5a46d429-66af-4dc5-89c2-9a7a0dfcef60", 1, false, new DateTime(2024, 5, 16, 15, 48, 6, 542, DateTimeKind.Utc).AddTicks(7520), "user31@gmail.com" },
                    { new Guid("91d0da1b-e147-4829-aa4e-7073c1a10d2c"), 0, null, "1bf808d8-58ff-4e38-b509-d06b3e7cb3dc", new DateTime(2024, 5, 16, 15, 48, 7, 8, DateTimeKind.Utc).AddTicks(8212), "user36@gmail.com", false, "User 36", 2, false, true, null, "USER36@GMAIL.COM", "USER36@GMAIL.COM", "AQAAAAIAAYagAAAAELHJoAlPGJU3DA+bU9lLbn8C44bjGHHvJ5AOePQ3AEoiB7HRnFJ083jN6MAd6hWoaA==", null, false, "https://avatarfiles.alphacoders.com/151/thumb-151233.jpg", "1272636b-e948-4870-ace0-eed8bf91568a", 1, false, new DateTime(2024, 5, 16, 15, 48, 7, 8, DateTimeKind.Utc).AddTicks(8216), "user36@gmail.com" },
                    { new Guid("9a4a34a4-4b12-4c8e-a52b-5fa49234d195"), 0, null, "19e5ce52-aa68-4ecf-82ef-9e53d596a85d", new DateTime(2024, 5, 16, 15, 48, 5, 364, DateTimeKind.Utc).AddTicks(2273), "user19@gmail.com", false, "User 19", 2, false, true, null, "USER19@GMAIL.COM", "USER19@GMAIL.COM", "AQAAAAIAAYagAAAAEOrTm9ZAeNY3zYAKZHTCRe6u4zOD4wFfJz45bz4si2ol6+ELBR5jtAKn3da1jXEHbQ==", null, false, "https://avatarfiles.alphacoders.com/151/thumb-151233.jpg", "23f34e2f-c788-4d95-84ca-00fdda16d5bb", 1, false, new DateTime(2024, 5, 16, 15, 48, 5, 364, DateTimeKind.Utc).AddTicks(2275), "user19@gmail.com" },
                    { new Guid("9b8c6d7b-754f-420c-b574-4a63326bfc6a"), 0, null, "e477ef6b-1a27-473b-8959-e73449937ca0", new DateTime(2024, 5, 16, 15, 48, 7, 232, DateTimeKind.Utc).AddTicks(1958), "user38@gmail.com", false, "User 38", 2, false, true, null, "USER38@GMAIL.COM", "USER38@GMAIL.COM", "AQAAAAIAAYagAAAAEIt8JDZRhjnfZqxSme33X9jHJ6d4JDoJVlCtHxooTRtIsKLgvMM/GXK5zei908PFfA==", null, false, "https://avatarfiles.alphacoders.com/151/thumb-151233.jpg", "76d5cad8-4d3d-4daf-8df4-8771896c6d99", 1, false, new DateTime(2024, 5, 16, 15, 48, 7, 232, DateTimeKind.Utc).AddTicks(1962), "user38@gmail.com" },
                    { new Guid("9d36fef6-9c75-4f96-a951-5fa49234d203"), 0, null, "f8d00561-4c5f-4fa8-a246-dd466efb5335", new DateTime(2024, 5, 16, 15, 48, 6, 178, DateTimeKind.Utc).AddTicks(753), "user27@gmail.com", false, "User 27", 2, false, true, null, "USER27@GMAIL.COM", "USER27@GMAIL.COM", "AQAAAAIAAYagAAAAEI7vwMd7u6Iv8n6BkaLAwm3pr94pbRLgkI9lQC5FFM10Ns31Zl9AAilLIibRzxFwXA==", null, false, "https://avatarfiles.alphacoders.com/151/thumb-151233.jpg", "458bb361-e96e-4fd9-8c67-04f1f2bfc447", 1, false, new DateTime(2024, 5, 16, 15, 48, 6, 178, DateTimeKind.Utc).AddTicks(758), "user27@gmail.com" },
                    { new Guid("b2687ce8-aad5-4d5f-849b-dcd2b402aff0"), 0, null, "b246b77d-95d1-415c-a600-8610ad62fe96", new DateTime(2024, 5, 16, 15, 48, 7, 849, DateTimeKind.Utc).AddTicks(961), "user44@gmail.com", false, "User 44", 2, false, true, null, "USER44@GMAIL.COM", "USER44@GMAIL.COM", "AQAAAAIAAYagAAAAEBzCXOPDTEcs2GuqO7cDmCZA/QDdGFdbE2klIzAwfQjMaI1tjZuNlpQn92n6eXKJ/A==", null, false, "https://avatarfiles.alphacoders.com/151/thumb-151233.jpg", "38e453f2-6134-43b2-98f2-7dec6ef788ce", 1, false, new DateTime(2024, 5, 16, 15, 48, 7, 849, DateTimeKind.Utc).AddTicks(963), "user44@gmail.com" },
                    { new Guid("b6123f4e-3443-41ae-a1cb-5fa49234d187"), 0, null, "566b359d-685e-4300-a864-83c1bb10f0a9", new DateTime(2024, 5, 16, 15, 48, 4, 449, DateTimeKind.Utc).AddTicks(1672), "user11@gmail.com", false, "User 11", 2, false, true, null, "USER11@GMAIL.COM", "USER11@GMAIL.COM", "AQAAAAIAAYagAAAAEHyd5Yc1J1IHVG6pNw67oGk1UZtYK4ftlg3lzJgwQEykDtgvXbghHb/+GPcnjuTMyQ==", null, false, "https://avatarfiles.alphacoders.com/151/thumb-151233.jpg", "73a9073c-6bf7-4d77-bcdb-b716e62c7ed7", 1, false, new DateTime(2024, 5, 16, 15, 48, 4, 449, DateTimeKind.Utc).AddTicks(1675), "user11@gmail.com" },
                    { new Guid("c0a7e4f4-d8d0-4c80-8e1c-5fa49234d201"), 0, null, "b370bacc-4f47-4507-ab33-591a1116e358", new DateTime(2024, 5, 16, 15, 48, 5, 992, DateTimeKind.Utc).AddTicks(8464), "user25@gmail.com", false, "User 25", 2, false, true, null, "USER25@GMAIL.COM", "USER25@GMAIL.COM", "AQAAAAIAAYagAAAAEGgZZKTkACpPxuFY9azL2vsdWpY0TeZd53DJmFfbF/gAuLGW85Vhf53geKrKT5pHbw==", null, false, "https://avatarfiles.alphacoders.com/151/thumb-151233.jpg", "f84308fa-daa6-4da7-8c2f-05befcd9048f", 1, false, new DateTime(2024, 5, 16, 15, 48, 5, 992, DateTimeKind.Utc).AddTicks(8466), "user25@gmail.com" },
                    { new Guid("c55cdfd0-d1dd-4841-ae27-f2d621686756"), 0, null, "ec0211d3-e5ef-46a7-9b16-8ff750fd7772", new DateTime(2024, 5, 16, 15, 48, 6, 633, DateTimeKind.Utc).AddTicks(4841), "user32@gmail.com", false, "User 32", 2, false, true, null, "USER32@GMAIL.COM", "USER32@GMAIL.COM", "AQAAAAIAAYagAAAAEH+rhr8CPrnpjy9F72x7LfZMwF+ZXF9kypT90xSflqAUZ/+8spGJs5+2ZYwNtMIAfQ==", null, false, "https://avatarfiles.alphacoders.com/151/thumb-151233.jpg", "97db90c9-08c1-43b8-a37b-f5a8c01d0bfc", 1, false, new DateTime(2024, 5, 16, 15, 48, 6, 633, DateTimeKind.Utc).AddTicks(4844), "user32@gmail.com" },
                    { new Guid("d0e03a1a-21c2-4123-a75e-5fa49234d191"), 0, null, "bd521b7c-9104-4ac8-ac6b-ee9c7224f5a7", new DateTime(2024, 5, 16, 15, 48, 4, 838, DateTimeKind.Utc).AddTicks(3232), "user15@gmail.com", false, "User 15", 2, false, true, null, "USER15@GMAIL.COM", "USER15@GMAIL.COM", "AQAAAAIAAYagAAAAEMV8PwfC4zhL5kpI943qDeRtZQhbyesugYzHPijbdbbc2h23B87imZynEX8sDgK/CA==", null, false, "https://avatarfiles.alphacoders.com/151/thumb-151233.jpg", "9d3eaab7-d021-4f92-8114-f4120f42ec3e", 1, false, new DateTime(2024, 5, 16, 15, 48, 4, 838, DateTimeKind.Utc).AddTicks(3235), "user15@gmail.com" },
                    { new Guid("d30fa796-5144-4467-a302-68dc64fd0d92"), 0, null, "cdb68856-8cd4-4366-ab90-e8ca0ad32ec8", new DateTime(2024, 5, 16, 15, 48, 6, 907, DateTimeKind.Utc).AddTicks(4450), "user35@gmail.com", false, "User 35", 2, false, true, null, "USER35@GMAIL.COM", "USER35@GMAIL.COM", "AQAAAAIAAYagAAAAEH15TGoSdZnI5Stx8tEo1QyYbvIaOVwGs/TJ6E0VyTaNIZJjr2ouM1WC+vfFUkMw6Q==", null, false, "https://avatarfiles.alphacoders.com/151/thumb-151233.jpg", "61e83ebe-4a5c-4de0-99ed-3f738ea24586", 1, false, new DateTime(2024, 5, 16, 15, 48, 6, 907, DateTimeKind.Utc).AddTicks(4453), "user35@gmail.com" },
                    { new Guid("e92c6f32-859b-443b-bfb2-bd0674b5673a"), 0, null, "e6970246-6105-4a9e-8128-9969500a608f", new DateTime(2024, 5, 16, 15, 48, 6, 359, DateTimeKind.Utc).AddTicks(3974), "user29@gmail.com", false, "User 29", 2, false, true, null, "USER29@GMAIL.COM", "USER29@GMAIL.COM", "AQAAAAIAAYagAAAAEGfkHP8gRe4VPlidzPz6ljI9EtSPwwYbsJAL73+qOjfPnm1xbOnshgPulHKI7dJyQA==", null, false, "https://avatarfiles.alphacoders.com/151/thumb-151233.jpg", "95bec683-e62e-46da-a2bf-3c6829c72c55", 1, false, new DateTime(2024, 5, 16, 15, 48, 6, 359, DateTimeKind.Utc).AddTicks(3977), "user29@gmail.com" },
                    { new Guid("eee6e626-9a26-4f38-bbe3-433d20440ce9"), 0, null, "3d8d9ce5-ce87-4cab-97f7-f60bb9fe818c", new DateTime(2024, 5, 16, 15, 48, 3, 780, DateTimeKind.Utc).AddTicks(2838), "user5@gmail.com", false, "Sarah Kim", 2, false, true, null, "USER5@GMAIL.COM", "USER5@GMAIL.COM", "AQAAAAIAAYagAAAAEEmTILrSv54pBbi22x5qJiNyXzYpASHD7241irl+OZIINo1HKDE5cMqL+rKSl1Bqmw==", null, false, "https://avatarfiles.alphacoders.com/151/thumb-151233.jpg", "c9b4d607-859d-48d6-bf12-1936caf50e3a", 1, false, new DateTime(2024, 5, 16, 15, 48, 3, 780, DateTimeKind.Utc).AddTicks(2843), "user5@gmail.com" },
                    { new Guid("eeed5a4d-e83d-4032-8c3c-5fa49234d197"), 0, null, "96f5a266-9a14-401a-8ddb-875d57b18c93", new DateTime(2024, 5, 16, 15, 48, 5, 593, DateTimeKind.Utc).AddTicks(7666), "user21@gmail.com", false, "User 21", 2, false, true, null, "USER21@GMAIL.COM", "USER21@GMAIL.COM", "AQAAAAIAAYagAAAAEP4jIyGlcZsUY8jUCRoINVIuMdPhAV/HJ1kjpTVq3jvvquy94vgsd7x97d/pckAe9g==", null, false, "https://avatarfiles.alphacoders.com/151/thumb-151233.jpg", "afd31cb1-2755-4558-a7ea-458ab0bf28a8", 1, false, new DateTime(2024, 5, 16, 15, 48, 5, 593, DateTimeKind.Utc).AddTicks(7669), "user21@gmail.com" },
                    { new Guid("f483fb9f-477c-4a3a-9f73-3b028b06ed49"), 0, null, "5189ea3a-8db5-440b-8295-613f840b9da5", new DateTime(2024, 5, 16, 15, 48, 6, 722, DateTimeKind.Utc).AddTicks(3962), "user33@gmail.com", false, "User 33", 2, false, true, null, "USER33@GMAIL.COM", "USER33@GMAIL.COM", "AQAAAAIAAYagAAAAENIzpEumGsdQhvCB6fZ2eqLyAWKwJpL5OmoFsu+YE6Imwd++8L4ji05VBeIDV9h5wA==", null, false, "https://avatarfiles.alphacoders.com/151/thumb-151233.jpg", "35281935-d299-4242-aa07-d42b2d4086e3", 1, false, new DateTime(2024, 5, 16, 15, 48, 6, 722, DateTimeKind.Utc).AddTicks(3964), "user33@gmail.com" },
                    { new Guid("fbd62259-a313-4d38-885e-1f6acdf9a30a"), 0, null, "3fd4d310-365d-4e5a-a105-81cf026e185e", new DateTime(2024, 5, 16, 15, 48, 7, 122, DateTimeKind.Utc).AddTicks(4150), "user37@gmail.com", false, "User 37", 2, false, true, null, "USER37@GMAIL.COM", "USER37@GMAIL.COM", "AQAAAAIAAYagAAAAEDLXPBlwGsthY3XoZbBs6HyjYOtatTBtLIXdqDkhEDpYGRxiirK4XcDdi3aCQS5SxA==", null, false, "https://avatarfiles.alphacoders.com/151/thumb-151233.jpg", "7e4c8eef-0b68-4680-aad6-2da2362e6545", 1, false, new DateTime(2024, 5, 16, 15, 48, 7, 122, DateTimeKind.Utc).AddTicks(4153), "user37@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "ProductCategories",
                columns: new[] { "Id", "CreatedDateTime", "Description", "Name", "UpdatedDateTime" },
                values: new object[,]
                {
                    { new Guid("292c90a5-1a0a-45a4-8f3d-37f09b09b422"), new DateTime(2024, 5, 16, 15, 48, 7, 954, DateTimeKind.Utc).AddTicks(7323), null, "History", new DateTime(2024, 5, 16, 15, 48, 7, 954, DateTimeKind.Utc).AddTicks(7323) },
                    { new Guid("2baf4c50-c927-4b54-971e-3ff5f300e147"), new DateTime(2024, 5, 16, 15, 48, 7, 954, DateTimeKind.Utc).AddTicks(7307), null, "Romance", new DateTime(2024, 5, 16, 15, 48, 7, 954, DateTimeKind.Utc).AddTicks(7309) },
                    { new Guid("97cf6bd7-7290-449a-a61d-5ea2fdfcf8de"), new DateTime(2024, 5, 16, 15, 48, 7, 954, DateTimeKind.Utc).AddTicks(7325), null, "Education and Teacher", new DateTime(2024, 5, 16, 15, 48, 7, 954, DateTimeKind.Utc).AddTicks(7326) },
                    { new Guid("99ada3c1-eea5-4431-a529-b3114de224da"), new DateTime(2024, 5, 16, 15, 48, 7, 954, DateTimeKind.Utc).AddTicks(7317), null, "Economic", new DateTime(2024, 5, 16, 15, 48, 7, 954, DateTimeKind.Utc).AddTicks(7318) },
                    { new Guid("adf36edc-3e08-4a36-8e20-0d79747f0962"), new DateTime(2024, 5, 16, 15, 48, 7, 954, DateTimeKind.Utc).AddTicks(7320), null, "Business and Money", new DateTime(2024, 5, 16, 15, 48, 7, 954, DateTimeKind.Utc).AddTicks(7321) }
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

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "AuthorName", "AvgRate", "CategoryId", "CreatedDateTime", "DateOfPublication", "Description", "IsDelete", "Name", "NumberOfPage", "NumberOfSale", "Price", "ProductThumbUrl", "Publisher", "Quantity", "Sku", "Status", "UpdatedDateTime" },
                values: new object[,]
                {
                    { new Guid("9243d741-a350-4067-bb29-395e9becf57e"), "Michael Goodwin", null, new Guid("99ada3c1-eea5-4431-a529-b3114de224da"), new DateTime(2024, 5, 16, 15, 48, 7, 956, DateTimeKind.Utc).AddTicks(9243), null, null, false, "Economix", 310, 0, 10m, "https://bizweb.dktcdn.net/thumb/1024x1024/100/363/455/products/economix01.jpg?v=1705552583773", null, 1000, "9243d741-a350-4067-bb29-395e9becf57e", 1, null },
                    { new Guid("e21f3a87-20d5-420e-ba33-9108df996747"), "Malcolm Gladwell", null, new Guid("99ada3c1-eea5-4431-a529-b3114de224da"), new DateTime(2024, 5, 16, 15, 48, 7, 956, DateTimeKind.Utc).AddTicks(9361), null, null, false, "Outliers", 416, 0, 10m, "https://bizweb.dktcdn.net/thumb/large/100/197/269/products/nhung-ke-xuat-chung.jpg?v=1526893051653", null, 1000, "e21f3a87-20d5-420e-ba33-9108df996747", 1, null }
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
                name: "IX_ProductImages_Order_ProductId",
                table: "ProductImages",
                columns: new[] { "Order", "ProductId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductImages_ProductId",
                table: "ProductImages",
                column: "ProductId");

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
                name: "ProductImages");

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
