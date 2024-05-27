using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shoppy.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Remove_sku_product : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_Orders_OrderId",
                table: "OrderItems");

            migrationBuilder.DropIndex(
                name: "IX_Products_Sku",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Sku",
                table: "Products");

            migrationBuilder.AlterColumn<Guid>(
                name: "OrderId",
                table: "OrderItems",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

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

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_Orders_OrderId",
                table: "OrderItems",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_Orders_OrderId",
                table: "OrderItems");

            migrationBuilder.AddColumn<string>(
                name: "Sku",
                table: "Products",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<Guid>(
                name: "OrderId",
                table: "OrderItems",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("021657c8-d4d0-4167-a1a6-b7bb840f33bf"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash", "SecurityStamp", "UpdatedDateTime" },
                values: new object[] { "d7d7c2a4-715f-4749-ab3d-877a454b3e9b", new DateTime(2024, 5, 23, 10, 40, 45, 259, DateTimeKind.Utc).AddTicks(6242), "AQAAAAIAAYagAAAAEO0JirRhqFpTliskbh90TSmiFvEa/wu4kaRJf2kvuxShdHr345sdT1z1ZPTpXQFnhw==", "907d8928-49c4-40f7-9a56-4326cdc8b75c", new DateTime(2024, 5, 23, 10, 40, 45, 259, DateTimeKind.Utc).AddTicks(6247) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("0cd66cfc-5d48-4f5e-b22d-5fa49234d192"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash", "SecurityStamp", "UpdatedDateTime" },
                values: new object[] { "3ba07d7d-f31d-49de-a1b6-9a58f65d7e57", new DateTime(2024, 5, 23, 10, 40, 46, 872, DateTimeKind.Utc).AddTicks(2632), "AQAAAAIAAYagAAAAEKYL6Vt2+zGkyupPoLA46TwpYuDZR7xgylPBvE5EdU3Yi/Jsy8XsK5c8Bx5mKR+b+g==", "9dbd618d-f482-403f-ad35-43bb1775d6c8", new DateTime(2024, 5, 23, 10, 40, 46, 872, DateTimeKind.Utc).AddTicks(2637) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("1d2b5cf5-0ad7-4c3a-b4b9-5fa49234d202"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash", "SecurityStamp", "UpdatedDateTime" },
                values: new object[] { "be7d2ba5-710a-4f4a-9ade-cc7728b1cf84", new DateTime(2024, 5, 23, 10, 40, 47, 770, DateTimeKind.Utc).AddTicks(2009), "AQAAAAIAAYagAAAAELf/YrlVQVbdhmZce/CcLMoHRHp0tF+pgzPuTpDV3ryTThJKHY0MXT3nTKKihHZhuA==", "8bd4aa5a-5821-400a-b08c-5f621ccf7d5e", new DateTime(2024, 5, 23, 10, 40, 47, 770, DateTimeKind.Utc).AddTicks(2012) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("296dbab2-62f2-4eb6-ae53-e4c7fffdaf34"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash", "SecurityStamp", "UpdatedDateTime" },
                values: new object[] { "53536eba-7aa5-4fd7-8692-2a6da018304a", new DateTime(2024, 5, 23, 10, 40, 49, 292, DateTimeKind.Utc).AddTicks(5480), "AQAAAAIAAYagAAAAEObOuEJf29aSqaaqGgL4i7AO/Y04CNLQgvmiRp2DCZexHV6k2vEoifiDWS+RDK3DTg==", "76329c7e-da9e-41c5-bb16-9a2939b46e27", new DateTime(2024, 5, 23, 10, 40, 49, 292, DateTimeKind.Utc).AddTicks(5483) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("2b844c01-c89e-4d24-a5d8-5fa49234d198"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash", "SecurityStamp", "UpdatedDateTime" },
                values: new object[] { "0cd1879f-a8d3-4a47-965d-03ee9b643c97", new DateTime(2024, 5, 23, 10, 40, 47, 411, DateTimeKind.Utc).AddTicks(5499), "AQAAAAIAAYagAAAAEDh7oWVK5cSmSrxgJNJoacDhNZFLHatDwNNTBeJtd3+Z+I+Rcep56zOZOwTgey+yhQ==", "be923359-08c0-4b83-83c7-b84ac7c91d0c", new DateTime(2024, 5, 23, 10, 40, 47, 411, DateTimeKind.Utc).AddTicks(5501) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("2c44d375-c725-4279-b2d3-87ea4218f385"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash", "SecurityStamp", "UpdatedDateTime" },
                values: new object[] { "5168d847-693e-4665-b225-a9715efb47a5", new DateTime(2024, 5, 23, 10, 40, 48, 125, DateTimeKind.Utc).AddTicks(5945), "AQAAAAIAAYagAAAAEKhRFre7Wkoz2/GADEfqLna1LGlyn+visUadeN2zlb6dQKG1phMhHQjYpvlJDoL6mQ==", "bc1d1b29-9c0c-475f-ab7b-40709b0d02d6", new DateTime(2024, 5, 23, 10, 40, 48, 125, DateTimeKind.Utc).AddTicks(5947) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("2c96fabb-f759-43ef-9a31-328c25d2eff5"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash", "SecurityStamp", "UpdatedDateTime" },
                values: new object[] { "248f1995-3c0b-450f-ad1e-3c1f393fb004", new DateTime(2024, 5, 23, 10, 40, 45, 386, DateTimeKind.Utc).AddTicks(617), "AQAAAAIAAYagAAAAEB2iekaYGVitiPQcrSSgH2XdQaBvyDUnFgVmaqhbxAXLStD82xN25g7/ph2BrI+gPQ==", "b44585fc-a5ab-4722-a18c-fc0ad0055825", new DateTime(2024, 5, 23, 10, 40, 45, 386, DateTimeKind.Utc).AddTicks(620) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("2d3d5b2d-b5a3-4b89-84b3-5fa49234d186"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash", "SecurityStamp", "UpdatedDateTime" },
                values: new object[] { "63c71bf8-a654-4344-83e4-9a172f57580c", new DateTime(2024, 5, 23, 10, 40, 46, 336, DateTimeKind.Utc).AddTicks(4966), "AQAAAAIAAYagAAAAEKLFpHTqKd8ss9akNsZlt+knWcYAY8yeeNE8qP6cMvTLrSHAxF2A2AfDUIuk8n+KeQ==", "b9e17ef5-b515-474a-8bed-b2340c6962c6", new DateTime(2024, 5, 23, 10, 40, 46, 336, DateTimeKind.Utc).AddTicks(4969) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("30a4345d-df2e-46ab-8c0e-d38a7933b591"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash", "SecurityStamp", "UpdatedDateTime" },
                values: new object[] { "1931d749-7322-4099-95bd-3354e079a136", new DateTime(2024, 5, 23, 10, 40, 45, 508, DateTimeKind.Utc).AddTicks(4526), "AQAAAAIAAYagAAAAEJYEwxXYMqnrIjrb7eTFuxA8QHFKiDIEsw9WgT6FYwx5fMoeva0+By2pIiRSNwFePA==", "9fefbc7d-70f9-4616-88fb-8c7ee7218773", new DateTime(2024, 5, 23, 10, 40, 45, 508, DateTimeKind.Utc).AddTicks(4529) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("31e7a1a6-9a5d-4b4e-84eb-5fa49234d190"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash", "SecurityStamp", "UpdatedDateTime" },
                values: new object[] { "7c0d1c7a-c668-4d93-994b-a7b255f338f4", new DateTime(2024, 5, 23, 10, 40, 46, 694, DateTimeKind.Utc).AddTicks(7994), "AQAAAAIAAYagAAAAEGWSO0j1o5uoxvj/La7Y5NS4W951eg5JLBVleqYCWc8mMta1tBBklJ0ZJC1bXNIpUA==", "34c9d7e0-2513-4ff2-926d-98c686175259", new DateTime(2024, 5, 23, 10, 40, 46, 694, DateTimeKind.Utc).AddTicks(7998) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("35d6cf06-f0ef-47a6-a4bd-5fa49234d196"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash", "SecurityStamp", "UpdatedDateTime" },
                values: new object[] { "28e87ce7-24ef-4f8b-9a39-518a1939b451", new DateTime(2024, 5, 23, 10, 40, 47, 233, DateTimeKind.Utc).AddTicks(6178), "AQAAAAIAAYagAAAAEHPxCR/Mj80H1p1IDvAB/bMVURddqsogWF+7vG9WA0+JOu9ENlL/bFeASshGqaA48w==", "c19a925f-1758-464c-8897-5b065bccaf98", new DateTime(2024, 5, 23, 10, 40, 47, 233, DateTimeKind.Utc).AddTicks(6181) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("3d77db7b-3b3e-4a38-a1d1-5fa49234d200"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash", "SecurityStamp", "UpdatedDateTime" },
                values: new object[] { "866ea7e8-c1e3-48fd-b90a-53d02bc6797b", new DateTime(2024, 5, 23, 10, 40, 47, 589, DateTimeKind.Utc).AddTicks(5913), "AQAAAAIAAYagAAAAEKsweyeNI4/nGn73F+VEA/FhEbFbTvRCk5GY/P1ADq9RbsHAMLO3OLH0U3iskL6x9w==", "e8aeafa8-9cdf-4d8a-8b67-a242fd34cbc0", new DateTime(2024, 5, 23, 10, 40, 47, 589, DateTimeKind.Utc).AddTicks(5916) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("4a8b3d09-78f2-43ad-bce6-5fa49234d189"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash", "SecurityStamp", "UpdatedDateTime" },
                values: new object[] { "e3110da3-7cd2-4719-b3ab-a279b01a0ed9", new DateTime(2024, 5, 23, 10, 40, 46, 605, DateTimeKind.Utc).AddTicks(5520), "AQAAAAIAAYagAAAAEBJevmUp4nXjyifKwEDEKb6qW+LZbVF6b/YogbNJfL/hdoocaZheUiUNteuGqohf4Q==", "6ab8434b-ab38-43e6-b398-589b5bdb8a71", new DateTime(2024, 5, 23, 10, 40, 46, 605, DateTimeKind.Utc).AddTicks(5523) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("50b95f41-7afa-4cda-aa7a-5fa49234d183"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash", "SecurityStamp", "UpdatedDateTime" },
                values: new object[] { "1859509f-5cb2-44dd-bc90-7adc71d1a969", new DateTime(2024, 5, 23, 10, 40, 46, 62, DateTimeKind.Utc).AddTicks(4253), "AQAAAAIAAYagAAAAEI62aDjd3cg30AkvZp2GoW1gGXGmwOvKlaPWG2g87BAtd+VqyJNxidqH2B4WDCaq+A==", "68d1a913-06d2-4138-a58e-e3589d66a03d", new DateTime(2024, 5, 23, 10, 40, 46, 62, DateTimeKind.Utc).AddTicks(4257) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("50b95f41-7afa-4cda-aa7a-5fa49234d184"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash", "SecurityStamp", "UpdatedDateTime" },
                values: new object[] { "cac5dfb6-15e9-45cb-adb8-2f6e0a1081ee", new DateTime(2024, 5, 23, 10, 40, 46, 152, DateTimeKind.Utc).AddTicks(7537), "AQAAAAIAAYagAAAAED6AfUO0XietcR+oQylBPQXaZvjjzflQ3Hg+Lj1KVk4S5mGjRNpRu5TcVSKE21455g==", "635e960d-adb6-4002-a669-2542542e2428", new DateTime(2024, 5, 23, 10, 40, 46, 152, DateTimeKind.Utc).AddTicks(7541) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("56b2a1c9-a651-4fee-8f8e-5fa49234d199"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash", "SecurityStamp", "UpdatedDateTime" },
                values: new object[] { "60f0eede-5e5a-4757-b6fc-e2c5dfd7994b", new DateTime(2024, 5, 23, 10, 40, 47, 501, DateTimeKind.Utc).AddTicks(3740), "AQAAAAIAAYagAAAAEJk8EkUsQQG1ARn1kBfhYD8kZQYZXEzJ+ZIZ068apHz4pb4WKAAqZAdAFJJM/scR4w==", "27261cc7-cb36-4854-9bbd-d011027ba3f7", new DateTime(2024, 5, 23, 10, 40, 47, 501, DateTimeKind.Utc).AddTicks(3744) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("594f8fe1-1cf1-4f5a-a8ae-6b9509fbf283"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash", "SecurityStamp", "UpdatedDateTime" },
                values: new object[] { "7ad81020-c7fe-4854-8f13-fb4128fc6478", new DateTime(2024, 5, 23, 10, 40, 45, 659, DateTimeKind.Utc).AddTicks(8203), "AQAAAAIAAYagAAAAECAgV/yF3eTnw3DQp4qdNCA/qyzE6Q/RaqAmy0g3R0RRo3UBviZ3KuiLyDllilhmkA==", "b6588cf0-7a84-420a-86b3-c2356743db15", new DateTime(2024, 5, 23, 10, 40, 45, 659, DateTimeKind.Utc).AddTicks(8206) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("5aca3775-d37e-473c-8f3a-3926ed32e360"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash", "SecurityStamp", "UpdatedDateTime" },
                values: new object[] { "1f242ade-361e-43d8-8179-484c0864c251", new DateTime(2024, 5, 23, 10, 40, 47, 947, DateTimeKind.Utc).AddTicks(3075), "AQAAAAIAAYagAAAAEFGnuph9xfPyZlMGKwM400PBzZUa75b4Kb8qKnuAfXcha0SxMHk2Jxydaw0aZ0Q+rA==", "c37ca680-bb13-4632-bddf-503fb48302e4", new DateTime(2024, 5, 23, 10, 40, 47, 947, DateTimeKind.Utc).AddTicks(3078) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("5c6a5f5e-3a11-4d42-bff8-5fa49234d188"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash", "SecurityStamp", "UpdatedDateTime" },
                values: new object[] { "88dde066-ac18-4464-8cd2-edeee7a9496a", new DateTime(2024, 5, 23, 10, 40, 46, 516, DateTimeKind.Utc).AddTicks(7583), "AQAAAAIAAYagAAAAEI1y9kh4F3KkRi4ks9pq5DdShP++D1Bmstq4xGKMDUE6bq0jwZGyejnhbPOZvVkz9w==", "620433da-ba98-4f6f-959b-8a330478e89e", new DateTime(2024, 5, 23, 10, 40, 46, 516, DateTimeKind.Utc).AddTicks(7586) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("60a119e1-610c-42fc-85c8-95a7e4d2119b"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash", "SecurityStamp", "UpdatedDateTime" },
                values: new object[] { "112c20a9-2cae-469b-968e-46d99bb70d1b", new DateTime(2024, 5, 23, 10, 40, 49, 110, DateTimeKind.Utc).AddTicks(5504), "AQAAAAIAAYagAAAAEJ61oIjv3/QXlUB0xVka84RsSjUDKvJS/YnaAODyfapi3EFM4r7HG14z0l2klwXL6w==", "a8c7eb85-f3dc-4b94-9827-c28cc086cdd2", new DateTime(2024, 5, 23, 10, 40, 49, 110, DateTimeKind.Utc).AddTicks(5506) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("60b9f0cc-b3b4-4ac3-a9ce-5fa49234d193"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash", "SecurityStamp", "UpdatedDateTime" },
                values: new object[] { "cca881af-1882-4084-b6a6-1be1abd1c0b9", new DateTime(2024, 5, 23, 10, 40, 46, 960, DateTimeKind.Utc).AddTicks(4827), "AQAAAAIAAYagAAAAEKp0qYqhspnOjhwag347ybacj2YfAsDShHtntb7xlOHjy53j21QuqV09dFH6RK10Ww==", "a0eea84a-39c5-4e50-bec8-1a54d7abd93a", new DateTime(2024, 5, 23, 10, 40, 46, 960, DateTimeKind.Utc).AddTicks(4831) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("6c16a235-f928-4b8d-978f-5fa49234d194"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash", "SecurityStamp", "UpdatedDateTime" },
                values: new object[] { "2fadc8f6-ccf3-4e9b-a553-62c7591e4bf2", new DateTime(2024, 5, 23, 10, 40, 47, 54, DateTimeKind.Utc).AddTicks(7724), "AQAAAAIAAYagAAAAEBY9jz1oZ5qgw8CdkEMGi5Il2bbiP/ayc6PSsTM+sdkzL8HMUnPmaH8Aj0L29IeKew==", "67c31f0b-4a8e-4b42-bc4e-76d130b71542", new DateTime(2024, 5, 23, 10, 40, 47, 54, DateTimeKind.Utc).AddTicks(7726) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("6e2f7a2d-1994-419b-8c6d-b3d297cd7b06"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash", "SecurityStamp", "UpdatedDateTime" },
                values: new object[] { "100e9fbb-ec09-4009-ad3b-afee82627dec", new DateTime(2024, 5, 23, 10, 40, 48, 932, DateTimeKind.Utc).AddTicks(3963), "AQAAAAIAAYagAAAAEPCaYp49aFomBZmxkNqJSfo8mKx5aKR5vcr+unuH9ftWG1JPHrFXY9LpMN6ZGhCsqQ==", "cfecfe5c-16e7-41cb-a2f3-a1dc392ec126", new DateTime(2024, 5, 23, 10, 40, 48, 932, DateTimeKind.Utc).AddTicks(3966) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("7db124bd-9953-4eb0-98f2-50b1be635544"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash", "SecurityStamp", "UpdatedDateTime" },
                values: new object[] { "154c0ed0-b503-4d38-a949-699846cdab21", new DateTime(2024, 5, 23, 10, 40, 45, 961, DateTimeKind.Utc).AddTicks(995), "AQAAAAIAAYagAAAAEIzGYJBfL0qGKBd7bZJsmVlurXazHMaBVv4zvI0Y8VjVK/bn5YfqzijlNerKhE+0OQ==", "b7255ce4-c94e-4f7f-b7d2-922cb99419e0", new DateTime(2024, 5, 23, 10, 40, 45, 961, DateTimeKind.Utc).AddTicks(998) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("853988db-ad55-4a28-9782-90438c64b62d"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash", "SecurityStamp", "UpdatedDateTime" },
                values: new object[] { "efb76e50-9f56-4743-8e43-59eed9f70801", new DateTime(2024, 5, 23, 10, 40, 49, 21, DateTimeKind.Utc).AddTicks(8584), "AQAAAAIAAYagAAAAELCYTiEV1Y/5U90UDaBlr4SdxJmZqz9oAHz6ItFBPALl3gtNw9u63oeU3YAnXRAe/Q==", "d50f8a15-9fec-4d32-b29a-6275ced63a20", new DateTime(2024, 5, 23, 10, 40, 49, 21, DateTimeKind.Utc).AddTicks(8587) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("85d8a27f-9d32-4269-b5d0-844589d498d0"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash", "SecurityStamp", "UpdatedDateTime" },
                values: new object[] { "019eed35-7b7e-40f9-9813-4d5b7acfb634", new DateTime(2024, 5, 23, 10, 40, 45, 139, DateTimeKind.Utc).AddTicks(3765), "AQAAAAIAAYagAAAAEJlCsvetadiQZosvHLI8C1tkDe8RT/5dmvf1JnD//tUFOM01zX0wODDd9rEzzpQmjA==", "fc65e101-c4dc-476a-b188-a9338bca8334", new DateTime(2024, 5, 23, 10, 40, 45, 139, DateTimeKind.Utc).AddTicks(3767) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("870559eb-5fde-4764-ade7-392b0cf6b5ce"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash", "SecurityStamp", "UpdatedDateTime" },
                values: new object[] { "2899ec07-c9e3-4fa9-a368-7f55c5700517", new DateTime(2024, 5, 23, 10, 40, 49, 201, DateTimeKind.Utc).AddTicks(8347), "AQAAAAIAAYagAAAAEKPKiS4qnFfE3zr3COBN8jMCyRwUCdADTcga0b1iebKow9K8GyyBT37+O0bI2VrTPQ==", "e3fef432-86a0-42eb-8ffc-f0a6526fb2b9", new DateTime(2024, 5, 23, 10, 40, 49, 201, DateTimeKind.Utc).AddTicks(8349) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("87787f6e-729b-436b-bcc9-c7b48c45ba05"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash", "SecurityStamp", "UpdatedDateTime" },
                values: new object[] { "c574cd94-c2fd-4935-8548-bdc514d2e727", new DateTime(2024, 5, 23, 10, 40, 48, 485, DateTimeKind.Utc).AddTicks(5673), "AQAAAAIAAYagAAAAENSpdfr6v5ciA7iSO1PTEBa9ycrlyU3d5bq4/PG2pCnUNVCTqGl87+6Yaltz6zmUbA==", "38d3d1e1-4482-43d1-94d5-5e3884fd4080", new DateTime(2024, 5, 23, 10, 40, 48, 485, DateTimeKind.Utc).AddTicks(5676) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("8c3b46b9-1321-4d97-a193-5fa49234d185"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash", "SecurityStamp", "UpdatedDateTime" },
                values: new object[] { "53169ca0-f859-41f3-8815-71d2c2d2da26", new DateTime(2024, 5, 23, 10, 40, 46, 246, DateTimeKind.Utc).AddTicks(9750), "AQAAAAIAAYagAAAAEOHP9+5SNK0N3fdbugWyq3JzLSRWIJRczCvMixEv3w1Z1g/5yKU/n+cbsZz+57I0yw==", "e9f1cf21-029b-4cd3-8bfb-d4d86b9cc67f", new DateTime(2024, 5, 23, 10, 40, 46, 246, DateTimeKind.Utc).AddTicks(9753) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("906f192a-96d3-433a-a7ea-288662b5f62d"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash", "SecurityStamp", "UpdatedDateTime" },
                values: new object[] { "1bc75c93-a3bb-4c14-8476-8ffa9eed4b9a", new DateTime(2024, 5, 23, 10, 40, 48, 216, DateTimeKind.Utc).AddTicks(4928), "AQAAAAIAAYagAAAAEOwP8H1a1dehNgBeoe3MGfMcATfvgfTRZ0ukDP3dMnp/KSQWI2gvUv964h4tgx/g+w==", "96dd200b-6e44-43a3-aa32-a6a6b8ad6abe", new DateTime(2024, 5, 23, 10, 40, 48, 216, DateTimeKind.Utc).AddTicks(4932) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("91d0da1b-e147-4829-aa4e-7073c1a10d2c"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash", "SecurityStamp", "UpdatedDateTime" },
                values: new object[] { "09c159b1-6b5e-4f38-9f24-3c5e6dff7795", new DateTime(2024, 5, 23, 10, 40, 48, 666, DateTimeKind.Utc).AddTicks(2128), "AQAAAAIAAYagAAAAEDJ/I3uhG1dW7cz1cdH0va7sEcTLwogl2phyojQEgKBjNy9zw8WKOwmqm0o09YX3jg==", "def2edc9-aa00-46a9-9141-f7b773cbb176", new DateTime(2024, 5, 23, 10, 40, 48, 666, DateTimeKind.Utc).AddTicks(2130) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("9a4a34a4-4b12-4c8e-a52b-5fa49234d195"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash", "SecurityStamp", "UpdatedDateTime" },
                values: new object[] { "35dcdfe7-b9e0-4a47-bc36-911612374edc", new DateTime(2024, 5, 23, 10, 40, 47, 144, DateTimeKind.Utc).AddTicks(317), "AQAAAAIAAYagAAAAEC54Lb2Ohl7rQS4IQcyq9NGt1zULgnbbkyHCbWtTt/ldugMMHtjySZk4QYgvtTGQow==", "ddd87dbd-9df6-4456-b6be-71e706b30adc", new DateTime(2024, 5, 23, 10, 40, 47, 144, DateTimeKind.Utc).AddTicks(320) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("9b8c6d7b-754f-420c-b574-4a63326bfc6a"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash", "SecurityStamp", "UpdatedDateTime" },
                values: new object[] { "162a728f-8d6b-4bef-b307-ce359c055f99", new DateTime(2024, 5, 23, 10, 40, 48, 843, DateTimeKind.Utc).AddTicks(7865), "AQAAAAIAAYagAAAAECOKxoogNyQyxZyATYccrbMKMPbBMmvdrD8suizEzSW0shylfTA8vFaUPCvSeyU/Fg==", "1223b075-eb49-4aa2-a7ea-63fdf640b321", new DateTime(2024, 5, 23, 10, 40, 48, 843, DateTimeKind.Utc).AddTicks(7869) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("9d36fef6-9c75-4f96-a951-5fa49234d203"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash", "SecurityStamp", "UpdatedDateTime" },
                values: new object[] { "d78ff1af-84bd-4b3b-adb9-a4e397172458", new DateTime(2024, 5, 23, 10, 40, 47, 858, DateTimeKind.Utc).AddTicks(5713), "AQAAAAIAAYagAAAAEDAUKW3rH7F/RSA/S2RjfwcpvRhbpVD+MLGUJq3+FZivftVqnbUTfBrM4Sg7sdD9pw==", "8f8748da-2429-4643-a7eb-d0a9bf9ec41a", new DateTime(2024, 5, 23, 10, 40, 47, 858, DateTimeKind.Utc).AddTicks(5715) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("b2687ce8-aad5-4d5f-849b-dcd2b402aff0"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash", "SecurityStamp", "UpdatedDateTime" },
                values: new object[] { "790ead86-51d5-4d23-a596-dd67e5c5e717", new DateTime(2024, 5, 23, 10, 40, 49, 380, DateTimeKind.Utc).AddTicks(5681), "AQAAAAIAAYagAAAAENjnIrTGSxS5hxuViMUn7mjP439Apv3+tbjHAneZBSzXQsQSarxKiSAtWhsvV9y85Q==", "e3244709-37e1-4b94-b7f4-6c6265697c36", new DateTime(2024, 5, 23, 10, 40, 49, 380, DateTimeKind.Utc).AddTicks(5689) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("b6123f4e-3443-41ae-a1cb-5fa49234d187"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash", "SecurityStamp", "UpdatedDateTime" },
                values: new object[] { "6c9e01b9-718f-42bb-b9a8-6c3634e0d2d4", new DateTime(2024, 5, 23, 10, 40, 46, 427, DateTimeKind.Utc).AddTicks(5354), "AQAAAAIAAYagAAAAEMIh5iJS10urqaYpMnq6iWvi8Jx0VbnqqLJmsXmLHYhRiOTndF2UDuPBYAj98M7s6A==", "600dbbbb-9c90-4a80-971e-5e2db3e8ba58", new DateTime(2024, 5, 23, 10, 40, 46, 427, DateTimeKind.Utc).AddTicks(5357) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("c0a7e4f4-d8d0-4c80-8e1c-5fa49234d201"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash", "SecurityStamp", "UpdatedDateTime" },
                values: new object[] { "6b64ad89-88fd-4b2f-94d0-ffed97f1fa33", new DateTime(2024, 5, 23, 10, 40, 47, 680, DateTimeKind.Utc).AddTicks(1867), "AQAAAAIAAYagAAAAEE61tqup78hqG6yBSKFmD7odHAFE9zPdgdg0gECrD196CPfrBdCuCr+vSD+7us7VzA==", "b7f85a16-5750-4a57-a536-7a588efe8d88", new DateTime(2024, 5, 23, 10, 40, 47, 680, DateTimeKind.Utc).AddTicks(1871) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("c55cdfd0-d1dd-4841-ae27-f2d621686756"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash", "SecurityStamp", "UpdatedDateTime" },
                values: new object[] { "00c50dfd-9c22-4e2b-82db-2ca5121fad33", new DateTime(2024, 5, 23, 10, 40, 48, 306, DateTimeKind.Utc).AddTicks(1064), "AQAAAAIAAYagAAAAEKARyp+c8A54pxR20QtZwCjrn8gHEwtsFEu7M8xk1ijW+VUsG0JQx8Go0vXqy4x61g==", "11dd5489-b17d-426d-8ec8-2d07a75be07c", new DateTime(2024, 5, 23, 10, 40, 48, 306, DateTimeKind.Utc).AddTicks(1066) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("d0e03a1a-21c2-4123-a75e-5fa49234d191"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash", "SecurityStamp", "UpdatedDateTime" },
                values: new object[] { "6b9a359c-453e-4928-9631-9a8fa6b61743", new DateTime(2024, 5, 23, 10, 40, 46, 783, DateTimeKind.Utc).AddTicks(6669), "AQAAAAIAAYagAAAAEF9eZjHmZD9z9/WEUonWOQMU7ALCFsvAOjuuO5qMpnxX26bdd3KvqKQBV/P7lXM2ng==", "eae27abc-073d-473e-9e09-38fe5136c6ee", new DateTime(2024, 5, 23, 10, 40, 46, 783, DateTimeKind.Utc).AddTicks(6672) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("d30fa796-5144-4467-a302-68dc64fd0d92"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash", "SecurityStamp", "UpdatedDateTime" },
                values: new object[] { "0afb3eef-8fa9-4cc6-b66b-e91adf41feb0", new DateTime(2024, 5, 23, 10, 40, 48, 575, DateTimeKind.Utc).AddTicks(4558), "AQAAAAIAAYagAAAAEKtPNBnrbEpbugmEVtVyAoYK5bn+Nf1z87xg6904sJcFveWWxCKgLsYTBFpztFtppg==", "01f32b76-9c4c-40f7-b34a-aaf99dbdb5b0", new DateTime(2024, 5, 23, 10, 40, 48, 575, DateTimeKind.Utc).AddTicks(4561) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e92c6f32-859b-443b-bfb2-bd0674b5673a"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash", "SecurityStamp", "UpdatedDateTime" },
                values: new object[] { "08f92a51-f138-40e5-a489-3faf43f35140", new DateTime(2024, 5, 23, 10, 40, 48, 36, DateTimeKind.Utc).AddTicks(5897), "AQAAAAIAAYagAAAAEDqvxV2BQkhiVys6tjH623yFriWgEJsRKa+ChfWe2MunBKf1e29LbXPoS1l7B0NRvA==", "18b205ec-b4a3-436b-943b-720c8b46e726", new DateTime(2024, 5, 23, 10, 40, 48, 36, DateTimeKind.Utc).AddTicks(5900) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("eee6e626-9a26-4f38-bbe3-433d20440ce9"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash", "SecurityStamp", "UpdatedDateTime" },
                values: new object[] { "69744fda-4a6f-459c-b475-db3a0ed5f8fe", new DateTime(2024, 5, 23, 10, 40, 45, 821, DateTimeKind.Utc).AddTicks(8711), "AQAAAAIAAYagAAAAEDSxaJ+D0GNuiF1jLsrGYlS0+lnexeu1H+165kdix4oIY65xieGRP6cQxMxtKyPw9A==", "e7fcff60-47be-4cb2-ac3f-cbb09fd056fa", new DateTime(2024, 5, 23, 10, 40, 45, 821, DateTimeKind.Utc).AddTicks(8714) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("eeed5a4d-e83d-4032-8c3c-5fa49234d197"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash", "SecurityStamp", "UpdatedDateTime" },
                values: new object[] { "25f8468c-cfa5-410c-b4bd-b9c9079fbbab", new DateTime(2024, 5, 23, 10, 40, 47, 321, DateTimeKind.Utc).AddTicks(5496), "AQAAAAIAAYagAAAAECmfBOGEULhB7XF+eRR2bjylM/EH8sE0qBdywUH+lWznRy7mu8BwV/wPqu6VWQKJJA==", "16b6060a-1693-4bcc-af6c-3abc5d9c4514", new DateTime(2024, 5, 23, 10, 40, 47, 321, DateTimeKind.Utc).AddTicks(5499) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("f483fb9f-477c-4a3a-9f73-3b028b06ed49"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash", "SecurityStamp", "UpdatedDateTime" },
                values: new object[] { "df2a3fed-dedb-4a9d-87cd-40ddab22419a", new DateTime(2024, 5, 23, 10, 40, 48, 395, DateTimeKind.Utc).AddTicks(9014), "AQAAAAIAAYagAAAAELwuOFeG9vYJNXHWKP161WGb8szLTouMVgyXJW/rwPBA2RsUhi83uOXItKheQw4ZYA==", "124b3dd2-fe3c-47be-b048-f6d1250b4a6e", new DateTime(2024, 5, 23, 10, 40, 48, 395, DateTimeKind.Utc).AddTicks(9018) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("fbd62259-a313-4d38-885e-1f6acdf9a30a"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash", "SecurityStamp", "UpdatedDateTime" },
                values: new object[] { "551b796c-90ea-48f0-ad91-3b9cba85a4e8", new DateTime(2024, 5, 23, 10, 40, 48, 754, DateTimeKind.Utc).AddTicks(7163), "AQAAAAIAAYagAAAAEOv+s+lkI7ZS3mUFuLXTNu/+gyt/CRbSkakZbftfWL+ryTd69ifuX/kFVmELJO19Lw==", "61d05cbe-5e89-4b8e-9e10-0c0e833675de", new DateTime(2024, 5, 23, 10, 40, 48, 754, DateTimeKind.Utc).AddTicks(7166) });

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: new Guid("292c90a5-1a0a-45a4-8f3d-37f09b09b422"),
                columns: new[] { "CreatedDateTime", "UpdatedDateTime" },
                values: new object[] { new DateTime(2024, 5, 23, 10, 40, 49, 470, DateTimeKind.Utc).AddTicks(3896), new DateTime(2024, 5, 23, 10, 40, 49, 470, DateTimeKind.Utc).AddTicks(3897) });

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: new Guid("2baf4c50-c927-4b54-971e-3ff5f300e147"),
                columns: new[] { "CreatedDateTime", "UpdatedDateTime" },
                values: new object[] { new DateTime(2024, 5, 23, 10, 40, 49, 470, DateTimeKind.Utc).AddTicks(3884), new DateTime(2024, 5, 23, 10, 40, 49, 470, DateTimeKind.Utc).AddTicks(3887) });

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: new Guid("97cf6bd7-7290-449a-a61d-5ea2fdfcf8de"),
                columns: new[] { "CreatedDateTime", "UpdatedDateTime" },
                values: new object[] { new DateTime(2024, 5, 23, 10, 40, 49, 470, DateTimeKind.Utc).AddTicks(3898), new DateTime(2024, 5, 23, 10, 40, 49, 470, DateTimeKind.Utc).AddTicks(3899) });

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: new Guid("99ada3c1-eea5-4431-a529-b3114de224da"),
                columns: new[] { "CreatedDateTime", "UpdatedDateTime" },
                values: new object[] { new DateTime(2024, 5, 23, 10, 40, 49, 470, DateTimeKind.Utc).AddTicks(3891), new DateTime(2024, 5, 23, 10, 40, 49, 470, DateTimeKind.Utc).AddTicks(3891) });

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: new Guid("adf36edc-3e08-4a36-8e20-0d79747f0962"),
                columns: new[] { "CreatedDateTime", "UpdatedDateTime" },
                values: new object[] { new DateTime(2024, 5, 23, 10, 40, 49, 470, DateTimeKind.Utc).AddTicks(3893), new DateTime(2024, 5, 23, 10, 40, 49, 470, DateTimeKind.Utc).AddTicks(3893) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("9243d741-a350-4067-bb29-395e9becf57e"),
                columns: new[] { "CreatedDateTime", "Sku" },
                values: new object[] { new DateTime(2024, 5, 23, 10, 40, 49, 471, DateTimeKind.Utc).AddTicks(9062), "9243d741-a350-4067-bb29-395e9becf57e" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("e21f3a87-20d5-420e-ba33-9108df996747"),
                columns: new[] { "CreatedDateTime", "Sku" },
                values: new object[] { new DateTime(2024, 5, 23, 10, 40, 49, 471, DateTimeKind.Utc).AddTicks(9087), "e21f3a87-20d5-420e-ba33-9108df996747" });

            migrationBuilder.CreateIndex(
                name: "IX_Products_Sku",
                table: "Products",
                column: "Sku",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_Orders_OrderId",
                table: "OrderItems",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id");
        }
    }
}
