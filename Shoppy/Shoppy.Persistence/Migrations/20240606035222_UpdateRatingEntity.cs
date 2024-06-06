using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shoppy.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class UpdateRatingEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Products_IsDelete",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_Name",
                table: "Products");

            migrationBuilder.AlterColumn<string>(
                name: "Comment",
                table: "ProductRatings",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250,
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "OrderItems",
                type: "decimal(10,2)",
                precision: 10,
                scale: 2,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("021657c8-d4d0-4167-a1a6-b7bb840f33bf"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash", "SecurityStamp", "UpdatedDateTime" },
                values: new object[] { "9a00b8ba-f517-46b8-adf1-b06b27d8660b", new DateTime(2024, 6, 6, 3, 52, 14, 923, DateTimeKind.Utc).AddTicks(4980), "AQAAAAIAAYagAAAAEEdE2uK+GbRlDA+b6IgJsYn7eqv2SQkaW2xGF5nBLCXPyzUJqwpbuBn9onAgdsCiZg==", "a6be3a19-d4e5-4929-8158-cd4244d5477f", new DateTime(2024, 6, 6, 3, 52, 14, 923, DateTimeKind.Utc).AddTicks(4983) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("0cd66cfc-5d48-4f5e-b22d-5fa49234d192"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash", "SecurityStamp", "UpdatedDateTime" },
                values: new object[] { "4d2f6c63-00d0-439c-b7ea-016566149286", new DateTime(2024, 6, 6, 3, 52, 16, 806, DateTimeKind.Utc).AddTicks(6885), "AQAAAAIAAYagAAAAEBttisrxEPKbKQJl8LJ2tsjvwN+CihqL9x59bqxPemMNnLlojKZBZ8QniN66sriEvA==", "68ad387a-abe1-4b75-b696-ff65d32484e7", new DateTime(2024, 6, 6, 3, 52, 16, 806, DateTimeKind.Utc).AddTicks(6887) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("1d2b5cf5-0ad7-4c3a-b4b9-5fa49234d202"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash", "SecurityStamp", "UpdatedDateTime" },
                values: new object[] { "05959f57-0165-4e31-8126-5662b9e0527c", new DateTime(2024, 6, 6, 3, 52, 17, 918, DateTimeKind.Utc).AddTicks(4444), "AQAAAAIAAYagAAAAEMh9flnw4CQnP9ECQhRaloOFrJ8Fi8qimDRIc9nfJmo2w/eN88YIdP6zi0k3uWA1XQ==", "717f45bb-567c-4ac3-9b54-c50b605f8137", new DateTime(2024, 6, 6, 3, 52, 17, 918, DateTimeKind.Utc).AddTicks(4447) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("296dbab2-62f2-4eb6-ae53-e4c7fffdaf34"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash", "SecurityStamp", "UpdatedDateTime" },
                values: new object[] { "8b9cf7ec-5c7a-46fb-b744-89d5375490b2", new DateTime(2024, 6, 6, 3, 52, 19, 739, DateTimeKind.Utc).AddTicks(3802), "AQAAAAIAAYagAAAAENEd7YX1NAVATwpOfcebxKovVvStLD/bkOh8YaTONrQVG0Dh7X6V7dctoFl5rVdjCA==", "36c0e778-07b4-4ad4-b815-7744a0ec9d00", new DateTime(2024, 6, 6, 3, 52, 19, 739, DateTimeKind.Utc).AddTicks(3804) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("2b844c01-c89e-4d24-a5d8-5fa49234d198"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash", "SecurityStamp", "UpdatedDateTime" },
                values: new object[] { "c9c9edc7-a509-4fe2-a269-21f15d449f0b", new DateTime(2024, 6, 6, 3, 52, 17, 487, DateTimeKind.Utc).AddTicks(5152), "AQAAAAIAAYagAAAAEOvN1xX0jI0Sm7LZPyx1aUc9SXrsmk2Xuhnrr9ywu5M9E9SE9ku+FhnlWhszQJQl/g==", "9032728b-615a-48ff-b440-d1de4283fdc6", new DateTime(2024, 6, 6, 3, 52, 17, 487, DateTimeKind.Utc).AddTicks(5155) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("2c44d375-c725-4279-b2d3-87ea4218f385"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash", "SecurityStamp", "UpdatedDateTime" },
                values: new object[] { "cbb306d8-c9b8-4b96-a69b-783fdc60a463", new DateTime(2024, 6, 6, 3, 52, 18, 367, DateTimeKind.Utc).AddTicks(1128), "AQAAAAIAAYagAAAAEEiFhnM+Te6ZykrC27svmd+sVnQBczvm/Qc0B7BGcsB8WZUJQvMtRTEVuufvm4ZOMA==", "8fb9ff63-7e55-4dc8-abbd-a89b9629e8a0", new DateTime(2024, 6, 6, 3, 52, 18, 367, DateTimeKind.Utc).AddTicks(1131) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("2c96fabb-f759-43ef-9a31-328c25d2eff5"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash", "SecurityStamp", "UpdatedDateTime" },
                values: new object[] { "532648ce-bea5-4a48-8374-c5984b07df34", new DateTime(2024, 6, 6, 3, 52, 15, 66, DateTimeKind.Utc).AddTicks(2678), "AQAAAAIAAYagAAAAEFmYhMhRkYvst2zvcP6XvTRnIyTJpiIRTS1xKR/MKFJF+9WbDhnwjMEIoDuZQjhJkA==", "6c179d86-5fb0-44d2-aa27-b2a3ec22c9dc", new DateTime(2024, 6, 6, 3, 52, 15, 66, DateTimeKind.Utc).AddTicks(2682) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("2d3d5b2d-b5a3-4b89-84b3-5fa49234d186"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash", "SecurityStamp", "UpdatedDateTime" },
                values: new object[] { "8be8157c-f2d3-474a-b7da-d864b628234f", new DateTime(2024, 6, 6, 3, 52, 16, 81, DateTimeKind.Utc).AddTicks(2189), "AQAAAAIAAYagAAAAEDum0MO0SxbgOj9G3bZbNIny/arKb6GvyJ4XRsQiYndhih3g1qTUm3YkIfDHL8pvwQ==", "3ad80ce9-b1fe-42f8-948c-490bfec36427", new DateTime(2024, 6, 6, 3, 52, 16, 81, DateTimeKind.Utc).AddTicks(2192) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("30a4345d-df2e-46ab-8c0e-d38a7933b591"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash", "SecurityStamp", "UpdatedDateTime" },
                values: new object[] { "1892570e-5b02-4d9f-aaf6-8ffd7a036481", new DateTime(2024, 6, 6, 3, 52, 15, 207, DateTimeKind.Utc).AddTicks(8808), "AQAAAAIAAYagAAAAEPxr0nfgBavbSKPyHpr6XCJ17t29cLAVxuCcwGAInugqfZbnb83vX5cyQNXPTr2cwg==", "10633ab7-2e95-4b8a-994a-bde38e819bc2", new DateTime(2024, 6, 6, 3, 52, 15, 207, DateTimeKind.Utc).AddTicks(8810) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("31e7a1a6-9a5d-4b4e-84eb-5fa49234d190"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash", "SecurityStamp", "UpdatedDateTime" },
                values: new object[] { "e606133b-a945-4f99-ab89-9e0208e38af3", new DateTime(2024, 6, 6, 3, 52, 16, 573, DateTimeKind.Utc).AddTicks(2112), "AQAAAAIAAYagAAAAEIKldISIFet+t6bAuMFNNUQjriZS3XTSceB6VJsVQXLL54PDu3O/6nZsWdep+rxJzQ==", "d980ec21-2f67-4ec3-8ea8-2a6ac0fa1357", new DateTime(2024, 6, 6, 3, 52, 16, 573, DateTimeKind.Utc).AddTicks(2114) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("35d6cf06-f0ef-47a6-a4bd-5fa49234d196"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash", "SecurityStamp", "UpdatedDateTime" },
                values: new object[] { "1bee82d3-e9da-452f-8bce-393704873046", new DateTime(2024, 6, 6, 3, 52, 17, 246, DateTimeKind.Utc).AddTicks(9601), "AQAAAAIAAYagAAAAEFDNlWvXAXXIzvFdBFF1sEG4hfpMvN+ypCWv3Rd70MjGaRn+tRNswyRBfBDpBAhm9Q==", "5e551efa-804e-4e63-876e-7ff2ba86fea2", new DateTime(2024, 6, 6, 3, 52, 17, 246, DateTimeKind.Utc).AddTicks(9603) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("3d77db7b-3b3e-4a38-a1d1-5fa49234d200"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash", "SecurityStamp", "UpdatedDateTime" },
                values: new object[] { "22d0e4a7-e072-4a76-8ef7-e96665fcbe7a", new DateTime(2024, 6, 6, 3, 52, 17, 682, DateTimeKind.Utc).AddTicks(9019), "AQAAAAIAAYagAAAAEB9EYSbUptXIl1xPL5sAxcsDcEVtTZZSjlENSTMb4PKoZTP22mkobZ1gwUgvpVO6aA==", "45c0c691-6c82-4380-aa23-6d4710b539a1", new DateTime(2024, 6, 6, 3, 52, 17, 682, DateTimeKind.Utc).AddTicks(9022) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("4a8b3d09-78f2-43ad-bce6-5fa49234d189"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash", "SecurityStamp", "UpdatedDateTime" },
                values: new object[] { "f4169501-1d1d-4670-9c19-71a9899f20c0", new DateTime(2024, 6, 6, 3, 52, 16, 477, DateTimeKind.Utc).AddTicks(2490), "AQAAAAIAAYagAAAAEEKNjITelWSZ2qePzU7SSP/7o9Q4UakXHJ+U2tlN4e5hT/SKGmHSBYmIffOg6XOFGA==", "5c789bab-1b02-4dc2-9485-059c1f8f79c5", new DateTime(2024, 6, 6, 3, 52, 16, 477, DateTimeKind.Utc).AddTicks(2494) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("50b95f41-7afa-4cda-aa7a-5fa49234d183"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash", "SecurityStamp", "UpdatedDateTime" },
                values: new object[] { "269d9448-dcd4-4430-b43a-c69bdbfcf2e5", new DateTime(2024, 6, 6, 3, 52, 15, 730, DateTimeKind.Utc).AddTicks(6689), "AQAAAAIAAYagAAAAENZXhoGJqJQ939yebaqQCkcylC/6MMg8LyqCNemJ2jz5mOLEx351e/2zWuCSrofmHQ==", "1b0f0f61-8d37-49e7-b2b4-68e8adb3073c", new DateTime(2024, 6, 6, 3, 52, 15, 730, DateTimeKind.Utc).AddTicks(6692) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("50b95f41-7afa-4cda-aa7a-5fa49234d184"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash", "SecurityStamp", "UpdatedDateTime" },
                values: new object[] { "1d06ed11-ff4e-4586-a340-f6edbd85b7a3", new DateTime(2024, 6, 6, 3, 52, 15, 828, DateTimeKind.Utc).AddTicks(220), "AQAAAAIAAYagAAAAEEMnQUuCtDyKNYhQtwOayfTdVAO0x+7AyrQ+EXAJXQmtskrNqYARyujFbUkZZqtwWA==", "eab42733-1976-443f-b31b-eabe8c54955e", new DateTime(2024, 6, 6, 3, 52, 15, 828, DateTimeKind.Utc).AddTicks(224) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("56b2a1c9-a651-4fee-8f8e-5fa49234d199"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash", "SecurityStamp", "UpdatedDateTime" },
                values: new object[] { "66a51495-7300-4d92-8883-e455b2ca93ac", new DateTime(2024, 6, 6, 3, 52, 17, 590, DateTimeKind.Utc).AddTicks(6962), "AQAAAAIAAYagAAAAEKfnJXDJJ/dAj6jgUu1lgBKa627W9E9gMLlaOi1ZTg3wbqPhKpdOuq72iMxNBCplEw==", "4051ca75-6798-462e-8934-2ce9d009f0db", new DateTime(2024, 6, 6, 3, 52, 17, 590, DateTimeKind.Utc).AddTicks(6964) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("594f8fe1-1cf1-4f5a-a8ae-6b9509fbf283"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash", "SecurityStamp", "UpdatedDateTime" },
                values: new object[] { "d5578434-ce03-4a3e-8d66-fe4b4f52ab23", new DateTime(2024, 6, 6, 3, 52, 15, 346, DateTimeKind.Utc).AddTicks(2376), "AQAAAAIAAYagAAAAEKhsRQBaznIIddTskW88JBPLpI+RBiWel0yomNN33DUdZxH353o/6hSjgaVaU2+N4w==", "7aa5e612-dc14-4c48-95a1-1bf26a2d263d", new DateTime(2024, 6, 6, 3, 52, 15, 346, DateTimeKind.Utc).AddTicks(2379) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("5aca3775-d37e-473c-8f3a-3926ed32e360"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash", "SecurityStamp", "UpdatedDateTime" },
                values: new object[] { "c571226a-f664-4f5a-80ba-aa537aab5072", new DateTime(2024, 6, 6, 3, 52, 18, 109, DateTimeKind.Utc).AddTicks(3103), "AQAAAAIAAYagAAAAEOnLmvSPpWEnEWfnrrL24r1fUrthssHwEWcugvMpt9BC3Dq0gc0CNqDxPIL+CjV49g==", "9f92bff9-2309-4bb9-aec6-1f1b97f741dc", new DateTime(2024, 6, 6, 3, 52, 18, 109, DateTimeKind.Utc).AddTicks(3105) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("5c6a5f5e-3a11-4d42-bff8-5fa49234d188"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash", "SecurityStamp", "UpdatedDateTime" },
                values: new object[] { "3a1a2abf-f4ca-4a82-a599-08b2fc2c0a04", new DateTime(2024, 6, 6, 3, 52, 16, 334, DateTimeKind.Utc).AddTicks(8792), "AQAAAAIAAYagAAAAEKxCFWLTZI1l140TCRHqU81Cj8b0ME32pNk977OZbVqucO+nBFYPSrOyVNEbmYJJ3w==", "54e6c57f-e202-4170-9513-b527cd75949c", new DateTime(2024, 6, 6, 3, 52, 16, 334, DateTimeKind.Utc).AddTicks(8796) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("60a119e1-610c-42fc-85c8-95a7e4d2119b"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash", "SecurityStamp", "UpdatedDateTime" },
                values: new object[] { "950d931c-675a-4666-a904-4c97c0db0652", new DateTime(2024, 6, 6, 3, 52, 19, 553, DateTimeKind.Utc).AddTicks(6686), "AQAAAAIAAYagAAAAELguKvseBVe4eTyn/sq7BTd1yqIpoK3nUxkU1mLLjgVNmu4NSGmqE3TDt47AokRygg==", "16dfee74-e8a5-49e1-881e-069834c5c9fe", new DateTime(2024, 6, 6, 3, 52, 19, 553, DateTimeKind.Utc).AddTicks(6688) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("60b9f0cc-b3b4-4ac3-a9ce-5fa49234d193"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash", "SecurityStamp", "UpdatedDateTime" },
                values: new object[] { "0075de3a-ecd0-4bf4-ac6c-dd553152764d", new DateTime(2024, 6, 6, 3, 52, 16, 907, DateTimeKind.Utc).AddTicks(5228), "AQAAAAIAAYagAAAAECNelddS88v4fbxR8RzMepBrQnWg6tzntywgvNH06iTt5Kpbqae4H2wpUC210XjfKA==", "1fc025b8-27c3-44e4-84c3-98febe37436f", new DateTime(2024, 6, 6, 3, 52, 16, 907, DateTimeKind.Utc).AddTicks(5231) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("6c16a235-f928-4b8d-978f-5fa49234d194"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash", "SecurityStamp", "UpdatedDateTime" },
                values: new object[] { "a6df366d-2e0e-45cb-a1cf-dbca54a79764", new DateTime(2024, 6, 6, 3, 52, 17, 3, DateTimeKind.Utc).AddTicks(5934), "AQAAAAIAAYagAAAAEHFlqLuv94H5tZn3U0GtV4PoPztbcgj4QKaYBhSGdu/ABB8S45jV+I7OEFWNQrP0Ww==", "49e210e2-c7b5-44b3-9fe2-da0ab100127b", new DateTime(2024, 6, 6, 3, 52, 17, 3, DateTimeKind.Utc).AddTicks(5936) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("6e2f7a2d-1994-419b-8c6d-b3d297cd7b06"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash", "SecurityStamp", "UpdatedDateTime" },
                values: new object[] { "7029d3f1-3404-4bba-b9c9-8253c708aa63", new DateTime(2024, 6, 6, 3, 52, 19, 364, DateTimeKind.Utc).AddTicks(8808), "AQAAAAIAAYagAAAAEJ3yASkmHKqzpH3YjJ0zVtYa8xmNTgSsSMbSvdBegB7F5SZQLdrpoCkXQNAGWHc1PA==", "13f20bf6-fc0a-42f0-9960-f3c35f4c105f", new DateTime(2024, 6, 6, 3, 52, 19, 364, DateTimeKind.Utc).AddTicks(8811) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("7db124bd-9953-4eb0-98f2-50b1be635544"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash", "SecurityStamp", "UpdatedDateTime" },
                values: new object[] { "c3952179-880b-4f11-ac21-69e0083006a3", new DateTime(2024, 6, 6, 3, 52, 15, 612, DateTimeKind.Utc).AddTicks(8106), "AQAAAAIAAYagAAAAENXqUTgFrtj9fUjBQfbst/ginPZyPrE8Ehyz3DLUslKA4GAB7HjyTrjTaD+HYrz6PA==", "eff0074c-7c7e-47ae-9911-184d866e9606", new DateTime(2024, 6, 6, 3, 52, 15, 612, DateTimeKind.Utc).AddTicks(8108) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("853988db-ad55-4a28-9782-90438c64b62d"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash", "SecurityStamp", "UpdatedDateTime" },
                values: new object[] { "a9640535-550c-409e-94b0-cbb73f3bac9a", new DateTime(2024, 6, 6, 3, 52, 19, 460, DateTimeKind.Utc).AddTicks(9064), "AQAAAAIAAYagAAAAEKPuk1X9NXXB7nJlwtEaJtzfCW38i08VlTl9QPBLiSLwwnWeBFs6T+jcXQXTRJT24A==", "7babf29f-bb53-4292-b7b7-72ecdfd5ed09", new DateTime(2024, 6, 6, 3, 52, 19, 460, DateTimeKind.Utc).AddTicks(9066) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("85d8a27f-9d32-4269-b5d0-844589d498d0"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash", "SecurityStamp", "UpdatedDateTime" },
                values: new object[] { "5391ab21-0b51-40e1-93cb-aa3d5f5b71cc", new DateTime(2024, 6, 6, 3, 52, 14, 782, DateTimeKind.Utc).AddTicks(3742), "AQAAAAIAAYagAAAAEDWul6PoVd8osngtwDKaF1LhclcZylPee3y+r9DiwDtexhqp5wlsDh1+es9cemPumw==", "5bed661d-d82a-4ce0-8ad0-512abe9b0e8b", new DateTime(2024, 6, 6, 3, 52, 14, 782, DateTimeKind.Utc).AddTicks(3745) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("870559eb-5fde-4764-ade7-392b0cf6b5ce"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash", "SecurityStamp", "UpdatedDateTime" },
                values: new object[] { "fd0d0f2f-43aa-4f00-8d86-43bbc7b39514", new DateTime(2024, 6, 6, 3, 52, 19, 646, DateTimeKind.Utc).AddTicks(5668), "AQAAAAIAAYagAAAAEBAeaP2SGn4UAG+hTe3z0D30T7RiufzLYATvBdRym/MVvXcnATDCojJUlqajW3x4LA==", "74726468-2ddc-4355-a32d-c6b8f48da8a5", new DateTime(2024, 6, 6, 3, 52, 19, 646, DateTimeKind.Utc).AddTicks(5671) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("87787f6e-729b-436b-bcc9-c7b48c45ba05"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash", "SecurityStamp", "UpdatedDateTime" },
                values: new object[] { "3a1bffb1-20e9-4fe4-94fe-5b0a23c42656", new DateTime(2024, 6, 6, 3, 52, 18, 825, DateTimeKind.Utc).AddTicks(9669), "AQAAAAIAAYagAAAAEFiU1nKl4F8mV0VQ0xM7mFiHyns2yuLfomSa4EDv8QXkizqn1mtNjYiV0z/sMrOZbg==", "b8bd03e9-5310-41a6-8ae7-71dab2d57a48", new DateTime(2024, 6, 6, 3, 52, 18, 825, DateTimeKind.Utc).AddTicks(9673) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("8c3b46b9-1321-4d97-a193-5fa49234d185"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash", "SecurityStamp", "UpdatedDateTime" },
                values: new object[] { "ddad2443-c794-4634-8d43-244141cc8bb2", new DateTime(2024, 6, 6, 3, 52, 15, 981, DateTimeKind.Utc).AddTicks(1051), "AQAAAAIAAYagAAAAEK1bfmgUbtZmEN02+w4hV4oQ4V+vhpC+hzgTNglWq6ME1f/4BpEtumRQfr9V8OVTSg==", "ffb262c8-7048-4705-8fda-d7e883b2f965", new DateTime(2024, 6, 6, 3, 52, 15, 981, DateTimeKind.Utc).AddTicks(1053) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("906f192a-96d3-433a-a7ea-288662b5f62d"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash", "SecurityStamp", "UpdatedDateTime" },
                values: new object[] { "2b7fa1cd-91b7-4232-9f21-fa04fe224ffb", new DateTime(2024, 6, 6, 3, 52, 18, 472, DateTimeKind.Utc).AddTicks(3616), "AQAAAAIAAYagAAAAEOwGVhzhacZaYOY4K+0/OSG4H3ef0qg2l+kDdDgOO2s7nkEqctbvUbNvsESE5y63Gw==", "b6f59e0a-e75f-4c81-81f8-f214549b55b6", new DateTime(2024, 6, 6, 3, 52, 18, 472, DateTimeKind.Utc).AddTicks(3619) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("91d0da1b-e147-4829-aa4e-7073c1a10d2c"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash", "SecurityStamp", "UpdatedDateTime" },
                values: new object[] { "9a14eb4c-d852-4be0-ab03-4cb9ebf90633", new DateTime(2024, 6, 6, 3, 52, 19, 21, DateTimeKind.Utc).AddTicks(5779), "AQAAAAIAAYagAAAAEGrWoZOBVY/rsOubnjENbGStAr68l/5LUmUwQ983WUtvlsfRdovmSEscPRM7ueiVmQ==", "d60971c5-f982-4da6-9538-41122c784285", new DateTime(2024, 6, 6, 3, 52, 19, 21, DateTimeKind.Utc).AddTicks(5782) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("9a4a34a4-4b12-4c8e-a52b-5fa49234d195"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash", "SecurityStamp", "UpdatedDateTime" },
                values: new object[] { "d534ea81-7974-4602-88f8-22b088d7a286", new DateTime(2024, 6, 6, 3, 52, 17, 148, DateTimeKind.Utc).AddTicks(4038), "AQAAAAIAAYagAAAAEBODP1na7sZtwgpgL0IR85mO1bhD9Rgo+tJhg2SWrwL5OsPgvFUn4K9Q8B8jV6OW+g==", "7cd081c9-1458-4c38-a0cd-6f7c83d48546", new DateTime(2024, 6, 6, 3, 52, 17, 148, DateTimeKind.Utc).AddTicks(4042) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("9b8c6d7b-754f-420c-b574-4a63326bfc6a"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash", "SecurityStamp", "UpdatedDateTime" },
                values: new object[] { "f786689a-f9d7-498b-857a-57c477ca0ec9", new DateTime(2024, 6, 6, 3, 52, 19, 214, DateTimeKind.Utc).AddTicks(5028), "AQAAAAIAAYagAAAAENNwzIKNvobcEAQeYVHzavu/kK6Z0a9zYK/sx3OfpiiNEyibHmloSoHjfJJLSzvaKw==", "95916984-402d-4b42-ae4e-da15a9d670dd", new DateTime(2024, 6, 6, 3, 52, 19, 214, DateTimeKind.Utc).AddTicks(5032) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("9d36fef6-9c75-4f96-a951-5fa49234d203"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash", "SecurityStamp", "UpdatedDateTime" },
                values: new object[] { "9d2f27a6-0f77-41d6-a83c-dc0e9390a23f", new DateTime(2024, 6, 6, 3, 52, 18, 15, DateTimeKind.Utc).AddTicks(9961), "AQAAAAIAAYagAAAAEAdHMVgfcxgFAvWzBY+RuHD+xKwZ1MJitt5bCMhyfD1D18fqBwkd8DWfDGCVBNis8g==", "5101d368-1709-4612-849b-dd4279ccde38", new DateTime(2024, 6, 6, 3, 52, 18, 15, DateTimeKind.Utc).AddTicks(9964) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("b2687ce8-aad5-4d5f-849b-dcd2b402aff0"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash", "SecurityStamp", "UpdatedDateTime" },
                values: new object[] { "9da80a3d-a02d-4963-a25c-ddd0d7627656", new DateTime(2024, 6, 6, 3, 52, 19, 866, DateTimeKind.Utc).AddTicks(9684), "AQAAAAIAAYagAAAAEN1+B5BBwQZsK/pIQgaAblivbl77YQ8PTl0/b9BbwDdA31MofACpID31CvoR59TIbA==", "05a586ae-872c-410e-90dd-df4a933c78eb", new DateTime(2024, 6, 6, 3, 52, 19, 866, DateTimeKind.Utc).AddTicks(9688) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("b6123f4e-3443-41ae-a1cb-5fa49234d187"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash", "SecurityStamp", "UpdatedDateTime" },
                values: new object[] { "c9f4990f-31f4-4661-a515-853ccea2ffb1", new DateTime(2024, 6, 6, 3, 52, 16, 227, DateTimeKind.Utc).AddTicks(5349), "AQAAAAIAAYagAAAAEJMGJg9b/soKekBOtm2i8OQo+eLmQQBjO59np3KDH1gSu46e5/Jx4R8Ibi5QaK6NcA==", "ca269c89-caae-46f7-9ae3-d9691c154130", new DateTime(2024, 6, 6, 3, 52, 16, 227, DateTimeKind.Utc).AddTicks(5352) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("c0a7e4f4-d8d0-4c80-8e1c-5fa49234d201"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash", "SecurityStamp", "UpdatedDateTime" },
                values: new object[] { "64895fae-8b6f-4e9f-a373-ac1a3f5caec1", new DateTime(2024, 6, 6, 3, 52, 17, 782, DateTimeKind.Utc).AddTicks(7347), "AQAAAAIAAYagAAAAEJkm31NUdudX4YZryCIBGV9fYQUD8/4OmInfwKeKGRzo2bvvuvf4hciHYAj+hwNJrw==", "688aa3f7-c55c-40bb-bb64-d48827bc0e32", new DateTime(2024, 6, 6, 3, 52, 17, 782, DateTimeKind.Utc).AddTicks(7349) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("c55cdfd0-d1dd-4841-ae27-f2d621686756"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash", "SecurityStamp", "UpdatedDateTime" },
                values: new object[] { "868d8c4f-4eb6-4430-af6e-71aae221b196", new DateTime(2024, 6, 6, 3, 52, 18, 593, DateTimeKind.Utc).AddTicks(1547), "AQAAAAIAAYagAAAAEMiKJGkpYZ0x46CLVTikyT3d81CzTZxHRmOqedxE5nNhSgO2Gs+Mg3i5ZbiiBwU56Q==", "03b498ac-43e6-41c3-9bf2-c39dfa8da7f6", new DateTime(2024, 6, 6, 3, 52, 18, 593, DateTimeKind.Utc).AddTicks(1551) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("d0e03a1a-21c2-4123-a75e-5fa49234d191"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash", "SecurityStamp", "UpdatedDateTime" },
                values: new object[] { "14848351-3ad4-4645-8231-4e71df24da1e", new DateTime(2024, 6, 6, 3, 52, 16, 677, DateTimeKind.Utc).AddTicks(3467), "AQAAAAIAAYagAAAAEL302NVUCkpmCMVpEwDG8slC1Oqr0UPcdgqIeTrToW/j0Hw6bsMBRWw6u67WHfsirw==", "9738efca-21eb-4a83-ae10-78191ae88d06", new DateTime(2024, 6, 6, 3, 52, 16, 677, DateTimeKind.Utc).AddTicks(3471) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("d30fa796-5144-4467-a302-68dc64fd0d92"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash", "SecurityStamp", "UpdatedDateTime" },
                values: new object[] { "ab4a11b4-78b5-41ab-ac0f-51f29eb97088", new DateTime(2024, 6, 6, 3, 52, 18, 928, DateTimeKind.Utc).AddTicks(4059), "AQAAAAIAAYagAAAAEPHP9e5oD5Fwi8x1kRDDPkXVd9BIVB8N1mbkEW/aFmwd58ZPVUI4kZFgK1WvepPTgA==", "6951646f-8010-4953-83fd-c982fc5248a8", new DateTime(2024, 6, 6, 3, 52, 18, 928, DateTimeKind.Utc).AddTicks(4062) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e92c6f32-859b-443b-bfb2-bd0674b5673a"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash", "SecurityStamp", "UpdatedDateTime" },
                values: new object[] { "99200db6-4162-4853-8f50-7a52ee7d175d", new DateTime(2024, 6, 6, 3, 52, 18, 218, DateTimeKind.Utc).AddTicks(6487), "AQAAAAIAAYagAAAAEDqYJCRI3ixlsQuGhBsk3Mo1KnTXj99WDKhG5r4Ed3TM6aaOZNr2kJqEQmBvG1Dtbw==", "6b813289-aa3c-4933-ba68-21f3a8b2eaca", new DateTime(2024, 6, 6, 3, 52, 18, 218, DateTimeKind.Utc).AddTicks(6489) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("eee6e626-9a26-4f38-bbe3-433d20440ce9"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash", "SecurityStamp", "UpdatedDateTime" },
                values: new object[] { "a9223256-3236-4439-ac22-8f0b39020509", new DateTime(2024, 6, 6, 3, 52, 15, 474, DateTimeKind.Utc).AddTicks(2647), "AQAAAAIAAYagAAAAEMhohokdi9kUtoIftCoz9Pll25/Shgegx0qYuYP6yeTbGbTanUNCEYQP9YwWEoB63g==", "9a3f2077-81f3-4ed6-91c5-5aff179c3889", new DateTime(2024, 6, 6, 3, 52, 15, 474, DateTimeKind.Utc).AddTicks(2650) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("eeed5a4d-e83d-4032-8c3c-5fa49234d197"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash", "SecurityStamp", "UpdatedDateTime" },
                values: new object[] { "0d43b01a-49af-4f74-b64c-5f09fbc7cfd4", new DateTime(2024, 6, 6, 3, 52, 17, 345, DateTimeKind.Utc).AddTicks(105), "AQAAAAIAAYagAAAAEKhFQgqVu81NU2mL0wdOqghdictZ6WEsplQKJHVV/ytdg0jJxxp0oOG2YLrhtBC9DA==", "88bc2975-c547-402c-9007-0c420ecf1323", new DateTime(2024, 6, 6, 3, 52, 17, 345, DateTimeKind.Utc).AddTicks(108) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("f483fb9f-477c-4a3a-9f73-3b028b06ed49"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash", "SecurityStamp", "UpdatedDateTime" },
                values: new object[] { "8b505826-d279-436c-b137-4f219c441096", new DateTime(2024, 6, 6, 3, 52, 18, 686, DateTimeKind.Utc).AddTicks(2621), "AQAAAAIAAYagAAAAEOJMjn3yH7vu+9DlX+LVJIV0IbjO3SveO6mSrA5r5tgf+6ka7ekAiof3sSN4wUXsYg==", "61705844-0f26-4f5e-a3de-0c3668799984", new DateTime(2024, 6, 6, 3, 52, 18, 686, DateTimeKind.Utc).AddTicks(2625) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("fbd62259-a313-4d38-885e-1f6acdf9a30a"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash", "SecurityStamp", "UpdatedDateTime" },
                values: new object[] { "66c2321b-1364-4494-a236-971f7ed6dd15", new DateTime(2024, 6, 6, 3, 52, 19, 113, DateTimeKind.Utc).AddTicks(6147), "AQAAAAIAAYagAAAAEBnuwhQbnLhJt1jmsMGr5+aD/X6UokEPIqSt7FymIOHcYD3zB3ZsPtl44qTxhmfj3g==", "6b34eb50-8e13-4525-a02c-fc6fb8f21110", new DateTime(2024, 6, 6, 3, 52, 19, 113, DateTimeKind.Utc).AddTicks(6149) });

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: new Guid("292c90a5-1a0a-45a4-8f3d-37f09b09b422"),
                columns: new[] { "CreatedDateTime", "UpdatedDateTime" },
                values: new object[] { new DateTime(2024, 6, 6, 3, 52, 19, 988, DateTimeKind.Utc).AddTicks(4526), new DateTime(2024, 6, 6, 3, 52, 19, 988, DateTimeKind.Utc).AddTicks(4526) });

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: new Guid("2baf4c50-c927-4b54-971e-3ff5f300e147"),
                columns: new[] { "CreatedDateTime", "UpdatedDateTime" },
                values: new object[] { new DateTime(2024, 6, 6, 3, 52, 19, 988, DateTimeKind.Utc).AddTicks(4513), new DateTime(2024, 6, 6, 3, 52, 19, 988, DateTimeKind.Utc).AddTicks(4514) });

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: new Guid("97cf6bd7-7290-449a-a61d-5ea2fdfcf8de"),
                columns: new[] { "CreatedDateTime", "UpdatedDateTime" },
                values: new object[] { new DateTime(2024, 6, 6, 3, 52, 19, 988, DateTimeKind.Utc).AddTicks(4528), new DateTime(2024, 6, 6, 3, 52, 19, 988, DateTimeKind.Utc).AddTicks(4528) });

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: new Guid("99ada3c1-eea5-4431-a529-b3114de224da"),
                columns: new[] { "CreatedDateTime", "UpdatedDateTime" },
                values: new object[] { new DateTime(2024, 6, 6, 3, 52, 19, 988, DateTimeKind.Utc).AddTicks(4520), new DateTime(2024, 6, 6, 3, 52, 19, 988, DateTimeKind.Utc).AddTicks(4520) });

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: new Guid("adf36edc-3e08-4a36-8e20-0d79747f0962"),
                columns: new[] { "CreatedDateTime", "UpdatedDateTime" },
                values: new object[] { new DateTime(2024, 6, 6, 3, 52, 19, 988, DateTimeKind.Utc).AddTicks(4522), new DateTime(2024, 6, 6, 3, 52, 19, 988, DateTimeKind.Utc).AddTicks(4523) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("9243d741-a350-4067-bb29-395e9becf57e"),
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 6, 3, 52, 19, 989, DateTimeKind.Utc).AddTicks(9300));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("e21f3a87-20d5-420e-ba33-9108df996747"),
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 6, 3, 52, 19, 989, DateTimeKind.Utc).AddTicks(9321));

            migrationBuilder.CreateIndex(
                name: "IX_Products_IsDelete_Name",
                table: "Products",
                columns: new[] { "IsDelete", "Name" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Products_IsDelete_Name",
                table: "Products");

            migrationBuilder.AlterColumn<string>(
                name: "Comment",
                table: "ProductRatings",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(1000)",
                oldMaxLength: 1000,
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "OrderItems",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(10,2)",
                oldPrecision: 10,
                oldScale: 2);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("021657c8-d4d0-4167-a1a6-b7bb840f33bf"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash", "SecurityStamp", "UpdatedDateTime" },
                values: new object[] { "e5a4700f-69af-4bdb-8231-076cee7135e9", new DateTime(2024, 5, 27, 9, 3, 6, 178, DateTimeKind.Utc).AddTicks(5263), "AQAAAAIAAYagAAAAEM8rI71re/pA68vTZN1iFI+/CJl08wLxVwFElNRmPMDIxRVybsVBXq216yIbuWm5Rg==", "74407672-16ba-45a4-84c8-da5cec93168b", new DateTime(2024, 5, 27, 9, 3, 6, 178, DateTimeKind.Utc).AddTicks(5266) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("0cd66cfc-5d48-4f5e-b22d-5fa49234d192"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash", "SecurityStamp", "UpdatedDateTime" },
                values: new object[] { "fb81fa3a-9f83-4b43-8d15-f609c4a602d2", new DateTime(2024, 5, 27, 9, 3, 10, 16, DateTimeKind.Utc).AddTicks(5204), "AQAAAAIAAYagAAAAECw2m/9jv03ynO9+eHL/sfsHM/rn3WH3VZl6Aads3BD0edMGQogJnzQRwmkL5fvqbw==", "41fd3f18-4841-477e-b3d8-baf7dc9a93f3", new DateTime(2024, 5, 27, 9, 3, 10, 16, DateTimeKind.Utc).AddTicks(5207) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("1d2b5cf5-0ad7-4c3a-b4b9-5fa49234d202"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash", "SecurityStamp", "UpdatedDateTime" },
                values: new object[] { "6277101a-7929-4243-8c99-c1abb6137f7b", new DateTime(2024, 5, 27, 9, 3, 12, 275, DateTimeKind.Utc).AddTicks(7723), "AQAAAAIAAYagAAAAEHYHmEALlj7xp6G3Xs9ptA0VW8mFNw3aAFqB0Cgb2G2U0tpsXIhGVdRBkcykXA5Cfw==", "459fd7d1-1de9-4b6b-850a-4186bea3d86b", new DateTime(2024, 5, 27, 9, 3, 12, 275, DateTimeKind.Utc).AddTicks(7725) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("296dbab2-62f2-4eb6-ae53-e4c7fffdaf34"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash", "SecurityStamp", "UpdatedDateTime" },
                values: new object[] { "dcef58c7-24f9-4105-845b-fd4ee12aa04b", new DateTime(2024, 5, 27, 9, 3, 14, 64, DateTimeKind.Utc).AddTicks(5461), "AQAAAAIAAYagAAAAEK2N+KjV8OMMYFZVYRkLnrbLwXk4YbvmE6R1qRKlw+sLEUyfMu0bAxQJ3m1UQ/q78g==", "3ea4e9c9-14d2-4661-8ec1-3d00ced9b782", new DateTime(2024, 5, 27, 9, 3, 14, 64, DateTimeKind.Utc).AddTicks(5463) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("2b844c01-c89e-4d24-a5d8-5fa49234d198"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash", "SecurityStamp", "UpdatedDateTime" },
                values: new object[] { "e550105a-fb8e-41a8-957d-96027b6a15f2", new DateTime(2024, 5, 27, 9, 3, 11, 381, DateTimeKind.Utc).AddTicks(8842), "AQAAAAIAAYagAAAAEBXYBGznVxjNWHMsbz2MIlUgLToI0+SpvgGhVEC17bJ6sqk9tNMMcrk6BqnrDrCOgg==", "196a8c56-9a57-4bd9-b80b-a6a391cfd88e", new DateTime(2024, 5, 27, 9, 3, 11, 381, DateTimeKind.Utc).AddTicks(8848) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("2c44d375-c725-4279-b2d3-87ea4218f385"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash", "SecurityStamp", "UpdatedDateTime" },
                values: new object[] { "832090df-04a2-4cbd-a90b-8aed8314f006", new DateTime(2024, 5, 27, 9, 3, 12, 677, DateTimeKind.Utc).AddTicks(6551), "AQAAAAIAAYagAAAAEEo1KQJaH2ptUxEvk7+n85tHJOY3dhMR/kf8YycWoMOqG4qn/YcPP5YYBIkc8kjRqg==", "75ddf683-91b1-4dd4-b0be-99c78ef300c2", new DateTime(2024, 5, 27, 9, 3, 12, 677, DateTimeKind.Utc).AddTicks(6554) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("2c96fabb-f759-43ef-9a31-328c25d2eff5"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash", "SecurityStamp", "UpdatedDateTime" },
                values: new object[] { "1d453917-ff94-440e-8e9b-8e96209b177c", new DateTime(2024, 5, 27, 9, 3, 6, 360, DateTimeKind.Utc).AddTicks(3319), "AQAAAAIAAYagAAAAEOz2VYdxDDgyKSaYVI10ZHIB618neVKqYs1AhnoiINiPO/YeaNyiGcxcncSzPogotA==", "d04e36c4-bb66-4ba0-83ef-7796864cc26c", new DateTime(2024, 5, 27, 9, 3, 6, 360, DateTimeKind.Utc).AddTicks(3322) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("2d3d5b2d-b5a3-4b89-84b3-5fa49234d186"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash", "SecurityStamp", "UpdatedDateTime" },
                values: new object[] { "83745cce-506a-4f48-ad08-a00db70826f4", new DateTime(2024, 5, 27, 9, 3, 8, 508, DateTimeKind.Utc).AddTicks(4369), "AQAAAAIAAYagAAAAENT6e09RF3aTK3E2XEdfv7LwYB8PnAVIQSecGt4POc/VRkjAsTApKwR0sAcK5ttEeg==", "51c3f3ac-05e0-4203-bc98-30242570bd4f", new DateTime(2024, 5, 27, 9, 3, 8, 508, DateTimeKind.Utc).AddTicks(4371) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("30a4345d-df2e-46ab-8c0e-d38a7933b591"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash", "SecurityStamp", "UpdatedDateTime" },
                values: new object[] { "b474a9c6-f92f-4de5-a023-8de8bfde2381", new DateTime(2024, 5, 27, 9, 3, 6, 550, DateTimeKind.Utc).AddTicks(6411), "AQAAAAIAAYagAAAAEFFJ46g4RRvdrRnVRW5xgp8IcBK6ExxLWqNeJMy8HPBLMpeDT9uzsLUFJlrCjJVBZg==", "807f1bed-d523-4ce3-85a0-5b4ba6f89b7c", new DateTime(2024, 5, 27, 9, 3, 6, 550, DateTimeKind.Utc).AddTicks(6413) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("31e7a1a6-9a5d-4b4e-84eb-5fa49234d190"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash", "SecurityStamp", "UpdatedDateTime" },
                values: new object[] { "0c21a5a2-c823-46f4-aa5d-3e62e9809221", new DateTime(2024, 5, 27, 9, 3, 9, 462, DateTimeKind.Utc).AddTicks(6415), "AQAAAAIAAYagAAAAEEuA1qW/eat2/XvViFZW/EX5H8RgMlZhqpf76EFoT24Uv+1pZAza7RZEjIStZgR1dA==", "2724d42b-c174-4fe9-89f3-83a1f02ae1be", new DateTime(2024, 5, 27, 9, 3, 9, 462, DateTimeKind.Utc).AddTicks(6418) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("35d6cf06-f0ef-47a6-a4bd-5fa49234d196"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash", "SecurityStamp", "UpdatedDateTime" },
                values: new object[] { "c07379c7-ae0e-42b6-b1a9-8ebc66dc2341", new DateTime(2024, 5, 27, 9, 3, 10, 975, DateTimeKind.Utc).AddTicks(5737), "AQAAAAIAAYagAAAAEOdJtWcpOmM6b6agY/P1sJfCQ77XkdlrFzXjQv9rDWRTxvjMSh6+frCyKsTCjfu/oA==", "65d72297-75de-491a-99e8-f2bf43a3765c", new DateTime(2024, 5, 27, 9, 3, 10, 975, DateTimeKind.Utc).AddTicks(5740) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("3d77db7b-3b3e-4a38-a1d1-5fa49234d200"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash", "SecurityStamp", "UpdatedDateTime" },
                values: new object[] { "97193b2e-e8ba-42dc-97bd-99ded096a8c2", new DateTime(2024, 5, 27, 9, 3, 11, 760, DateTimeKind.Utc).AddTicks(1531), "AQAAAAIAAYagAAAAEIvTE9Bm24NslOWjT++yWu/0oCjrLOCsifi2Pj+av8baXA/lTHONrLj3R9cZEQtxpA==", "e077823a-9aa7-43f4-9123-15649b4b22c1", new DateTime(2024, 5, 27, 9, 3, 11, 760, DateTimeKind.Utc).AddTicks(1534) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("4a8b3d09-78f2-43ad-bce6-5fa49234d189"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash", "SecurityStamp", "UpdatedDateTime" },
                values: new object[] { "2110279d-ad62-4ba6-bd65-ff0151a22bb2", new DateTime(2024, 5, 27, 9, 3, 9, 94, DateTimeKind.Utc).AddTicks(728), "AQAAAAIAAYagAAAAEDnogL1Dmn0IpTCdVVArwu+G+G6P6DINCMGMBTEmjWMWiOZQLBhLei0EdcUCRkeK/Q==", "be78ad2f-924e-4077-a69a-6f838090ce5b", new DateTime(2024, 5, 27, 9, 3, 9, 94, DateTimeKind.Utc).AddTicks(732) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("50b95f41-7afa-4cda-aa7a-5fa49234d183"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash", "SecurityStamp", "UpdatedDateTime" },
                values: new object[] { "5851e0a2-2f1e-4b94-ab1b-1ed27295ced1", new DateTime(2024, 5, 27, 9, 3, 7, 821, DateTimeKind.Utc).AddTicks(7867), "AQAAAAIAAYagAAAAEE4hzCNqcN2+xIRA3nSuV33vBq0werBWTZPYmJB6sbcSW5+814xohDH3IwIt0uVn+A==", "2ca6c66b-3b54-4a52-ae9f-28032894c3b9", new DateTime(2024, 5, 27, 9, 3, 7, 821, DateTimeKind.Utc).AddTicks(7872) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("50b95f41-7afa-4cda-aa7a-5fa49234d184"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash", "SecurityStamp", "UpdatedDateTime" },
                values: new object[] { "26a622e4-b877-4351-8ff0-5d55886ac2d9", new DateTime(2024, 5, 27, 9, 3, 8, 76, DateTimeKind.Utc).AddTicks(983), "AQAAAAIAAYagAAAAEFVUvJvICvJIuzImY0RLwmU7YYK8RZUxxUcycWN3BVQV2tEnEMvSphlqXCnLI2Myig==", "f61796d3-3b5f-4265-b61e-19a637518c19", new DateTime(2024, 5, 27, 9, 3, 8, 76, DateTimeKind.Utc).AddTicks(986) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("56b2a1c9-a651-4fee-8f8e-5fa49234d199"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash", "SecurityStamp", "UpdatedDateTime" },
                values: new object[] { "2c76c620-7796-44f3-b6d7-7fdc5770bd52", new DateTime(2024, 5, 27, 9, 3, 11, 577, DateTimeKind.Utc).AddTicks(1171), "AQAAAAIAAYagAAAAEC3ZRyyGSO+kDcjb2mlB9ZCRJ/kVHSSsIH819MOmXE4C7IOlUre2xRmE3olEzotH7Q==", "8386d365-e132-4e0e-9711-0ad94c859fbc", new DateTime(2024, 5, 27, 9, 3, 11, 577, DateTimeKind.Utc).AddTicks(1177) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("594f8fe1-1cf1-4f5a-a8ae-6b9509fbf283"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash", "SecurityStamp", "UpdatedDateTime" },
                values: new object[] { "5e0c5238-347b-476a-b479-6c465c74e049", new DateTime(2024, 5, 27, 9, 3, 6, 970, DateTimeKind.Utc).AddTicks(133), "AQAAAAIAAYagAAAAEJExBTSbMBT7ywaRCnMG7Y4YKFYkMwHKLfBDlNCXEU4SS98nyu0NRVupv4f0Hdd5Xg==", "3743588b-e8cd-431a-af37-de582b814c74", new DateTime(2024, 5, 27, 9, 3, 6, 970, DateTimeKind.Utc).AddTicks(136) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("5aca3775-d37e-473c-8f3a-3926ed32e360"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash", "SecurityStamp", "UpdatedDateTime" },
                values: new object[] { "a72c6b91-6590-40b7-92d8-6364c3b4cec6", new DateTime(2024, 5, 27, 9, 3, 12, 485, DateTimeKind.Utc).AddTicks(3742), "AQAAAAIAAYagAAAAELWBRuBEyDm+NU5Mp8iKaIdNGAjLt9Yyt2gIz36iZ2y1FKPMtu7osyy641KhUp1b/g==", "66d16eda-818c-4073-b45e-9ec894beee90", new DateTime(2024, 5, 27, 9, 3, 12, 485, DateTimeKind.Utc).AddTicks(3744) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("5c6a5f5e-3a11-4d42-bff8-5fa49234d188"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash", "SecurityStamp", "UpdatedDateTime" },
                values: new object[] { "c9e61578-0538-4171-9d5f-2a98fc39e379", new DateTime(2024, 5, 27, 9, 3, 8, 915, DateTimeKind.Utc).AddTicks(9475), "AQAAAAIAAYagAAAAEJrqLZYkUGRvPWf+f7m7D/97I7E/S7NcXwatAzpAFWCLKQMJ1izXbBs72sLiZ78nXg==", "f5a56832-4cb5-402f-953e-5685b8e6aaea", new DateTime(2024, 5, 27, 9, 3, 8, 915, DateTimeKind.Utc).AddTicks(9477) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("60a119e1-610c-42fc-85c8-95a7e4d2119b"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash", "SecurityStamp", "UpdatedDateTime" },
                values: new object[] { "975da4dd-5f96-42f8-b784-c76ce1593536", new DateTime(2024, 5, 27, 9, 3, 13, 864, DateTimeKind.Utc).AddTicks(6354), "AQAAAAIAAYagAAAAEIjFGdWpKD2aqgdbcWuLv88hXAx8DgtHr6vnkncQTD90H3hKo0vfjO2XIkOcWGlJRA==", "0d0f5e58-a02c-4c55-b8e1-676aedddc6b9", new DateTime(2024, 5, 27, 9, 3, 13, 864, DateTimeKind.Utc).AddTicks(6356) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("60b9f0cc-b3b4-4ac3-a9ce-5fa49234d193"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash", "SecurityStamp", "UpdatedDateTime" },
                values: new object[] { "efd8ec32-fd2c-447b-bc23-00dfce0e30a6", new DateTime(2024, 5, 27, 9, 3, 10, 224, DateTimeKind.Utc).AddTicks(9386), "AQAAAAIAAYagAAAAEAeF7Q9psRHvVeAbTgZtWZ8l7U3ZRsO85M8/969P+QO/c6PZENK+rUMtCJHCnz8Z0A==", "277a320c-a059-41ae-9303-fae28470da60", new DateTime(2024, 5, 27, 9, 3, 10, 224, DateTimeKind.Utc).AddTicks(9388) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("6c16a235-f928-4b8d-978f-5fa49234d194"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash", "SecurityStamp", "UpdatedDateTime" },
                values: new object[] { "dbaa98d2-524a-42d4-b065-f69a31e9d1e2", new DateTime(2024, 5, 27, 9, 3, 10, 528, DateTimeKind.Utc).AddTicks(9464), "AQAAAAIAAYagAAAAEDkenwlEcTPn5WDVtONyddQGyIqo0/CkTFBeViA6tSqDnd63pjqCrsUS3JLRzS6abA==", "f3451bac-22c2-47a3-8256-03bb7980979f", new DateTime(2024, 5, 27, 9, 3, 10, 528, DateTimeKind.Utc).AddTicks(9467) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("6e2f7a2d-1994-419b-8c6d-b3d297cd7b06"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash", "SecurityStamp", "UpdatedDateTime" },
                values: new object[] { "c65d63e4-f489-4473-8c45-b64ebc2eafa9", new DateTime(2024, 5, 27, 9, 3, 13, 671, DateTimeKind.Utc).AddTicks(6085), "AQAAAAIAAYagAAAAELh9SIX5SDouzmYDFhIFIdHle9nqSmXN2q+qp0jizE4g2uLvgTC1p04Et79MMtNsEQ==", "581ef41d-c8cf-4b6f-bc15-46f6b627e165", new DateTime(2024, 5, 27, 9, 3, 13, 671, DateTimeKind.Utc).AddTicks(6087) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("7db124bd-9953-4eb0-98f2-50b1be635544"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash", "SecurityStamp", "UpdatedDateTime" },
                values: new object[] { "692f508b-215b-4997-afe4-e3987ca208d0", new DateTime(2024, 5, 27, 9, 3, 7, 583, DateTimeKind.Utc).AddTicks(4728), "AQAAAAIAAYagAAAAED/xl9gd6pD6RQzThwj9TCc84qvSnAszETi7pVpvTBGt+Q9pyQEVCdBHsk+LxyKe6w==", "594b207c-7e99-4f9b-9082-9373e860b6c1", new DateTime(2024, 5, 27, 9, 3, 7, 583, DateTimeKind.Utc).AddTicks(4731) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("853988db-ad55-4a28-9782-90438c64b62d"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash", "SecurityStamp", "UpdatedDateTime" },
                values: new object[] { "8cd29fc7-6310-4633-8016-ae9674acc6cd", new DateTime(2024, 5, 27, 9, 3, 13, 769, DateTimeKind.Utc).AddTicks(9734), "AQAAAAIAAYagAAAAEIkMe8MGqK3KkM43aYcPWSMW4fuUNV/QhvGEkZhR678qyvJLhk3Erym2OrAAasypaA==", "01fed7bf-8af7-470f-862c-eaffb112598e", new DateTime(2024, 5, 27, 9, 3, 13, 769, DateTimeKind.Utc).AddTicks(9737) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("85d8a27f-9d32-4269-b5d0-844589d498d0"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash", "SecurityStamp", "UpdatedDateTime" },
                values: new object[] { "8daa8c87-a21b-4b91-b6c9-f6056682b3ee", new DateTime(2024, 5, 27, 9, 3, 5, 993, DateTimeKind.Utc).AddTicks(441), "AQAAAAIAAYagAAAAELCpldukycysekGbkyGYZIYnYN2vsXmzaugxazBLjUBwd0NDdbCnS6E5o4EbvOP/qA==", "e5e738ed-4e7c-43a3-a74d-46bda4ec0ec4", new DateTime(2024, 5, 27, 9, 3, 5, 993, DateTimeKind.Utc).AddTicks(443) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("870559eb-5fde-4764-ade7-392b0cf6b5ce"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash", "SecurityStamp", "UpdatedDateTime" },
                values: new object[] { "174f8015-cda9-4a16-9d90-3a9630c8ef00", new DateTime(2024, 5, 27, 9, 3, 13, 968, DateTimeKind.Utc).AddTicks(639), "AQAAAAIAAYagAAAAEFAFPZGCAj19Nb1rCRSmPnU8uH6atYwd4yx0J+MwsNUzInUKgXm5KSLc/74j5QdwsQ==", "06a5424e-f3bd-4b38-8d78-46d28fa284a4", new DateTime(2024, 5, 27, 9, 3, 13, 968, DateTimeKind.Utc).AddTicks(641) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("87787f6e-729b-436b-bcc9-c7b48c45ba05"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash", "SecurityStamp", "UpdatedDateTime" },
                values: new object[] { "8e119894-ed73-46f9-9b8e-1020f40142b0", new DateTime(2024, 5, 27, 9, 3, 13, 85, DateTimeKind.Utc).AddTicks(8428), "AQAAAAIAAYagAAAAEPEECBy1Z2ydrS7kxmH9YMN/JkaeQXll3ZbSgVEMNpancuqgkg2dh3te/xUTzEr8cw==", "eab92b85-2f87-4ab9-803a-18fc18cbc482", new DateTime(2024, 5, 27, 9, 3, 13, 85, DateTimeKind.Utc).AddTicks(8430) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("8c3b46b9-1321-4d97-a193-5fa49234d185"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash", "SecurityStamp", "UpdatedDateTime" },
                values: new object[] { "a67c3048-f0f3-424a-9442-ac5caa7d9555", new DateTime(2024, 5, 27, 9, 3, 8, 299, DateTimeKind.Utc).AddTicks(1749), "AQAAAAIAAYagAAAAENjyUQWxrSUwbGLNlil9VnHfHn5EXJEozLL90R1OF/Fp9k9O4H+664oC00LPX2do0A==", "f9d9c7f0-e03d-4cac-ade6-7c0419db82a5", new DateTime(2024, 5, 27, 9, 3, 8, 299, DateTimeKind.Utc).AddTicks(1751) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("906f192a-96d3-433a-a7ea-288662b5f62d"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash", "SecurityStamp", "UpdatedDateTime" },
                values: new object[] { "7c2faf84-e8f2-475d-bc42-fe31bcbde2ee", new DateTime(2024, 5, 27, 9, 3, 12, 769, DateTimeKind.Utc).AddTicks(8765), "AQAAAAIAAYagAAAAEHw13bDR8T2U/VIsrcUwEikcBA8vMmVuhmJb2Pju+8x42cXTx49RXsBX0lCfjZdY/g==", "6ec55a0f-96e5-461f-9daa-c9f31eb2daf8", new DateTime(2024, 5, 27, 9, 3, 12, 769, DateTimeKind.Utc).AddTicks(8768) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("91d0da1b-e147-4829-aa4e-7073c1a10d2c"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash", "SecurityStamp", "UpdatedDateTime" },
                values: new object[] { "c6c76393-8708-402b-9e78-647842f87bf5", new DateTime(2024, 5, 27, 9, 3, 13, 269, DateTimeKind.Utc).AddTicks(4379), "AQAAAAIAAYagAAAAEOEdXCg2c7x1Wi9eqIqfFNt36o2RMdkL5Sx17RFtNFGENLX4+pApdX1f0XFaXh7b2w==", "75f41eb4-422b-4292-954c-1dac48efe975", new DateTime(2024, 5, 27, 9, 3, 13, 269, DateTimeKind.Utc).AddTicks(4381) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("9a4a34a4-4b12-4c8e-a52b-5fa49234d195"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash", "SecurityStamp", "UpdatedDateTime" },
                values: new object[] { "1e5b0e01-b23c-4627-ae40-a54a2ee10adb", new DateTime(2024, 5, 27, 9, 3, 10, 743, DateTimeKind.Utc).AddTicks(9962), "AQAAAAIAAYagAAAAENfBhCFRGZ/4+v+MC7jY/xgFozobnEn0Ayg7X7aPaYil+iq4Pnz+fF3bEEd6ye5O5w==", "60d71a6b-2bb7-4230-9359-33cbb80d9332", new DateTime(2024, 5, 27, 9, 3, 10, 743, DateTimeKind.Utc).AddTicks(9965) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("9b8c6d7b-754f-420c-b574-4a63326bfc6a"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash", "SecurityStamp", "UpdatedDateTime" },
                values: new object[] { "a8a63f84-62af-4e1f-9f5d-82603102841c", new DateTime(2024, 5, 27, 9, 3, 13, 569, DateTimeKind.Utc).AddTicks(9888), "AQAAAAIAAYagAAAAEOiSM5yfYqs/grXyt5HqwllpIdCmB7rP4hdbBfCAXbfpmM2PgtWM7dbw/UQmiCzwww==", "7a389417-99ef-4354-a7f9-a38e58a69307", new DateTime(2024, 5, 27, 9, 3, 13, 569, DateTimeKind.Utc).AddTicks(9890) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("9d36fef6-9c75-4f96-a951-5fa49234d203"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash", "SecurityStamp", "UpdatedDateTime" },
                values: new object[] { "2dffa424-3e24-40c4-8a0b-b920eb44bf2e", new DateTime(2024, 5, 27, 9, 3, 12, 377, DateTimeKind.Utc).AddTicks(7177), "AQAAAAIAAYagAAAAEKMLoRLXlNMAPAw4WzJ/p0b+qvDAS4iNu1Py9f7HXliEKJ45VIhnT0xjCFChl4kMzw==", "97e0d840-a02d-4f6e-b597-a6edf851f27d", new DateTime(2024, 5, 27, 9, 3, 12, 377, DateTimeKind.Utc).AddTicks(7179) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("b2687ce8-aad5-4d5f-849b-dcd2b402aff0"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash", "SecurityStamp", "UpdatedDateTime" },
                values: new object[] { "866506a9-1948-47a0-8064-284cf69c69fc", new DateTime(2024, 5, 27, 9, 3, 14, 158, DateTimeKind.Utc).AddTicks(8361), "AQAAAAIAAYagAAAAEE87i28BDcGYsk1Id8lq0vKVSMCSxPGwkf/hvlUMLteyiXuALp5RnSNLH4WJ7UrDhA==", "6d7bc417-2d00-4e07-9e77-821402882cd7", new DateTime(2024, 5, 27, 9, 3, 14, 158, DateTimeKind.Utc).AddTicks(8363) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("b6123f4e-3443-41ae-a1cb-5fa49234d187"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash", "SecurityStamp", "UpdatedDateTime" },
                values: new object[] { "2fe3ad03-e268-4c61-b4a6-47d91f323594", new DateTime(2024, 5, 27, 9, 3, 8, 722, DateTimeKind.Utc).AddTicks(3044), "AQAAAAIAAYagAAAAEOgwiweChDnFBNT1a7o+vssZvUfAjbeOeaLo1C86hX4kqBQk70mVPyBZwjbViNHK5w==", "e21c3774-b67f-465f-afdf-e27705bcd5c5", new DateTime(2024, 5, 27, 9, 3, 8, 722, DateTimeKind.Utc).AddTicks(3047) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("c0a7e4f4-d8d0-4c80-8e1c-5fa49234d201"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash", "SecurityStamp", "UpdatedDateTime" },
                values: new object[] { "eb3fc4de-6da2-4bc3-8ce6-7c7677408e86", new DateTime(2024, 5, 27, 9, 3, 12, 49, DateTimeKind.Utc).AddTicks(6618), "AQAAAAIAAYagAAAAEPW2qykpqZ8ieCtSMJpKuCC7eoKOjCtq7XgQDkODqGDMbsoCfVts6E+ljIIh89ChBw==", "7122ade4-4c32-4088-8faa-7636d2575874", new DateTime(2024, 5, 27, 9, 3, 12, 49, DateTimeKind.Utc).AddTicks(6620) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("c55cdfd0-d1dd-4841-ae27-f2d621686756"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash", "SecurityStamp", "UpdatedDateTime" },
                values: new object[] { "a48a55eb-3c07-44ac-9a78-c33106df23b4", new DateTime(2024, 5, 27, 9, 3, 12, 898, DateTimeKind.Utc).AddTicks(1527), "AQAAAAIAAYagAAAAEDhlEmfJD5dfz6g7tz9m83L5gh2KBfWqjMidw7u1cLR7t3UQE539MHOjtxa+g+cyYA==", "d3d776fb-03c6-404a-925a-475110a0c73d", new DateTime(2024, 5, 27, 9, 3, 12, 898, DateTimeKind.Utc).AddTicks(1529) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("d0e03a1a-21c2-4123-a75e-5fa49234d191"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash", "SecurityStamp", "UpdatedDateTime" },
                values: new object[] { "c3fe3193-688b-42e2-bdbd-e49779ffc1d0", new DateTime(2024, 5, 27, 9, 3, 9, 775, DateTimeKind.Utc).AddTicks(7726), "AQAAAAIAAYagAAAAENnJcXRVXoXs57P6cVVGnTn630UIZpMA3FBQLfQrw6SWlxOiFt9JJOIVopca7mozXw==", "90b6e416-e9d3-435a-ac27-e569c026f403", new DateTime(2024, 5, 27, 9, 3, 9, 775, DateTimeKind.Utc).AddTicks(7731) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("d30fa796-5144-4467-a302-68dc64fd0d92"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash", "SecurityStamp", "UpdatedDateTime" },
                values: new object[] { "20f320cd-9b37-4743-8eb5-97d4f3574f0e", new DateTime(2024, 5, 27, 9, 3, 13, 179, DateTimeKind.Utc).AddTicks(2325), "AQAAAAIAAYagAAAAEFXsVDO6Gm4mZnQTl1MnE8lMjugGxi9OFOAkbG4kMJiYxSj9mAEhscndgVs4lDV42w==", "f1164b51-f5e6-4976-8a7f-f9aee8445af9", new DateTime(2024, 5, 27, 9, 3, 13, 179, DateTimeKind.Utc).AddTicks(2327) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e92c6f32-859b-443b-bfb2-bd0674b5673a"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash", "SecurityStamp", "UpdatedDateTime" },
                values: new object[] { "4b56e88f-bd57-497e-a7dc-37aa65eb69e5", new DateTime(2024, 5, 27, 9, 3, 12, 583, DateTimeKind.Utc).AddTicks(8415), "AQAAAAIAAYagAAAAECWOl3aEKtV4qBMQoOyH3O8T6oBOpWZtrjegoJqhAKFo/k02hub8LxybPkQPZPdlzA==", "b5291058-0c76-470e-8ba5-a5257db2ceb7", new DateTime(2024, 5, 27, 9, 3, 12, 583, DateTimeKind.Utc).AddTicks(8417) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("eee6e626-9a26-4f38-bbe3-433d20440ce9"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash", "SecurityStamp", "UpdatedDateTime" },
                values: new object[] { "d659548d-72a2-4ada-948d-e26c36b334e5", new DateTime(2024, 5, 27, 9, 3, 7, 313, DateTimeKind.Utc).AddTicks(740), "AQAAAAIAAYagAAAAEI2Q8wi7BrLOUIpLlmKi9TXrmpmyfDc8SxFuHtA99DSLD0i651U+7E5J+Y0Ka2AhWg==", "29308e54-710f-4179-ab37-f5df7a8b7939", new DateTime(2024, 5, 27, 9, 3, 7, 313, DateTimeKind.Utc).AddTicks(742) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("eeed5a4d-e83d-4032-8c3c-5fa49234d197"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash", "SecurityStamp", "UpdatedDateTime" },
                values: new object[] { "4af127a3-3e56-4370-ae6c-48345605e3b7", new DateTime(2024, 5, 27, 9, 3, 11, 150, DateTimeKind.Utc).AddTicks(3219), "AQAAAAIAAYagAAAAEI0ZBKkvwbSzZHZ4Zq5RER+bjEBwWUrd13ZYuLPjwXfAB+qjJoSNcSENXpRvNemAVw==", "f73029a6-c568-4b67-8437-b783f0e7de61", new DateTime(2024, 5, 27, 9, 3, 11, 150, DateTimeKind.Utc).AddTicks(3222) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("f483fb9f-477c-4a3a-9f73-3b028b06ed49"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash", "SecurityStamp", "UpdatedDateTime" },
                values: new object[] { "da61ccdf-68e4-4451-a5ad-c296b041178e", new DateTime(2024, 5, 27, 9, 3, 12, 996, DateTimeKind.Utc).AddTicks(5266), "AQAAAAIAAYagAAAAEP2Ssk8LUyXhBZ4QPTPWCP4h2eAIqWHvxMITMRNqEtE6qkvx7mtZ01R1hfSpTk6crA==", "3f615cef-79d1-4ba4-9830-0dcfae7c674d", new DateTime(2024, 5, 27, 9, 3, 12, 996, DateTimeKind.Utc).AddTicks(5271) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("fbd62259-a313-4d38-885e-1f6acdf9a30a"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash", "SecurityStamp", "UpdatedDateTime" },
                values: new object[] { "0ea7bf64-a7e7-4df8-b617-8259154bf8b0", new DateTime(2024, 5, 27, 9, 3, 13, 412, DateTimeKind.Utc).AddTicks(8405), "AQAAAAIAAYagAAAAEBj+yrdztzY8gkb8dku0YtCJfOLOPEhuJc5Wiqaf9YVgu1FNxLeVS+E1CM/n8xd8Nw==", "98241317-daaf-4514-b5b4-ae073b658b3d", new DateTime(2024, 5, 27, 9, 3, 13, 412, DateTimeKind.Utc).AddTicks(8411) });

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: new Guid("292c90a5-1a0a-45a4-8f3d-37f09b09b422"),
                columns: new[] { "CreatedDateTime", "UpdatedDateTime" },
                values: new object[] { new DateTime(2024, 5, 27, 9, 3, 14, 254, DateTimeKind.Utc).AddTicks(3953), new DateTime(2024, 5, 27, 9, 3, 14, 254, DateTimeKind.Utc).AddTicks(3954) });

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: new Guid("2baf4c50-c927-4b54-971e-3ff5f300e147"),
                columns: new[] { "CreatedDateTime", "UpdatedDateTime" },
                values: new object[] { new DateTime(2024, 5, 27, 9, 3, 14, 254, DateTimeKind.Utc).AddTicks(3941), new DateTime(2024, 5, 27, 9, 3, 14, 254, DateTimeKind.Utc).AddTicks(3943) });

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: new Guid("97cf6bd7-7290-449a-a61d-5ea2fdfcf8de"),
                columns: new[] { "CreatedDateTime", "UpdatedDateTime" },
                values: new object[] { new DateTime(2024, 5, 27, 9, 3, 14, 254, DateTimeKind.Utc).AddTicks(3955), new DateTime(2024, 5, 27, 9, 3, 14, 254, DateTimeKind.Utc).AddTicks(3956) });

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: new Guid("99ada3c1-eea5-4431-a529-b3114de224da"),
                columns: new[] { "CreatedDateTime", "UpdatedDateTime" },
                values: new object[] { new DateTime(2024, 5, 27, 9, 3, 14, 254, DateTimeKind.Utc).AddTicks(3947), new DateTime(2024, 5, 27, 9, 3, 14, 254, DateTimeKind.Utc).AddTicks(3948) });

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: new Guid("adf36edc-3e08-4a36-8e20-0d79747f0962"),
                columns: new[] { "CreatedDateTime", "UpdatedDateTime" },
                values: new object[] { new DateTime(2024, 5, 27, 9, 3, 14, 254, DateTimeKind.Utc).AddTicks(3950), new DateTime(2024, 5, 27, 9, 3, 14, 254, DateTimeKind.Utc).AddTicks(3951) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("9243d741-a350-4067-bb29-395e9becf57e"),
                column: "CreatedDateTime",
                value: new DateTime(2024, 5, 27, 9, 3, 14, 255, DateTimeKind.Utc).AddTicks(4867));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("e21f3a87-20d5-420e-ba33-9108df996747"),
                column: "CreatedDateTime",
                value: new DateTime(2024, 5, 27, 9, 3, 14, 255, DateTimeKind.Utc).AddTicks(4889));

            migrationBuilder.CreateIndex(
                name: "IX_Products_IsDelete",
                table: "Products",
                column: "IsDelete");

            migrationBuilder.CreateIndex(
                name: "IX_Products_Name",
                table: "Products",
                column: "Name");
        }
    }
}
