using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Shoppy.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitProductCategoryData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "AvgRate",
                table: "Products",
                type: "decimal(2,1)",
                precision: 2,
                scale: 1,
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(2,1)",
                oldPrecision: 2,
                oldScale: 1);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("021657c8-d4d0-4167-a1a6-b7bb840f33bf"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "IsDelete", "PasswordHash", "SecurityStamp", "UpdatedDateTime" },
                values: new object[] { "a5701e6e-0c0a-4b0a-8642-ba9aeddf14fa", new DateTime(2024, 5, 15, 10, 35, 20, 784, DateTimeKind.Utc).AddTicks(977), false, "AQAAAAIAAYagAAAAEOM/mRz/EuRskrYsRbDJaWdiXRT/ZCCkgwyEwAbyqWhFF/q/Q/enIx/BXNKEA6M6Kw==", "1ed64a3f-d8fb-4f45-b5de-afff0b9e62a1", new DateTime(2024, 5, 15, 10, 35, 20, 784, DateTimeKind.Utc).AddTicks(981) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("2c96fabb-f759-43ef-9a31-328c25d2eff5"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "IsDelete", "PasswordHash", "SecurityStamp", "UpdatedDateTime" },
                values: new object[] { "9afb5650-b019-41d7-b075-5d77981ce08d", new DateTime(2024, 5, 15, 10, 35, 20, 890, DateTimeKind.Utc).AddTicks(9956), false, "AQAAAAIAAYagAAAAEG4dEHbaathqbxd3sc9+mY5Z6Mn1H7KhYw4LSVwOyckW4umQupPwYZaxC78Nm2/Rvw==", "395d00a7-5585-4f49-a6fb-a1aaa2e75a00", new DateTime(2024, 5, 15, 10, 35, 20, 890, DateTimeKind.Utc).AddTicks(9962) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("30a4345d-df2e-46ab-8c0e-d38a7933b591"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "IsDelete", "PasswordHash", "SecurityStamp", "UpdatedDateTime" },
                values: new object[] { "1ae5018f-10ec-4b3d-9028-de59c2abf525", new DateTime(2024, 5, 15, 10, 35, 21, 30, DateTimeKind.Utc).AddTicks(402), false, "AQAAAAIAAYagAAAAEHAMRrLIURuM53dui7uQ1bP1jXfnvPbaGzA6dyiiYRkIiZTRTmlgQmFMsZhokErg/A==", "41d2646a-d178-4f65-adc1-e7ae81c0a028", new DateTime(2024, 5, 15, 10, 35, 21, 30, DateTimeKind.Utc).AddTicks(407) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("594f8fe1-1cf1-4f5a-a8ae-6b9509fbf283"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "IsDelete", "PasswordHash", "SecurityStamp", "UpdatedDateTime" },
                values: new object[] { "2ee6ee6d-5de5-4db4-8426-b0a6996ce3a3", new DateTime(2024, 5, 15, 10, 35, 21, 168, DateTimeKind.Utc).AddTicks(8992), false, "AQAAAAIAAYagAAAAEFQeOb4AuS64C3DOMDdUH4eTs//5/uADbV+SaBPgFVrESI/TK0oSXG52DG+BMwhkXg==", "cdb5c0ee-3f31-4815-af6e-05c7a9ce45d9", new DateTime(2024, 5, 15, 10, 35, 21, 168, DateTimeKind.Utc).AddTicks(8996) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("85d8a27f-9d32-4269-b5d0-844589d498d0"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "IsDelete", "PasswordHash", "SecurityStamp", "UpdatedDateTime" },
                values: new object[] { "bf418e62-48cf-4d81-b90e-54fed7def290", new DateTime(2024, 5, 15, 10, 35, 20, 686, DateTimeKind.Utc).AddTicks(4443), false, "AQAAAAIAAYagAAAAED4zz3yyFktpu9eoMNaGI6oU9Y+DO97A49/gismetztX+zcc54az62OivgUmVQoXKw==", "3cd987e8-d316-472a-8ae7-096c8ee4b9da", new DateTime(2024, 5, 15, 10, 35, 20, 686, DateTimeKind.Utc).AddTicks(4446) });

            migrationBuilder.InsertData(
                table: "ProductCategories",
                columns: new[] { "Id", "CreatedDateTime", "Description", "Name", "UpdatedDateTime" },
                values: new object[,]
                {
                    { new Guid("292c90a5-1a0a-45a4-8f3d-37f09b09b422"), new DateTime(2024, 5, 15, 10, 35, 21, 312, DateTimeKind.Utc).AddTicks(9093), null, "History", new DateTime(2024, 5, 15, 10, 35, 21, 312, DateTimeKind.Utc).AddTicks(9094) },
                    { new Guid("2baf4c50-c927-4b54-971e-3ff5f300e147"), new DateTime(2024, 5, 15, 10, 35, 21, 312, DateTimeKind.Utc).AddTicks(9069), null, "Romance", new DateTime(2024, 5, 15, 10, 35, 21, 312, DateTimeKind.Utc).AddTicks(9073) },
                    { new Guid("97cf6bd7-7290-449a-a61d-5ea2fdfcf8de"), new DateTime(2024, 5, 15, 10, 35, 21, 312, DateTimeKind.Utc).AddTicks(9096), null, "Education and Teacher", new DateTime(2024, 5, 15, 10, 35, 21, 312, DateTimeKind.Utc).AddTicks(9097) },
                    { new Guid("99ada3c1-eea5-4431-a529-b3114de224da"), new DateTime(2024, 5, 15, 10, 35, 21, 312, DateTimeKind.Utc).AddTicks(9086), null, "Economic", new DateTime(2024, 5, 15, 10, 35, 21, 312, DateTimeKind.Utc).AddTicks(9087) },
                    { new Guid("adf36edc-3e08-4a36-8e20-0d79747f0962"), new DateTime(2024, 5, 15, 10, 35, 21, 312, DateTimeKind.Utc).AddTicks(9091), null, "Business and Money", new DateTime(2024, 5, 15, 10, 35, 21, 312, DateTimeKind.Utc).AddTicks(9091) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_IsDelete",
                table: "Products",
                column: "IsDelete");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_FullName",
                table: "AspNetUsers",
                column: "FullName");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_Gender",
                table: "AspNetUsers",
                column: "Gender");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_IsDelete",
                table: "AspNetUsers",
                column: "IsDelete");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Products_IsDelete",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_FullName",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_Gender",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_IsDelete",
                table: "AspNetUsers");

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: new Guid("292c90a5-1a0a-45a4-8f3d-37f09b09b422"));

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: new Guid("2baf4c50-c927-4b54-971e-3ff5f300e147"));

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: new Guid("97cf6bd7-7290-449a-a61d-5ea2fdfcf8de"));

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: new Guid("99ada3c1-eea5-4431-a529-b3114de224da"));

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: new Guid("adf36edc-3e08-4a36-8e20-0d79747f0962"));

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<decimal>(
                name: "AvgRate",
                table: "Products",
                type: "decimal(2,1)",
                precision: 2,
                scale: 1,
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(2,1)",
                oldPrecision: 2,
                oldScale: 1,
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("021657c8-d4d0-4167-a1a6-b7bb840f33bf"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash", "SecurityStamp", "UpdatedDateTime" },
                values: new object[] { "71cb5ed2-45c4-45ca-8a95-5ad8f7a8aab7", new DateTime(2024, 5, 15, 7, 7, 3, 186, DateTimeKind.Utc).AddTicks(3833), "AQAAAAIAAYagAAAAEF2Flm4yKX1De+RKxI4BbwQ+U2+6+0IXUHH2Y94hUPTwXHSyZgmRNJaPQliQa2289g==", "dfbb15fa-24e3-4633-ad8a-d3dec8cf58a9", new DateTime(2024, 5, 15, 7, 7, 3, 186, DateTimeKind.Utc).AddTicks(3836) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("2c96fabb-f759-43ef-9a31-328c25d2eff5"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash", "SecurityStamp", "UpdatedDateTime" },
                values: new object[] { "14b08047-628a-4fb3-bb64-20de4bf05a4e", new DateTime(2024, 5, 15, 7, 7, 3, 319, DateTimeKind.Utc).AddTicks(152), "AQAAAAIAAYagAAAAECCQMRpgGmXfKScEp5RArMXCLootpvhs+bh0CdJqLARM80NmgmMbxPuPLUzan6BOGA==", "1ec97943-c4ae-43ba-9b9f-56168f50d937", new DateTime(2024, 5, 15, 7, 7, 3, 319, DateTimeKind.Utc).AddTicks(156) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("30a4345d-df2e-46ab-8c0e-d38a7933b591"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash", "SecurityStamp", "UpdatedDateTime" },
                values: new object[] { "0a603104-1dd7-4ee1-9818-7ea86fdc2fc5", new DateTime(2024, 5, 15, 7, 7, 3, 464, DateTimeKind.Utc).AddTicks(8333), "AQAAAAIAAYagAAAAEN3EaOxYUsW2wl5To+HiRR+QWY7tLLKdJV7xj4GRaKiO6HFDH/f8fWw+FXcf9IpDlA==", "748c4223-edb5-43bc-8d20-ebc878c8c593", new DateTime(2024, 5, 15, 7, 7, 3, 464, DateTimeKind.Utc).AddTicks(8336) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("594f8fe1-1cf1-4f5a-a8ae-6b9509fbf283"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash", "SecurityStamp", "UpdatedDateTime" },
                values: new object[] { "02853d11-a0bc-4804-8dac-9e75dab38570", new DateTime(2024, 5, 15, 7, 7, 3, 595, DateTimeKind.Utc).AddTicks(7345), "AQAAAAIAAYagAAAAEMZ+aTETtsx6o7K3ognkQ/gJTLaqKH0dHLB26dTchxKJ5IPr5d3xNwFjd0aXOQbjvQ==", "08d9e29f-48e3-42d7-94cc-ef74bf7f7c02", new DateTime(2024, 5, 15, 7, 7, 3, 595, DateTimeKind.Utc).AddTicks(7348) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("85d8a27f-9d32-4269-b5d0-844589d498d0"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash", "SecurityStamp", "UpdatedDateTime" },
                values: new object[] { "13acdb12-3bdd-42c0-a16b-f0452f712875", new DateTime(2024, 5, 15, 7, 7, 3, 95, DateTimeKind.Utc).AddTicks(1566), "AQAAAAIAAYagAAAAEF6EsdPY3dp7RpR2QxpAgIqAUsctEoDcyBTfeVyRIYJtq1MskjEnzciA/8iXScGZHQ==", "e7cdda6f-4932-4031-9bf0-055a58ea2e6b", new DateTime(2024, 5, 15, 7, 7, 3, 95, DateTimeKind.Utc).AddTicks(1568) });
        }
    }
}
