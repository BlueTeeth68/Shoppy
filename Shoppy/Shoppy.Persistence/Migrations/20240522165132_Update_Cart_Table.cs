using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shoppy.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Update_Cart_Table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartItems_Carts_CartId",
                table: "CartItems");

            migrationBuilder.AddColumn<bool>(
                name: "IsReviewed",
                table: "OrderItems",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDateTime",
                table: "Carts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "Carts",
                type: "rowversion",
                rowVersion: true,
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDateTime",
                table: "Carts",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "CartId",
                table: "CartItems",
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

            migrationBuilder.AddForeignKey(
                name: "FK_CartItems_Carts_CartId",
                table: "CartItems",
                column: "CartId",
                principalTable: "Carts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartItems_Carts_CartId",
                table: "CartItems");

            migrationBuilder.DropColumn(
                name: "IsReviewed",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "CreatedDateTime",
                table: "Carts");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "Carts");

            migrationBuilder.DropColumn(
                name: "UpdatedDateTime",
                table: "Carts");

            migrationBuilder.AlterColumn<Guid>(
                name: "CartId",
                table: "CartItems",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("021657c8-d4d0-4167-a1a6-b7bb840f33bf"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash", "SecurityStamp", "UpdatedDateTime" },
                values: new object[] { "29d8a2a2-7f33-439b-8c2d-4b844edff675", new DateTime(2024, 5, 16, 15, 48, 3, 231, DateTimeKind.Utc).AddTicks(5977), "AQAAAAIAAYagAAAAEJVaeVNRZaHYvaAm2C+yvtxLZpmcbp/X+RLx7cQgrv8x3rZSsV8IgPSxPGuJXMYJ9A==", "876afdf9-9307-4e88-8f7d-5d445ca1b50a", new DateTime(2024, 5, 16, 15, 48, 3, 231, DateTimeKind.Utc).AddTicks(5984) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("0cd66cfc-5d48-4f5e-b22d-5fa49234d192"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash", "SecurityStamp", "UpdatedDateTime" },
                values: new object[] { "c069b003-2dd3-46e8-82d0-5fae49738b3f", new DateTime(2024, 5, 16, 15, 48, 5, 7, DateTimeKind.Utc).AddTicks(933), "AQAAAAIAAYagAAAAED2KZQuxEz9X/SP0cdFjyXgqCrkpr9fJ/taUZBH1Q+TR5P3zQ+QUaj5jMDpSUXhL+g==", "5072180a-f2f9-4aa7-9856-50ce64000931", new DateTime(2024, 5, 16, 15, 48, 5, 7, DateTimeKind.Utc).AddTicks(936) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("1d2b5cf5-0ad7-4c3a-b4b9-5fa49234d202"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash", "SecurityStamp", "UpdatedDateTime" },
                values: new object[] { "29c26204-71c3-4e2c-b476-abdc9cd80bb0", new DateTime(2024, 5, 16, 15, 48, 6, 88, DateTimeKind.Utc).AddTicks(5693), "AQAAAAIAAYagAAAAEIm1Vf9/1u5F6VxqhF+GyTVT3Dx7UaGt89pAjzcchspfsz6Nnkjys05BKAPZJ8WqHw==", "68145281-74c4-4d14-978d-793d763482be", new DateTime(2024, 5, 16, 15, 48, 6, 88, DateTimeKind.Utc).AddTicks(5695) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("296dbab2-62f2-4eb6-ae53-e4c7fffdaf34"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash", "SecurityStamp", "UpdatedDateTime" },
                values: new object[] { "93f69e3a-728a-436e-98bc-237ae8ae4355", new DateTime(2024, 5, 16, 15, 48, 7, 758, DateTimeKind.Utc).AddTicks(939), "AQAAAAIAAYagAAAAEF9CxTN0Y2OrWWyHdOfX1D8hkHGyDJhGc/j/4qw594mG2DUjG9OF4znbDSvVXrxR7A==", "26972e0f-5ea9-49a4-84da-1bc6c9db463a", new DateTime(2024, 5, 16, 15, 48, 7, 758, DateTimeKind.Utc).AddTicks(941) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("2b844c01-c89e-4d24-a5d8-5fa49234d198"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash", "SecurityStamp", "UpdatedDateTime" },
                values: new object[] { "a1e1aa09-3321-41eb-a202-348b6ed52e12", new DateTime(2024, 5, 16, 15, 48, 5, 719, DateTimeKind.Utc).AddTicks(6946), "AQAAAAIAAYagAAAAEAUAQvzZ1eOIzmtdWiTbP3mdYtmyJjP7AxafDDIEaHq5Rkbypfjw52o5NsYvtgiWhQ==", "f9038fa9-f589-4c92-a34f-e929ed19f0d0", new DateTime(2024, 5, 16, 15, 48, 5, 719, DateTimeKind.Utc).AddTicks(6950) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("2c44d375-c725-4279-b2d3-87ea4218f385"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash", "SecurityStamp", "UpdatedDateTime" },
                values: new object[] { "e3735e7d-7d95-4157-a751-5a4a0c1518d9", new DateTime(2024, 5, 16, 15, 48, 6, 451, DateTimeKind.Utc).AddTicks(2668), "AQAAAAIAAYagAAAAEN9lRwW94a15dDlX3+RkZMVjlXfwLENhNFFZtRcBAHoOW4DGElUiop9bvX3dXVDSJQ==", "aa9728da-8028-458b-ad69-f8a6dbc35f52", new DateTime(2024, 5, 16, 15, 48, 6, 451, DateTimeKind.Utc).AddTicks(2671) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("2c96fabb-f759-43ef-9a31-328c25d2eff5"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash", "SecurityStamp", "UpdatedDateTime" },
                values: new object[] { "1d90a092-eb48-4d0c-aeda-0b61b86c20bf", new DateTime(2024, 5, 16, 15, 48, 3, 414, DateTimeKind.Utc).AddTicks(3717), "AQAAAAIAAYagAAAAEGzyZujwiCXHu2T9P2nhwbJK5LsvgFd95QbftgaCw19IkTrGz42j5g3rW+wXI2s5ZA==", "956984a5-329a-47d0-927e-7fd7b12cdb5a", new DateTime(2024, 5, 16, 15, 48, 3, 414, DateTimeKind.Utc).AddTicks(3719) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("2d3d5b2d-b5a3-4b89-84b3-5fa49234d186"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash", "SecurityStamp", "UpdatedDateTime" },
                values: new object[] { "8af5119e-33d1-4287-990b-d9982e944587", new DateTime(2024, 5, 16, 15, 48, 4, 328, DateTimeKind.Utc).AddTicks(2771), "AQAAAAIAAYagAAAAEHa+5aweWPlcPyaczPbjSDxHD0/kspVPmtt2GQ1UVXhCyTXwxToZ1i+1NnM8XPVTEA==", "9fadee71-76cd-4015-b116-6d0fdc31c694", new DateTime(2024, 5, 16, 15, 48, 4, 328, DateTimeKind.Utc).AddTicks(2773) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("30a4345d-df2e-46ab-8c0e-d38a7933b591"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash", "SecurityStamp", "UpdatedDateTime" },
                values: new object[] { "4dbcf81b-b826-42be-88f9-92850cf07de1", new DateTime(2024, 5, 16, 15, 48, 3, 554, DateTimeKind.Utc).AddTicks(6085), "AQAAAAIAAYagAAAAEHacJbV5lgzZy1t0289Nuy5/6YbwyQunvsM6aw2KzgUcUhTbynpVA4QEjN5LrK6gjQ==", "7aa08661-312f-4327-8b3c-b264dc94ba61", new DateTime(2024, 5, 16, 15, 48, 3, 554, DateTimeKind.Utc).AddTicks(6087) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("31e7a1a6-9a5d-4b4e-84eb-5fa49234d190"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash", "SecurityStamp", "UpdatedDateTime" },
                values: new object[] { "46e22cfa-994a-4e13-8442-06e75ff25130", new DateTime(2024, 5, 16, 15, 48, 4, 724, DateTimeKind.Utc).AddTicks(2243), "AQAAAAIAAYagAAAAEMZSfc31bVfkmNHuUShZBf7OlBKIV6ZxATom9rkeSXDU8wORJRzy16R73sh8Mjx1nw==", "717530dd-bf66-4726-9205-0002fddc1e4c", new DateTime(2024, 5, 16, 15, 48, 4, 724, DateTimeKind.Utc).AddTicks(2245) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("35d6cf06-f0ef-47a6-a4bd-5fa49234d196"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash", "SecurityStamp", "UpdatedDateTime" },
                values: new object[] { "60799f45-08f2-4347-a64e-830492b934b4", new DateTime(2024, 5, 16, 15, 48, 5, 480, DateTimeKind.Utc).AddTicks(164), "AQAAAAIAAYagAAAAEBLu4m0mrkjmWDMgDufwLMZ3DKArtswZ5aLf3NUPJd3eyy5A4ygDQDkY/G/ySGmUNw==", "c9dbb0b0-ef02-47cd-a4bf-2623b4196995", new DateTime(2024, 5, 16, 15, 48, 5, 480, DateTimeKind.Utc).AddTicks(166) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("3d77db7b-3b3e-4a38-a1d1-5fa49234d200"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash", "SecurityStamp", "UpdatedDateTime" },
                values: new object[] { "6583c2dc-849c-456d-9ebc-3c793e060a87", new DateTime(2024, 5, 16, 15, 48, 5, 902, DateTimeKind.Utc).AddTicks(8035), "AQAAAAIAAYagAAAAEHiPTHYNkqUYfuWcAYbK4oFoZHdMYQ0c3+lQ9nCDLDJEkuY0aAn7hOy6jfxo6zEqBA==", "7acd2408-b750-476e-83c2-145b4c1f3ed1", new DateTime(2024, 5, 16, 15, 48, 5, 902, DateTimeKind.Utc).AddTicks(8037) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("4a8b3d09-78f2-43ad-bce6-5fa49234d189"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash", "SecurityStamp", "UpdatedDateTime" },
                values: new object[] { "02ba10df-82b6-4a61-9175-0251ade4e8af", new DateTime(2024, 5, 16, 15, 48, 4, 634, DateTimeKind.Utc).AddTicks(2476), "AQAAAAIAAYagAAAAEM9Aj8IQfHBqyBdq1ReLSaczKmM4xC3pj3pXqUjl5SEHrbR40oNBMQ0J2Qnkqw16dA==", "f2bedd8f-258e-4925-9df4-71bbe50e41e4", new DateTime(2024, 5, 16, 15, 48, 4, 634, DateTimeKind.Utc).AddTicks(2479) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("50b95f41-7afa-4cda-aa7a-5fa49234d183"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash", "SecurityStamp", "UpdatedDateTime" },
                values: new object[] { "e9edeab2-8d97-4b16-8d12-0065d2673a84", new DateTime(2024, 5, 16, 15, 48, 4, 20, DateTimeKind.Utc).AddTicks(643), "AQAAAAIAAYagAAAAEGkUmNGjffBO/VYXx9liqxclbfGpbSPk8fvjnICa4muHidK58KoKnyx7+RpmMBi1/Q==", "ed552d91-b2dd-4247-9796-d2edee04caea", new DateTime(2024, 5, 16, 15, 48, 4, 20, DateTimeKind.Utc).AddTicks(645) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("50b95f41-7afa-4cda-aa7a-5fa49234d184"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash", "SecurityStamp", "UpdatedDateTime" },
                values: new object[] { "d68b83b5-659f-49ab-bd74-328ed814774e", new DateTime(2024, 5, 16, 15, 48, 4, 118, DateTimeKind.Utc).AddTicks(655), "AQAAAAIAAYagAAAAEDFS0d9waiHp4bx/OjXsAwg6CogtaqN0Qrzj5zWHwgGv7xbJ2AdDtu1PNVuS60qBGw==", "6d122aa1-8456-498e-8927-a72e909923a2", new DateTime(2024, 5, 16, 15, 48, 4, 118, DateTimeKind.Utc).AddTicks(658) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("56b2a1c9-a651-4fee-8f8e-5fa49234d199"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash", "SecurityStamp", "UpdatedDateTime" },
                values: new object[] { "415c9942-88fd-4eb6-9a76-6157b2f5d12d", new DateTime(2024, 5, 16, 15, 48, 5, 810, DateTimeKind.Utc).AddTicks(2301), "AQAAAAIAAYagAAAAEM4C8ZuKnxNBy54uhNuwSkUdt5+DL0cN4IhiLoZW3LhQbCC5bWNJFAsJtaSGpaYMvg==", "0671c679-06c7-4a22-893a-17d0654c4766", new DateTime(2024, 5, 16, 15, 48, 5, 810, DateTimeKind.Utc).AddTicks(2305) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("594f8fe1-1cf1-4f5a-a8ae-6b9509fbf283"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash", "SecurityStamp", "UpdatedDateTime" },
                values: new object[] { "14e6dee6-71c3-46bc-97cc-374bf518b6ba", new DateTime(2024, 5, 16, 15, 48, 3, 665, DateTimeKind.Utc).AddTicks(3205), "AQAAAAIAAYagAAAAEC+OaqVQ9ybj+zhlMMTMOO2gKzbxTKa3tkV6IAidU9MBPNwtbM3JbsUBnl3qiJuSfQ==", "de190c89-5293-47ae-9bc5-0247dcfece1c", new DateTime(2024, 5, 16, 15, 48, 3, 665, DateTimeKind.Utc).AddTicks(3207) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("5aca3775-d37e-473c-8f3a-3926ed32e360"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash", "SecurityStamp", "UpdatedDateTime" },
                values: new object[] { "82499e12-d42a-4ed4-9d4c-5440debeb777", new DateTime(2024, 5, 16, 15, 48, 6, 269, DateTimeKind.Utc).AddTicks(3041), "AQAAAAIAAYagAAAAECawHzVFnwRQdUfUCnYoK9bilGR2z5mRRfrfwLGyQxvUPomlOwstKaSkxBN013+ImA==", "452b40b4-28b9-40e6-8001-6361adc1778d", new DateTime(2024, 5, 16, 15, 48, 6, 269, DateTimeKind.Utc).AddTicks(3044) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("5c6a5f5e-3a11-4d42-bff8-5fa49234d188"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash", "SecurityStamp", "UpdatedDateTime" },
                values: new object[] { "6b1bf79a-7c1e-4f12-b8f4-ec46c3950909", new DateTime(2024, 5, 16, 15, 48, 4, 544, DateTimeKind.Utc).AddTicks(5574), "AQAAAAIAAYagAAAAEDDLn1ute7Bq/f85z7U1Q1wLJwi5FdgIMlkr4wyY/hE5ZuxEfGXvUoPhrPmVuSMtdg==", "3a4cf827-ec39-49e4-b120-66d2c1cbae87", new DateTime(2024, 5, 16, 15, 48, 4, 544, DateTimeKind.Utc).AddTicks(5577) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("60a119e1-610c-42fc-85c8-95a7e4d2119b"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash", "SecurityStamp", "UpdatedDateTime" },
                values: new object[] { "1284da79-cbba-4744-acbe-f7bb50d7ed66", new DateTime(2024, 5, 16, 15, 48, 7, 561, DateTimeKind.Utc).AddTicks(985), "AQAAAAIAAYagAAAAEC/SnudtWiZzv84EO1StN833Gga2FdrX8ntX6DCzzA4oh4+ko0/b7sMI0O3j4taC5A==", "92e5aad3-d685-4e18-842d-e569148dadf4", new DateTime(2024, 5, 16, 15, 48, 7, 561, DateTimeKind.Utc).AddTicks(988) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("60b9f0cc-b3b4-4ac3-a9ce-5fa49234d193"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash", "SecurityStamp", "UpdatedDateTime" },
                values: new object[] { "655cdccb-82d7-4992-8337-d0065b93cb86", new DateTime(2024, 5, 16, 15, 48, 5, 122, DateTimeKind.Utc).AddTicks(3871), "AQAAAAIAAYagAAAAEMi3E09XUX0lBKaItMDfEqhLVPgzGEPfNsazZrJ7iMO1YOKwBwaG4UXQGVib3Ns+mQ==", "a0216501-31a8-4b8b-a266-3e0effedd823", new DateTime(2024, 5, 16, 15, 48, 5, 122, DateTimeKind.Utc).AddTicks(3874) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("6c16a235-f928-4b8d-978f-5fa49234d194"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash", "SecurityStamp", "UpdatedDateTime" },
                values: new object[] { "bea3d00a-2c2d-4fa8-95ce-d83b9fdb427b", new DateTime(2024, 5, 16, 15, 48, 5, 257, DateTimeKind.Utc).AddTicks(5599), "AQAAAAIAAYagAAAAEA2ZcZ96RWOap1vcrmfuIaWpRHV5Obt0cw1FxnGefS0tWXHS6+PRlJgLvQWsGyohog==", "5b99efb2-cb3e-4019-a512-3e33518b1d22", new DateTime(2024, 5, 16, 15, 48, 5, 257, DateTimeKind.Utc).AddTicks(5601) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("6e2f7a2d-1994-419b-8c6d-b3d297cd7b06"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash", "SecurityStamp", "UpdatedDateTime" },
                values: new object[] { "928bf84d-09ef-4c75-9b6f-0f786fa95bd3", new DateTime(2024, 5, 16, 15, 48, 7, 324, DateTimeKind.Utc).AddTicks(4796), "AQAAAAIAAYagAAAAECU2jCWqzJhl7LRGhaDjubQ4QL31P2+62iVTQ/75XyhUJD89LYUdX4/NMUyOqA2Leg==", "f12d492a-c000-4434-9d6a-dd09952beadc", new DateTime(2024, 5, 16, 15, 48, 7, 324, DateTimeKind.Utc).AddTicks(4800) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("7db124bd-9953-4eb0-98f2-50b1be635544"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash", "SecurityStamp", "UpdatedDateTime" },
                values: new object[] { "775c41f4-b4aa-40a0-99e1-2f1bd8e26a1a", new DateTime(2024, 5, 16, 15, 48, 3, 905, DateTimeKind.Utc).AddTicks(3956), "AQAAAAIAAYagAAAAEAcPyvP5m3xHxIlowAONmVwUYkbdYVq1MgZdTJmNEepEaIVT3IHWU14TWNbOgzpkjA==", "f5a4bcf9-3509-41b3-9810-ba8b13d5c50f", new DateTime(2024, 5, 16, 15, 48, 3, 905, DateTimeKind.Utc).AddTicks(3959) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("853988db-ad55-4a28-9782-90438c64b62d"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash", "SecurityStamp", "UpdatedDateTime" },
                values: new object[] { "fbc3664c-5735-4152-93b8-39e3c410939b", new DateTime(2024, 5, 16, 15, 48, 7, 451, DateTimeKind.Utc).AddTicks(5707), "AQAAAAIAAYagAAAAEEy+E95fDNK6Sqcqkp075DbvJQSx9Ee9Hi+kWXlwi+70Vj9Ed5qXueiCSjOVCSzN8g==", "3e8ab264-79e7-447e-8b0a-d9c5e6c0d755", new DateTime(2024, 5, 16, 15, 48, 7, 451, DateTimeKind.Utc).AddTicks(5711) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("85d8a27f-9d32-4269-b5d0-844589d498d0"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash", "SecurityStamp", "UpdatedDateTime" },
                values: new object[] { "d4525dc2-4678-4fce-83fa-4c95a0619aa2", new DateTime(2024, 5, 16, 15, 48, 3, 58, DateTimeKind.Utc).AddTicks(6179), "AQAAAAIAAYagAAAAENgi98+4PbHl9Ac2kd9p7XFJScTFZCnRD8u409IHvSEDQuJUYU1GcJcUWqU6g9eI7g==", "5e1df2ed-5c9e-4cf0-af92-b66a23719cca", new DateTime(2024, 5, 16, 15, 48, 3, 58, DateTimeKind.Utc).AddTicks(6182) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("870559eb-5fde-4764-ade7-392b0cf6b5ce"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash", "SecurityStamp", "UpdatedDateTime" },
                values: new object[] { "c5e318f1-e001-419b-b423-4ed42f0f0e5a", new DateTime(2024, 5, 16, 15, 48, 7, 664, DateTimeKind.Utc).AddTicks(1434), "AQAAAAIAAYagAAAAEJJe7N0R+WJ4mEDqBp0YOmXo/3go/GLHbGpJ3VcfwIFQQJogiqdhnwCdzMjsd6i55A==", "11ad84c7-e8fc-4201-bdc6-a5500633554c", new DateTime(2024, 5, 16, 15, 48, 7, 664, DateTimeKind.Utc).AddTicks(1437) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("87787f6e-729b-436b-bcc9-c7b48c45ba05"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash", "SecurityStamp", "UpdatedDateTime" },
                values: new object[] { "c4e374e8-156b-4333-822b-1683d3dadf1c", new DateTime(2024, 5, 16, 15, 48, 6, 817, DateTimeKind.Utc).AddTicks(9713), "AQAAAAIAAYagAAAAELjWDXGVK3d9lyhCiQ88oDGBvbGyZwZgf2F/zRmr2M1oBDxQQHAHLqR4lIYOgR3zYQ==", "c52f8082-ad21-4a3b-9bc3-292ccca5789c", new DateTime(2024, 5, 16, 15, 48, 6, 817, DateTimeKind.Utc).AddTicks(9716) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("8c3b46b9-1321-4d97-a193-5fa49234d185"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash", "SecurityStamp", "UpdatedDateTime" },
                values: new object[] { "6a48f788-4b4b-4c6c-943f-caaf9155c5dc", new DateTime(2024, 5, 16, 15, 48, 4, 220, DateTimeKind.Utc).AddTicks(579), "AQAAAAIAAYagAAAAEFfhhdl/TtzbDHOpbPLI4SzjR5jy6679gPyFrs6DrV5OlLSn1M8aQiIL6JbY65+gfQ==", "de5086fb-6e48-4848-9a11-f3e5352644bb", new DateTime(2024, 5, 16, 15, 48, 4, 220, DateTimeKind.Utc).AddTicks(581) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("906f192a-96d3-433a-a7ea-288662b5f62d"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash", "SecurityStamp", "UpdatedDateTime" },
                values: new object[] { "92cde726-80bd-4f55-8676-e2bc72f74597", new DateTime(2024, 5, 16, 15, 48, 6, 542, DateTimeKind.Utc).AddTicks(7518), "AQAAAAIAAYagAAAAEKsXEd6I1kLX83GPqYLQC7TSTsf006TdPXJlg3c7F88m33lydiTKd+OlMPKzSoRoQA==", "5a46d429-66af-4dc5-89c2-9a7a0dfcef60", new DateTime(2024, 5, 16, 15, 48, 6, 542, DateTimeKind.Utc).AddTicks(7520) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("91d0da1b-e147-4829-aa4e-7073c1a10d2c"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash", "SecurityStamp", "UpdatedDateTime" },
                values: new object[] { "1bf808d8-58ff-4e38-b509-d06b3e7cb3dc", new DateTime(2024, 5, 16, 15, 48, 7, 8, DateTimeKind.Utc).AddTicks(8212), "AQAAAAIAAYagAAAAELHJoAlPGJU3DA+bU9lLbn8C44bjGHHvJ5AOePQ3AEoiB7HRnFJ083jN6MAd6hWoaA==", "1272636b-e948-4870-ace0-eed8bf91568a", new DateTime(2024, 5, 16, 15, 48, 7, 8, DateTimeKind.Utc).AddTicks(8216) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("9a4a34a4-4b12-4c8e-a52b-5fa49234d195"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash", "SecurityStamp", "UpdatedDateTime" },
                values: new object[] { "19e5ce52-aa68-4ecf-82ef-9e53d596a85d", new DateTime(2024, 5, 16, 15, 48, 5, 364, DateTimeKind.Utc).AddTicks(2273), "AQAAAAIAAYagAAAAEOrTm9ZAeNY3zYAKZHTCRe6u4zOD4wFfJz45bz4si2ol6+ELBR5jtAKn3da1jXEHbQ==", "23f34e2f-c788-4d95-84ca-00fdda16d5bb", new DateTime(2024, 5, 16, 15, 48, 5, 364, DateTimeKind.Utc).AddTicks(2275) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("9b8c6d7b-754f-420c-b574-4a63326bfc6a"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash", "SecurityStamp", "UpdatedDateTime" },
                values: new object[] { "e477ef6b-1a27-473b-8959-e73449937ca0", new DateTime(2024, 5, 16, 15, 48, 7, 232, DateTimeKind.Utc).AddTicks(1958), "AQAAAAIAAYagAAAAEIt8JDZRhjnfZqxSme33X9jHJ6d4JDoJVlCtHxooTRtIsKLgvMM/GXK5zei908PFfA==", "76d5cad8-4d3d-4daf-8df4-8771896c6d99", new DateTime(2024, 5, 16, 15, 48, 7, 232, DateTimeKind.Utc).AddTicks(1962) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("9d36fef6-9c75-4f96-a951-5fa49234d203"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash", "SecurityStamp", "UpdatedDateTime" },
                values: new object[] { "f8d00561-4c5f-4fa8-a246-dd466efb5335", new DateTime(2024, 5, 16, 15, 48, 6, 178, DateTimeKind.Utc).AddTicks(753), "AQAAAAIAAYagAAAAEI7vwMd7u6Iv8n6BkaLAwm3pr94pbRLgkI9lQC5FFM10Ns31Zl9AAilLIibRzxFwXA==", "458bb361-e96e-4fd9-8c67-04f1f2bfc447", new DateTime(2024, 5, 16, 15, 48, 6, 178, DateTimeKind.Utc).AddTicks(758) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("b2687ce8-aad5-4d5f-849b-dcd2b402aff0"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash", "SecurityStamp", "UpdatedDateTime" },
                values: new object[] { "b246b77d-95d1-415c-a600-8610ad62fe96", new DateTime(2024, 5, 16, 15, 48, 7, 849, DateTimeKind.Utc).AddTicks(961), "AQAAAAIAAYagAAAAEBzCXOPDTEcs2GuqO7cDmCZA/QDdGFdbE2klIzAwfQjMaI1tjZuNlpQn92n6eXKJ/A==", "38e453f2-6134-43b2-98f2-7dec6ef788ce", new DateTime(2024, 5, 16, 15, 48, 7, 849, DateTimeKind.Utc).AddTicks(963) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("b6123f4e-3443-41ae-a1cb-5fa49234d187"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash", "SecurityStamp", "UpdatedDateTime" },
                values: new object[] { "566b359d-685e-4300-a864-83c1bb10f0a9", new DateTime(2024, 5, 16, 15, 48, 4, 449, DateTimeKind.Utc).AddTicks(1672), "AQAAAAIAAYagAAAAEHyd5Yc1J1IHVG6pNw67oGk1UZtYK4ftlg3lzJgwQEykDtgvXbghHb/+GPcnjuTMyQ==", "73a9073c-6bf7-4d77-bcdb-b716e62c7ed7", new DateTime(2024, 5, 16, 15, 48, 4, 449, DateTimeKind.Utc).AddTicks(1675) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("c0a7e4f4-d8d0-4c80-8e1c-5fa49234d201"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash", "SecurityStamp", "UpdatedDateTime" },
                values: new object[] { "b370bacc-4f47-4507-ab33-591a1116e358", new DateTime(2024, 5, 16, 15, 48, 5, 992, DateTimeKind.Utc).AddTicks(8464), "AQAAAAIAAYagAAAAEGgZZKTkACpPxuFY9azL2vsdWpY0TeZd53DJmFfbF/gAuLGW85Vhf53geKrKT5pHbw==", "f84308fa-daa6-4da7-8c2f-05befcd9048f", new DateTime(2024, 5, 16, 15, 48, 5, 992, DateTimeKind.Utc).AddTicks(8466) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("c55cdfd0-d1dd-4841-ae27-f2d621686756"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash", "SecurityStamp", "UpdatedDateTime" },
                values: new object[] { "ec0211d3-e5ef-46a7-9b16-8ff750fd7772", new DateTime(2024, 5, 16, 15, 48, 6, 633, DateTimeKind.Utc).AddTicks(4841), "AQAAAAIAAYagAAAAEH+rhr8CPrnpjy9F72x7LfZMwF+ZXF9kypT90xSflqAUZ/+8spGJs5+2ZYwNtMIAfQ==", "97db90c9-08c1-43b8-a37b-f5a8c01d0bfc", new DateTime(2024, 5, 16, 15, 48, 6, 633, DateTimeKind.Utc).AddTicks(4844) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("d0e03a1a-21c2-4123-a75e-5fa49234d191"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash", "SecurityStamp", "UpdatedDateTime" },
                values: new object[] { "bd521b7c-9104-4ac8-ac6b-ee9c7224f5a7", new DateTime(2024, 5, 16, 15, 48, 4, 838, DateTimeKind.Utc).AddTicks(3232), "AQAAAAIAAYagAAAAEMV8PwfC4zhL5kpI943qDeRtZQhbyesugYzHPijbdbbc2h23B87imZynEX8sDgK/CA==", "9d3eaab7-d021-4f92-8114-f4120f42ec3e", new DateTime(2024, 5, 16, 15, 48, 4, 838, DateTimeKind.Utc).AddTicks(3235) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("d30fa796-5144-4467-a302-68dc64fd0d92"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash", "SecurityStamp", "UpdatedDateTime" },
                values: new object[] { "cdb68856-8cd4-4366-ab90-e8ca0ad32ec8", new DateTime(2024, 5, 16, 15, 48, 6, 907, DateTimeKind.Utc).AddTicks(4450), "AQAAAAIAAYagAAAAEH15TGoSdZnI5Stx8tEo1QyYbvIaOVwGs/TJ6E0VyTaNIZJjr2ouM1WC+vfFUkMw6Q==", "61e83ebe-4a5c-4de0-99ed-3f738ea24586", new DateTime(2024, 5, 16, 15, 48, 6, 907, DateTimeKind.Utc).AddTicks(4453) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e92c6f32-859b-443b-bfb2-bd0674b5673a"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash", "SecurityStamp", "UpdatedDateTime" },
                values: new object[] { "e6970246-6105-4a9e-8128-9969500a608f", new DateTime(2024, 5, 16, 15, 48, 6, 359, DateTimeKind.Utc).AddTicks(3974), "AQAAAAIAAYagAAAAEGfkHP8gRe4VPlidzPz6ljI9EtSPwwYbsJAL73+qOjfPnm1xbOnshgPulHKI7dJyQA==", "95bec683-e62e-46da-a2bf-3c6829c72c55", new DateTime(2024, 5, 16, 15, 48, 6, 359, DateTimeKind.Utc).AddTicks(3977) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("eee6e626-9a26-4f38-bbe3-433d20440ce9"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash", "SecurityStamp", "UpdatedDateTime" },
                values: new object[] { "3d8d9ce5-ce87-4cab-97f7-f60bb9fe818c", new DateTime(2024, 5, 16, 15, 48, 3, 780, DateTimeKind.Utc).AddTicks(2838), "AQAAAAIAAYagAAAAEEmTILrSv54pBbi22x5qJiNyXzYpASHD7241irl+OZIINo1HKDE5cMqL+rKSl1Bqmw==", "c9b4d607-859d-48d6-bf12-1936caf50e3a", new DateTime(2024, 5, 16, 15, 48, 3, 780, DateTimeKind.Utc).AddTicks(2843) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("eeed5a4d-e83d-4032-8c3c-5fa49234d197"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash", "SecurityStamp", "UpdatedDateTime" },
                values: new object[] { "96f5a266-9a14-401a-8ddb-875d57b18c93", new DateTime(2024, 5, 16, 15, 48, 5, 593, DateTimeKind.Utc).AddTicks(7666), "AQAAAAIAAYagAAAAEP4jIyGlcZsUY8jUCRoINVIuMdPhAV/HJ1kjpTVq3jvvquy94vgsd7x97d/pckAe9g==", "afd31cb1-2755-4558-a7ea-458ab0bf28a8", new DateTime(2024, 5, 16, 15, 48, 5, 593, DateTimeKind.Utc).AddTicks(7669) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("f483fb9f-477c-4a3a-9f73-3b028b06ed49"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash", "SecurityStamp", "UpdatedDateTime" },
                values: new object[] { "5189ea3a-8db5-440b-8295-613f840b9da5", new DateTime(2024, 5, 16, 15, 48, 6, 722, DateTimeKind.Utc).AddTicks(3962), "AQAAAAIAAYagAAAAENIzpEumGsdQhvCB6fZ2eqLyAWKwJpL5OmoFsu+YE6Imwd++8L4ji05VBeIDV9h5wA==", "35281935-d299-4242-aa07-d42b2d4086e3", new DateTime(2024, 5, 16, 15, 48, 6, 722, DateTimeKind.Utc).AddTicks(3964) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("fbd62259-a313-4d38-885e-1f6acdf9a30a"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash", "SecurityStamp", "UpdatedDateTime" },
                values: new object[] { "3fd4d310-365d-4e5a-a105-81cf026e185e", new DateTime(2024, 5, 16, 15, 48, 7, 122, DateTimeKind.Utc).AddTicks(4150), "AQAAAAIAAYagAAAAEDLXPBlwGsthY3XoZbBs6HyjYOtatTBtLIXdqDkhEDpYGRxiirK4XcDdi3aCQS5SxA==", "7e4c8eef-0b68-4680-aad6-2da2362e6545", new DateTime(2024, 5, 16, 15, 48, 7, 122, DateTimeKind.Utc).AddTicks(4153) });

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: new Guid("292c90a5-1a0a-45a4-8f3d-37f09b09b422"),
                columns: new[] { "CreatedDateTime", "UpdatedDateTime" },
                values: new object[] { new DateTime(2024, 5, 16, 15, 48, 7, 954, DateTimeKind.Utc).AddTicks(7323), new DateTime(2024, 5, 16, 15, 48, 7, 954, DateTimeKind.Utc).AddTicks(7323) });

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: new Guid("2baf4c50-c927-4b54-971e-3ff5f300e147"),
                columns: new[] { "CreatedDateTime", "UpdatedDateTime" },
                values: new object[] { new DateTime(2024, 5, 16, 15, 48, 7, 954, DateTimeKind.Utc).AddTicks(7307), new DateTime(2024, 5, 16, 15, 48, 7, 954, DateTimeKind.Utc).AddTicks(7309) });

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: new Guid("97cf6bd7-7290-449a-a61d-5ea2fdfcf8de"),
                columns: new[] { "CreatedDateTime", "UpdatedDateTime" },
                values: new object[] { new DateTime(2024, 5, 16, 15, 48, 7, 954, DateTimeKind.Utc).AddTicks(7325), new DateTime(2024, 5, 16, 15, 48, 7, 954, DateTimeKind.Utc).AddTicks(7326) });

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: new Guid("99ada3c1-eea5-4431-a529-b3114de224da"),
                columns: new[] { "CreatedDateTime", "UpdatedDateTime" },
                values: new object[] { new DateTime(2024, 5, 16, 15, 48, 7, 954, DateTimeKind.Utc).AddTicks(7317), new DateTime(2024, 5, 16, 15, 48, 7, 954, DateTimeKind.Utc).AddTicks(7318) });

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: new Guid("adf36edc-3e08-4a36-8e20-0d79747f0962"),
                columns: new[] { "CreatedDateTime", "UpdatedDateTime" },
                values: new object[] { new DateTime(2024, 5, 16, 15, 48, 7, 954, DateTimeKind.Utc).AddTicks(7320), new DateTime(2024, 5, 16, 15, 48, 7, 954, DateTimeKind.Utc).AddTicks(7321) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("9243d741-a350-4067-bb29-395e9becf57e"),
                column: "CreatedDateTime",
                value: new DateTime(2024, 5, 16, 15, 48, 7, 956, DateTimeKind.Utc).AddTicks(9243));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("e21f3a87-20d5-420e-ba33-9108df996747"),
                column: "CreatedDateTime",
                value: new DateTime(2024, 5, 16, 15, 48, 7, 956, DateTimeKind.Utc).AddTicks(9361));

            migrationBuilder.AddForeignKey(
                name: "FK_CartItems_Carts_CartId",
                table: "CartItems",
                column: "CartId",
                principalTable: "Carts",
                principalColumn: "Id");
        }
    }
}
