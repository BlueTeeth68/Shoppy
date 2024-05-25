using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shoppy.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Update_Rating_Relationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductRatings_AspNetUsers_UserId",
                table: "ProductRatings");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductRatings_Products_ProductId",
                table: "ProductRatings");

            migrationBuilder.DropIndex(
                name: "IX_ProductRatings_ProductId",
                table: "ProductRatings");

            migrationBuilder.DropIndex(
                name: "IX_ProductRatings_UserId",
                table: "ProductRatings");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "ProductRatings");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "ProductRatings",
                newName: "OrderItemId");

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
                column: "CreatedDateTime",
                value: new DateTime(2024, 5, 23, 10, 40, 49, 471, DateTimeKind.Utc).AddTicks(9062));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("e21f3a87-20d5-420e-ba33-9108df996747"),
                column: "CreatedDateTime",
                value: new DateTime(2024, 5, 23, 10, 40, 49, 471, DateTimeKind.Utc).AddTicks(9087));

            migrationBuilder.CreateIndex(
                name: "IX_ProductRatings_OrderItemId",
                table: "ProductRatings",
                column: "OrderItemId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductRatings_OrderItems_OrderItemId",
                table: "ProductRatings",
                column: "OrderItemId",
                principalTable: "OrderItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductRatings_OrderItems_OrderItemId",
                table: "ProductRatings");

            migrationBuilder.DropIndex(
                name: "IX_ProductRatings_OrderItemId",
                table: "ProductRatings");

            migrationBuilder.RenameColumn(
                name: "OrderItemId",
                table: "ProductRatings",
                newName: "UserId");

            migrationBuilder.AddColumn<Guid>(
                name: "ProductId",
                table: "ProductRatings",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("021657c8-d4d0-4167-a1a6-b7bb840f33bf"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash", "SecurityStamp", "UpdatedDateTime" },
                values: new object[] { "5c074718-3592-4297-af6e-829e60893517", new DateTime(2024, 5, 22, 16, 51, 26, 827, DateTimeKind.Utc).AddTicks(4347), "AQAAAAIAAYagAAAAEM1dbn+IAtRD2/E7tBGPk3IhXqJIZ963c+f9/Im6ga9EaKn7T7IErJSz8YpsXwlaug==", "94847428-1155-4bf7-8a92-ff18fc7b68b6", new DateTime(2024, 5, 22, 16, 51, 26, 827, DateTimeKind.Utc).AddTicks(4352) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("0cd66cfc-5d48-4f5e-b22d-5fa49234d192"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash", "SecurityStamp", "UpdatedDateTime" },
                values: new object[] { "27cc40f7-7cd8-40fb-a006-a6086e3f1670", new DateTime(2024, 5, 22, 16, 51, 28, 376, DateTimeKind.Utc).AddTicks(6981), "AQAAAAIAAYagAAAAEE7sTG2oWbdWQvKh63GBetLWY4qsfxbR21UrFLxVBt5mWX0eXHwVrZdbw1axTjR7UQ==", "e78564d9-3ec0-405a-a357-dab123d42088", new DateTime(2024, 5, 22, 16, 51, 28, 376, DateTimeKind.Utc).AddTicks(6983) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("1d2b5cf5-0ad7-4c3a-b4b9-5fa49234d202"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash", "SecurityStamp", "UpdatedDateTime" },
                values: new object[] { "9bb886d3-d6dd-4ea0-93ea-457ca5a31591", new DateTime(2024, 5, 22, 16, 51, 29, 281, DateTimeKind.Utc).AddTicks(7844), "AQAAAAIAAYagAAAAEM59qfyCN2Xoi8Fo0JLJ//6U2SEoZvSj9AW+1EAOHzA+L/Ba+okHU3Qwi6HNSt1ZWg==", "b5312fa2-8b16-424f-9ec3-2973670d248b", new DateTime(2024, 5, 22, 16, 51, 29, 281, DateTimeKind.Utc).AddTicks(7847) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("296dbab2-62f2-4eb6-ae53-e4c7fffdaf34"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash", "SecurityStamp", "UpdatedDateTime" },
                values: new object[] { "41bb60f7-4177-4016-98fb-82fa6674ab48", new DateTime(2024, 5, 22, 16, 51, 30, 994, DateTimeKind.Utc).AddTicks(4422), "AQAAAAIAAYagAAAAENesElTxb+a2fmfSMSsP++Sq1EnD5bctuQG+kjxNGYXHjkHlyCxotSCgS79Wmo5Ikw==", "9baefe48-b617-47a8-a3fc-57bc7f05adfa", new DateTime(2024, 5, 22, 16, 51, 30, 994, DateTimeKind.Utc).AddTicks(4426) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("2b844c01-c89e-4d24-a5d8-5fa49234d198"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash", "SecurityStamp", "UpdatedDateTime" },
                values: new object[] { "6e110817-3ae9-433b-a0f2-aed9551d665f", new DateTime(2024, 5, 22, 16, 51, 28, 924, DateTimeKind.Utc).AddTicks(5732), "AQAAAAIAAYagAAAAEPWOocekI2UpUpzxlfzaoQK9no36aq4yHqc4wBwBASckmkk5XmrghJEJhSUATNapFA==", "ee53f431-4811-4d31-a1d8-e45ac3a5dd9d", new DateTime(2024, 5, 22, 16, 51, 28, 924, DateTimeKind.Utc).AddTicks(5735) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("2c44d375-c725-4279-b2d3-87ea4218f385"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash", "SecurityStamp", "UpdatedDateTime" },
                values: new object[] { "7e326090-8383-4d48-8f36-c5ac596405c8", new DateTime(2024, 5, 22, 16, 51, 29, 646, DateTimeKind.Utc).AddTicks(1664), "AQAAAAIAAYagAAAAELvrw//jjrkD77NkjTeqspZmz9Cb7WXqiHZeGviA2Jyo6ZF2WFS1WBJNxbILmkoevA==", "f9e8af71-5c2b-46a8-b955-1dac8b2187b4", new DateTime(2024, 5, 22, 16, 51, 29, 646, DateTimeKind.Utc).AddTicks(1666) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("2c96fabb-f759-43ef-9a31-328c25d2eff5"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash", "SecurityStamp", "UpdatedDateTime" },
                values: new object[] { "a6321c5e-4532-4f6d-9f39-5711db73ccd7", new DateTime(2024, 5, 22, 16, 51, 26, 940, DateTimeKind.Utc).AddTicks(8592), "AQAAAAIAAYagAAAAEOzNmGMh3W+OD0UaMHkJ83Th1/2driuTqQusPEnG5HfEZacFKvdcjFltGiQ4olvZJg==", "675f53ef-73ff-4af8-a4fe-beffa3636e68", new DateTime(2024, 5, 22, 16, 51, 26, 940, DateTimeKind.Utc).AddTicks(8597) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("2d3d5b2d-b5a3-4b89-84b3-5fa49234d186"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash", "SecurityStamp", "UpdatedDateTime" },
                values: new object[] { "4a2c0277-0d21-4060-a0ce-76aa82c46269", new DateTime(2024, 5, 22, 16, 51, 27, 782, DateTimeKind.Utc).AddTicks(9576), "AQAAAAIAAYagAAAAEJEV3ep2oMKtr+SdXhddkW8y1pK06jHJz2QRN/6p3kXb9UR+AvXbaIzjdjaAKR4hFw==", "b90c980f-fd8f-444b-9e12-ebe53dd919c3", new DateTime(2024, 5, 22, 16, 51, 27, 782, DateTimeKind.Utc).AddTicks(9580) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("30a4345d-df2e-46ab-8c0e-d38a7933b591"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash", "SecurityStamp", "UpdatedDateTime" },
                values: new object[] { "fec58fc2-82bb-4d62-9abd-8610a7344484", new DateTime(2024, 5, 22, 16, 51, 27, 52, DateTimeKind.Utc).AddTicks(1651), "AQAAAAIAAYagAAAAENLfr5fBf8HGMuPTF4lXZ0sWJMAzLnoL3mVdrdLWlaN2EnScU5wj5eC0SfZZDjS6ug==", "e11b6b45-6ecd-4c7c-a9ea-a7ce0a693cdc", new DateTime(2024, 5, 22, 16, 51, 27, 52, DateTimeKind.Utc).AddTicks(1655) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("31e7a1a6-9a5d-4b4e-84eb-5fa49234d190"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash", "SecurityStamp", "UpdatedDateTime" },
                values: new object[] { "e3d1b8b8-f541-4ac7-affe-51aaa8b1a041", new DateTime(2024, 5, 22, 16, 51, 28, 172, DateTimeKind.Utc).AddTicks(2285), "AQAAAAIAAYagAAAAEDSw4V4CYwUj1iCYkvtYEL1CtST/oEgsODaF+0tVoCci10fcXxJamSUXs1JT8Akxyw==", "1469e525-02a8-4fb1-9728-dc5d1be69703", new DateTime(2024, 5, 22, 16, 51, 28, 172, DateTimeKind.Utc).AddTicks(2288) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("35d6cf06-f0ef-47a6-a4bd-5fa49234d196"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash", "SecurityStamp", "UpdatedDateTime" },
                values: new object[] { "3ac36f13-09fb-47cb-9a80-844179434f8f", new DateTime(2024, 5, 22, 16, 51, 28, 745, DateTimeKind.Utc).AddTicks(6190), "AQAAAAIAAYagAAAAEBZXu+p/TwdNyauv9F+hGoBR/aWk3tYjGugR6wXJCnVWEDNapHZZ/UdNNHQt4qrnIA==", "61101f82-bdd3-48fe-9112-d22df407184b", new DateTime(2024, 5, 22, 16, 51, 28, 745, DateTimeKind.Utc).AddTicks(6193) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("3d77db7b-3b3e-4a38-a1d1-5fa49234d200"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash", "SecurityStamp", "UpdatedDateTime" },
                values: new object[] { "f4ad8481-3b76-4889-af66-390b96899c10", new DateTime(2024, 5, 22, 16, 51, 29, 100, DateTimeKind.Utc).AddTicks(2420), "AQAAAAIAAYagAAAAENMnttCj8Rid3eCQex02IV5RB8XxWxOaoxyUhyW7qPdCyuWa2/+hPYBCoweunen1/Q==", "c0dab74f-ac38-45b9-a770-8d496647213f", new DateTime(2024, 5, 22, 16, 51, 29, 100, DateTimeKind.Utc).AddTicks(2422) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("4a8b3d09-78f2-43ad-bce6-5fa49234d189"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash", "SecurityStamp", "UpdatedDateTime" },
                values: new object[] { "053662ff-39fa-4143-bd88-d34f527271a9", new DateTime(2024, 5, 22, 16, 51, 28, 83, DateTimeKind.Utc).AddTicks(8693), "AQAAAAIAAYagAAAAEGRGTBAIYyS3dP89LFlEGDZ6KltY32bOw1dlC3VZwJU4WDI6KoZGdz1AHQbH/KCpZA==", "df80f3f9-0f27-4f13-9919-b0a27b75a28c", new DateTime(2024, 5, 22, 16, 51, 28, 83, DateTimeKind.Utc).AddTicks(8696) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("50b95f41-7afa-4cda-aa7a-5fa49234d183"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash", "SecurityStamp", "UpdatedDateTime" },
                values: new object[] { "663189e8-031b-4756-8a90-4f4499770bf3", new DateTime(2024, 5, 22, 16, 51, 27, 495, DateTimeKind.Utc).AddTicks(7371), "AQAAAAIAAYagAAAAELsBPjNQoFqdxWHe4Y53UseNn77MDdYc0T1nrOuaBuJ0gm2Ot8/6DGrxgK49pgcvNA==", "35b5d9ee-7401-49cb-afa6-d05e2d66ca5c", new DateTime(2024, 5, 22, 16, 51, 27, 495, DateTimeKind.Utc).AddTicks(7375) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("50b95f41-7afa-4cda-aa7a-5fa49234d184"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash", "SecurityStamp", "UpdatedDateTime" },
                values: new object[] { "7cece8b7-1399-4428-9cf7-74d24513368c", new DateTime(2024, 5, 22, 16, 51, 27, 590, DateTimeKind.Utc).AddTicks(2642), "AQAAAAIAAYagAAAAEERoDLFljJGrSc1daAmPNKcUvjDBfuvsOD6fhucdFOKqKe3hn1qWkMoYfN8D5N938A==", "b65a4e25-37e5-4108-ad6b-1a0e62b4bbe7", new DateTime(2024, 5, 22, 16, 51, 27, 590, DateTimeKind.Utc).AddTicks(2647) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("56b2a1c9-a651-4fee-8f8e-5fa49234d199"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash", "SecurityStamp", "UpdatedDateTime" },
                values: new object[] { "af4af235-de16-48a7-ae5c-28f6f2000aab", new DateTime(2024, 5, 22, 16, 51, 29, 12, DateTimeKind.Utc).AddTicks(2469), "AQAAAAIAAYagAAAAEOn+syterUkF1DaiMIRGBC46tHXLVit1iFT3wWsmBEZvvwhkikCTT7Xku0h3WWxVag==", "fd85acc6-72aa-4ba4-8e8a-cc01a0896baf", new DateTime(2024, 5, 22, 16, 51, 29, 12, DateTimeKind.Utc).AddTicks(2472) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("594f8fe1-1cf1-4f5a-a8ae-6b9509fbf283"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash", "SecurityStamp", "UpdatedDateTime" },
                values: new object[] { "c35ea7ad-66f2-4b37-b343-702952189a63", new DateTime(2024, 5, 22, 16, 51, 27, 158, DateTimeKind.Utc).AddTicks(5389), "AQAAAAIAAYagAAAAEGu3uvKDynvF2XXhBAdEgL7m4ypcqqse+iUc8ABoBCteSrfP2CuyWFI/HX9F801fcA==", "b107372a-5d0f-4436-a6e5-b206e9b378cf", new DateTime(2024, 5, 22, 16, 51, 27, 158, DateTimeKind.Utc).AddTicks(5391) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("5aca3775-d37e-473c-8f3a-3926ed32e360"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash", "SecurityStamp", "UpdatedDateTime" },
                values: new object[] { "2eec982b-bf32-4b70-a662-a79742104925", new DateTime(2024, 5, 22, 16, 51, 29, 464, DateTimeKind.Utc).AddTicks(8034), "AQAAAAIAAYagAAAAEHBXxoAalG9eIOeoAVQYmoWrh59Qo3HCTDzORdTzjwdKZDHdUQMOexx8GT1jN5pjOw==", "6eda0ec8-07a6-498c-bc0f-3727490c2e81", new DateTime(2024, 5, 22, 16, 51, 29, 464, DateTimeKind.Utc).AddTicks(8036) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("5c6a5f5e-3a11-4d42-bff8-5fa49234d188"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash", "SecurityStamp", "UpdatedDateTime" },
                values: new object[] { "78e045a6-157f-4b49-bb23-bf06e558bc5e", new DateTime(2024, 5, 22, 16, 51, 27, 989, DateTimeKind.Utc).AddTicks(6812), "AQAAAAIAAYagAAAAEA6YqY8acXhrt4NHepKLjEtUKClyWNwy+VKsr2IEtdVORxoz45c9Gy9QoKM5X9Y41w==", "486788e6-102f-405f-950f-1fa96425976d", new DateTime(2024, 5, 22, 16, 51, 27, 989, DateTimeKind.Utc).AddTicks(6815) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("60a119e1-610c-42fc-85c8-95a7e4d2119b"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash", "SecurityStamp", "UpdatedDateTime" },
                values: new object[] { "056ef2f4-a5d9-44e5-ab5d-931135ae022f", new DateTime(2024, 5, 22, 16, 51, 30, 766, DateTimeKind.Utc).AddTicks(4932), "AQAAAAIAAYagAAAAEP5CzzgEN5rp6Fa8XJnfUWhH+RD2e6nq1psgowKFBg8YPXO+EzT4GGO23lkg/puqOg==", "355be309-2b0e-4da2-8fcc-8f05d682590d", new DateTime(2024, 5, 22, 16, 51, 30, 766, DateTimeKind.Utc).AddTicks(4936) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("60b9f0cc-b3b4-4ac3-a9ce-5fa49234d193"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash", "SecurityStamp", "UpdatedDateTime" },
                values: new object[] { "958ed02c-ea4b-4a05-a727-a60d4b14c915", new DateTime(2024, 5, 22, 16, 51, 28, 471, DateTimeKind.Utc).AddTicks(7414), "AQAAAAIAAYagAAAAEMpiwOmijWjgDiIDCpxk4YGZjBZuKJ5IuGRS56eJmF1VU10TEvvZTjVA3E2E88z2+A==", "3e7f1288-6222-4b9a-b94b-d92d7699c2ee", new DateTime(2024, 5, 22, 16, 51, 28, 471, DateTimeKind.Utc).AddTicks(7417) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("6c16a235-f928-4b8d-978f-5fa49234d194"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash", "SecurityStamp", "UpdatedDateTime" },
                values: new object[] { "bddb6c7c-eef7-430a-8f3b-975d877be77b", new DateTime(2024, 5, 22, 16, 51, 28, 563, DateTimeKind.Utc).AddTicks(1109), "AQAAAAIAAYagAAAAELbUyzEttAce02jUIwkJ2+BsnKWe6UuKe17iaEZnErGTD2iQy1cGrWMB014MbW9L+A==", "9d54bb9e-aace-473c-ad56-05627aaa36ed", new DateTime(2024, 5, 22, 16, 51, 28, 563, DateTimeKind.Utc).AddTicks(1112) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("6e2f7a2d-1994-419b-8c6d-b3d297cd7b06"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash", "SecurityStamp", "UpdatedDateTime" },
                values: new object[] { "d7645271-bc2d-4951-86de-0609941712a8", new DateTime(2024, 5, 22, 16, 51, 30, 450, DateTimeKind.Utc).AddTicks(7448), "AQAAAAIAAYagAAAAECRSgPbSsngpVk7aWKtf9WOtWLB7kn0GRo77oSMZE/uoyZUtJDh1tmuLE1G4It6uEg==", "ae8e2741-cc27-4657-b17e-1a577cb12660", new DateTime(2024, 5, 22, 16, 51, 30, 450, DateTimeKind.Utc).AddTicks(7451) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("7db124bd-9953-4eb0-98f2-50b1be635544"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash", "SecurityStamp", "UpdatedDateTime" },
                values: new object[] { "88791b5b-1a24-4d93-8434-ec3885bfce8f", new DateTime(2024, 5, 22, 16, 51, 27, 386, DateTimeKind.Utc).AddTicks(8034), "AQAAAAIAAYagAAAAENB3RV0H3Cxl6tarVg+qS7cyGUYInBJVFwh7HCd4IHfHT2Ad1xfHXsm/KZvgflT1Dw==", "c5b2c5ec-574d-433a-8ab8-8ae3c0748368", new DateTime(2024, 5, 22, 16, 51, 27, 386, DateTimeKind.Utc).AddTicks(8039) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("853988db-ad55-4a28-9782-90438c64b62d"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash", "SecurityStamp", "UpdatedDateTime" },
                values: new object[] { "a18ee35e-8d1a-47ea-b72b-e09c161c5718", new DateTime(2024, 5, 22, 16, 51, 30, 618, DateTimeKind.Utc).AddTicks(6353), "AQAAAAIAAYagAAAAEExqGBOB3Z3GzFnvp0prU8wEaR8TYS6QO/DFCalTiB9aHtf6I8AMj8HOc+Zkqd8Z9A==", "e3f8e6df-4159-4fc0-bc18-101dd5c89ac8", new DateTime(2024, 5, 22, 16, 51, 30, 618, DateTimeKind.Utc).AddTicks(6356) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("85d8a27f-9d32-4269-b5d0-844589d498d0"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash", "SecurityStamp", "UpdatedDateTime" },
                values: new object[] { "9bd4c0eb-c6ed-49dc-954c-0ac5758999ab", new DateTime(2024, 5, 22, 16, 51, 26, 734, DateTimeKind.Utc).AddTicks(5621), "AQAAAAIAAYagAAAAEF6cdEszo6SiTzU72E3YT9J1eIlMeZ/rUoO4Zfm8poE1YqrNwcozLvUJkMi5lVwYpg==", "dee907ac-597e-47ae-8b1b-f0e50622bf26", new DateTime(2024, 5, 22, 16, 51, 26, 734, DateTimeKind.Utc).AddTicks(5624) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("870559eb-5fde-4764-ade7-392b0cf6b5ce"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash", "SecurityStamp", "UpdatedDateTime" },
                values: new object[] { "786bb1e6-373b-4fb1-ab42-30437d48dbea", new DateTime(2024, 5, 22, 16, 51, 30, 873, DateTimeKind.Utc).AddTicks(2205), "AQAAAAIAAYagAAAAEPzU7B2q2LfjePFX1BHuzMR8vTnmGPXD5BKnZ1PAiIq/OTSuBvyq2AP8uIwYij+YlA==", "4291f89e-5ab9-4fc9-b7c5-df8302e1396d", new DateTime(2024, 5, 22, 16, 51, 30, 873, DateTimeKind.Utc).AddTicks(2210) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("87787f6e-729b-436b-bcc9-c7b48c45ba05"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash", "SecurityStamp", "UpdatedDateTime" },
                values: new object[] { "9ecc9489-0922-4521-963a-20b91b4eb735", new DateTime(2024, 5, 22, 16, 51, 30, 4, DateTimeKind.Utc).AddTicks(2644), "AQAAAAIAAYagAAAAEKBPF3M/akTVwup+ZeLkrpoA/0Agxjf+Vm/YgRzUf90E+N6oCbx+i1GLoXE3OgMhYQ==", "491d8ce3-ae90-4feb-ae40-6c9f32c43c1e", new DateTime(2024, 5, 22, 16, 51, 30, 4, DateTimeKind.Utc).AddTicks(2649) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("8c3b46b9-1321-4d97-a193-5fa49234d185"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash", "SecurityStamp", "UpdatedDateTime" },
                values: new object[] { "85b24815-b69a-4c98-ba08-963f61822600", new DateTime(2024, 5, 22, 16, 51, 27, 688, DateTimeKind.Utc).AddTicks(5580), "AQAAAAIAAYagAAAAEEgbAS4Ra0TP3IkLRIvKI627vmCFoBXgEp6HvQtqxHNiBTT1jXSoJbRVGcaFgWziGQ==", "c14827ce-8f57-4611-9143-183e56195791", new DateTime(2024, 5, 22, 16, 51, 27, 688, DateTimeKind.Utc).AddTicks(5582) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("906f192a-96d3-433a-a7ea-288662b5f62d"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash", "SecurityStamp", "UpdatedDateTime" },
                values: new object[] { "6c17f339-206d-4690-8a8c-fda6ec51c84e", new DateTime(2024, 5, 22, 16, 51, 29, 738, DateTimeKind.Utc).AddTicks(5975), "AQAAAAIAAYagAAAAEC6OxnrpQRVokY0S9MG9rDUJAPImwoQ8alXcBk+/+ZC3shiOB4jGN1vsd/xeF8WOtQ==", "0fb0e103-45e1-49ff-873c-fda7e2d214d4", new DateTime(2024, 5, 22, 16, 51, 29, 738, DateTimeKind.Utc).AddTicks(5978) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("91d0da1b-e147-4829-aa4e-7073c1a10d2c"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash", "SecurityStamp", "UpdatedDateTime" },
                values: new object[] { "65799838-7bd9-45c5-abe8-09d118a9fed6", new DateTime(2024, 5, 22, 16, 51, 30, 185, DateTimeKind.Utc).AddTicks(1201), "AQAAAAIAAYagAAAAEFNrMiFQIWrNKXEJy0tDtQwczJkti500S0RJ1RxA+x8QNyaJ4gGTO+YZ/85XlNgXPA==", "020e15ca-e964-4047-890f-f993c35f075e", new DateTime(2024, 5, 22, 16, 51, 30, 185, DateTimeKind.Utc).AddTicks(1205) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("9a4a34a4-4b12-4c8e-a52b-5fa49234d195"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash", "SecurityStamp", "UpdatedDateTime" },
                values: new object[] { "7d5e7bb3-71db-4825-9e80-d075ae17141e", new DateTime(2024, 5, 22, 16, 51, 28, 656, DateTimeKind.Utc).AddTicks(2359), "AQAAAAIAAYagAAAAEGyjNwI2a09UbSLALwIjaiQQkPumvYW1SMulqJOj7l7+FVU2hwgut8y/tN6MBO8t+g==", "532efad4-8247-45c2-a51d-781ebd38ecd8", new DateTime(2024, 5, 22, 16, 51, 28, 656, DateTimeKind.Utc).AddTicks(2361) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("9b8c6d7b-754f-420c-b574-4a63326bfc6a"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash", "SecurityStamp", "UpdatedDateTime" },
                values: new object[] { "42222215-4651-4b56-a853-fa63a66cb951", new DateTime(2024, 5, 22, 16, 51, 30, 361, DateTimeKind.Utc).AddTicks(1367), "AQAAAAIAAYagAAAAECrrUO4BLJ//chQuCgaIbXYLT5+WdlTKXXZlHfuIZrNLKdonuhDovfsZ4W5Ff7cFHw==", "20053537-97e4-4aca-af97-f29a9a6b7e28", new DateTime(2024, 5, 22, 16, 51, 30, 361, DateTimeKind.Utc).AddTicks(1370) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("9d36fef6-9c75-4f96-a951-5fa49234d203"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash", "SecurityStamp", "UpdatedDateTime" },
                values: new object[] { "9b262e94-7c35-4b77-a415-fedb4e526d1a", new DateTime(2024, 5, 22, 16, 51, 29, 372, DateTimeKind.Utc).AddTicks(2855), "AQAAAAIAAYagAAAAEJEEugc4GOtvdjxSKjSqC5Q+hMmF/Jb5D3W1GilV8umWcMYIBdd4JU1H3c/AJHrejg==", "47db8765-02aa-483e-b591-ebf9058a71b9", new DateTime(2024, 5, 22, 16, 51, 29, 372, DateTimeKind.Utc).AddTicks(2857) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("b2687ce8-aad5-4d5f-849b-dcd2b402aff0"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash", "SecurityStamp", "UpdatedDateTime" },
                values: new object[] { "24131ba6-368a-473e-aa50-8dda75b757c6", new DateTime(2024, 5, 22, 16, 51, 31, 107, DateTimeKind.Utc).AddTicks(2914), "AQAAAAIAAYagAAAAEMdAWZH63k1Wra962hJsXjVeUgpsQWKrbnLjw8T4Li5AQb7Jp8BHFkVewaJpcTJV/Q==", "6b1387be-f48b-4ad0-99d7-5e6c957dec04", new DateTime(2024, 5, 22, 16, 51, 31, 107, DateTimeKind.Utc).AddTicks(2918) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("b6123f4e-3443-41ae-a1cb-5fa49234d187"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash", "SecurityStamp", "UpdatedDateTime" },
                values: new object[] { "77424e6a-ac36-4310-88c3-6063dfa2ea64", new DateTime(2024, 5, 22, 16, 51, 27, 874, DateTimeKind.Utc).AddTicks(8874), "AQAAAAIAAYagAAAAELH9SKIEqXV6TnQhvVID/NwuVuJmAjcycpkJACH8+TFXXi0CGBzwo2dVb4xIPwAeAQ==", "8e9048b5-2453-4c3b-94e0-ba8ef0fdd2e8", new DateTime(2024, 5, 22, 16, 51, 27, 874, DateTimeKind.Utc).AddTicks(8877) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("c0a7e4f4-d8d0-4c80-8e1c-5fa49234d201"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash", "SecurityStamp", "UpdatedDateTime" },
                values: new object[] { "9b9159c1-928d-4c62-ac93-56f50c84b0ae", new DateTime(2024, 5, 22, 16, 51, 29, 194, DateTimeKind.Utc).AddTicks(1572), "AQAAAAIAAYagAAAAEE3rRxwIkpbDTcHL95WYvHOR+hAhHkVbVZFH18GlWw1X1QDPCVvr2nExaAeWpqn4Vw==", "2139b1ba-4407-4360-95b0-5e84ef9a1c97", new DateTime(2024, 5, 22, 16, 51, 29, 194, DateTimeKind.Utc).AddTicks(1577) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("c55cdfd0-d1dd-4841-ae27-f2d621686756"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash", "SecurityStamp", "UpdatedDateTime" },
                values: new object[] { "583dfc24-a714-42e1-bdf3-a2bcbb1eb258", new DateTime(2024, 5, 22, 16, 51, 29, 827, DateTimeKind.Utc).AddTicks(1363), "AQAAAAIAAYagAAAAEJbKe8IA0zYyzYCeKnJXsHzmtCfqMg2tDCv6UCk3twYRQ6VfIOr+ezz5LxvyuM5t9Q==", "561a9885-2029-4cb0-875d-5e9258b96ef3", new DateTime(2024, 5, 22, 16, 51, 29, 827, DateTimeKind.Utc).AddTicks(1367) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("d0e03a1a-21c2-4123-a75e-5fa49234d191"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash", "SecurityStamp", "UpdatedDateTime" },
                values: new object[] { "d92e63db-acc9-4c1e-adae-df6b36c91893", new DateTime(2024, 5, 22, 16, 51, 28, 268, DateTimeKind.Utc).AddTicks(8768), "AQAAAAIAAYagAAAAEIP4W63902W7ScPTb4rUMjMqvK/Z4kiAHJEBF/8yuU0O8xjipl6VuZcJ704lHTxATg==", "b8cce32a-55d1-4dd7-ba07-e275560f7e04", new DateTime(2024, 5, 22, 16, 51, 28, 268, DateTimeKind.Utc).AddTicks(8771) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("d30fa796-5144-4467-a302-68dc64fd0d92"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash", "SecurityStamp", "UpdatedDateTime" },
                values: new object[] { "a8582bdf-16d1-4514-b0ef-3aa4db1d9a00", new DateTime(2024, 5, 22, 16, 51, 30, 91, DateTimeKind.Utc).AddTicks(8508), "AQAAAAIAAYagAAAAEAkV5feJWheATZ+RfRYGwnZw/EcQk4kYs9jJta0O1wrkWuMVd1ooRAL+CQnmvO+GwA==", "864187b2-258a-4525-9074-909f3b015fd0", new DateTime(2024, 5, 22, 16, 51, 30, 91, DateTimeKind.Utc).AddTicks(8513) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e92c6f32-859b-443b-bfb2-bd0674b5673a"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash", "SecurityStamp", "UpdatedDateTime" },
                values: new object[] { "d25d2bc5-2629-4acd-a6b8-ce3d5155ffcb", new DateTime(2024, 5, 22, 16, 51, 29, 552, DateTimeKind.Utc).AddTicks(2891), "AQAAAAIAAYagAAAAEAcbDw3RrxUdiWvKkxJ0JZ/WYeGvWVJ/wvGc36+vygcNC+Dy0uHlniLfpGNiIM2yFQ==", "f5c813e1-2e26-4f53-90b6-8759cacb7e9e", new DateTime(2024, 5, 22, 16, 51, 29, 552, DateTimeKind.Utc).AddTicks(2894) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("eee6e626-9a26-4f38-bbe3-433d20440ce9"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash", "SecurityStamp", "UpdatedDateTime" },
                values: new object[] { "80e317f6-6a88-4d4b-bbd3-9e5b5cce6fb8", new DateTime(2024, 5, 22, 16, 51, 27, 271, DateTimeKind.Utc).AddTicks(960), "AQAAAAIAAYagAAAAEALfquHOFgig0zeKnJobeQ1manvUVX+xpqEfkjzsF9LwSmDI++kCkcmn15Hzs17zvg==", "e38b1be5-0f33-4703-bf0e-57813cdce541", new DateTime(2024, 5, 22, 16, 51, 27, 271, DateTimeKind.Utc).AddTicks(963) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("eeed5a4d-e83d-4032-8c3c-5fa49234d197"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash", "SecurityStamp", "UpdatedDateTime" },
                values: new object[] { "8c6776d8-f404-4200-8968-228407606677", new DateTime(2024, 5, 22, 16, 51, 28, 837, DateTimeKind.Utc).AddTicks(3799), "AQAAAAIAAYagAAAAEMNsX+o0ynQ7y13G7NwW5y0xmwUH9oQ7WfCnE2RaHw62DH2IWIgs5/cpD2fmRHaH5Q==", "8891db71-018f-453b-b6b9-61d8312b6447", new DateTime(2024, 5, 22, 16, 51, 28, 837, DateTimeKind.Utc).AddTicks(3802) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("f483fb9f-477c-4a3a-9f73-3b028b06ed49"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash", "SecurityStamp", "UpdatedDateTime" },
                values: new object[] { "6a4b9d62-7658-4c4c-82e7-c641cf4b7331", new DateTime(2024, 5, 22, 16, 51, 29, 916, DateTimeKind.Utc).AddTicks(7977), "AQAAAAIAAYagAAAAEE8xbDg6t/G+gjq0Au9GktQfVSWnwOnnKQHh8ge3N92IaBeALVkumITgpJCNSj9YLQ==", "c0df584b-004f-4cd9-9592-51f089ec4494", new DateTime(2024, 5, 22, 16, 51, 29, 916, DateTimeKind.Utc).AddTicks(7981) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("fbd62259-a313-4d38-885e-1f6acdf9a30a"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash", "SecurityStamp", "UpdatedDateTime" },
                values: new object[] { "480f07d1-c268-48d4-b13d-439f3c786d83", new DateTime(2024, 5, 22, 16, 51, 30, 272, DateTimeKind.Utc).AddTicks(8663), "AQAAAAIAAYagAAAAEBlHGoY6A4XrAxa/8pr/DbHd1/29nWZJ6+25qznwCHcUTrypQRWAygsFdb2w8dYVWw==", "b37656e8-56d1-4b90-b72e-50880ba00e7d", new DateTime(2024, 5, 22, 16, 51, 30, 272, DateTimeKind.Utc).AddTicks(8667) });

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: new Guid("292c90a5-1a0a-45a4-8f3d-37f09b09b422"),
                columns: new[] { "CreatedDateTime", "UpdatedDateTime" },
                values: new object[] { new DateTime(2024, 5, 22, 16, 51, 31, 312, DateTimeKind.Utc).AddTicks(4551), new DateTime(2024, 5, 22, 16, 51, 31, 312, DateTimeKind.Utc).AddTicks(4551) });

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: new Guid("2baf4c50-c927-4b54-971e-3ff5f300e147"),
                columns: new[] { "CreatedDateTime", "UpdatedDateTime" },
                values: new object[] { new DateTime(2024, 5, 22, 16, 51, 31, 312, DateTimeKind.Utc).AddTicks(4534), new DateTime(2024, 5, 22, 16, 51, 31, 312, DateTimeKind.Utc).AddTicks(4538) });

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: new Guid("97cf6bd7-7290-449a-a61d-5ea2fdfcf8de"),
                columns: new[] { "CreatedDateTime", "UpdatedDateTime" },
                values: new object[] { new DateTime(2024, 5, 22, 16, 51, 31, 312, DateTimeKind.Utc).AddTicks(4554), new DateTime(2024, 5, 22, 16, 51, 31, 312, DateTimeKind.Utc).AddTicks(4554) });

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: new Guid("99ada3c1-eea5-4431-a529-b3114de224da"),
                columns: new[] { "CreatedDateTime", "UpdatedDateTime" },
                values: new object[] { new DateTime(2024, 5, 22, 16, 51, 31, 312, DateTimeKind.Utc).AddTicks(4544), new DateTime(2024, 5, 22, 16, 51, 31, 312, DateTimeKind.Utc).AddTicks(4545) });

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: new Guid("adf36edc-3e08-4a36-8e20-0d79747f0962"),
                columns: new[] { "CreatedDateTime", "UpdatedDateTime" },
                values: new object[] { new DateTime(2024, 5, 22, 16, 51, 31, 312, DateTimeKind.Utc).AddTicks(4548), new DateTime(2024, 5, 22, 16, 51, 31, 312, DateTimeKind.Utc).AddTicks(4548) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("9243d741-a350-4067-bb29-395e9becf57e"),
                column: "CreatedDateTime",
                value: new DateTime(2024, 5, 22, 16, 51, 31, 314, DateTimeKind.Utc).AddTicks(8017));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("e21f3a87-20d5-420e-ba33-9108df996747"),
                column: "CreatedDateTime",
                value: new DateTime(2024, 5, 22, 16, 51, 31, 314, DateTimeKind.Utc).AddTicks(8047));

            migrationBuilder.CreateIndex(
                name: "IX_ProductRatings_ProductId",
                table: "ProductRatings",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductRatings_UserId",
                table: "ProductRatings",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductRatings_AspNetUsers_UserId",
                table: "ProductRatings",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductRatings_Products_ProductId",
                table: "ProductRatings",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
