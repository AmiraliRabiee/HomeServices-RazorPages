using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.Infrastructure.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class _8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsPresented",
                table: "Suggestions",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisterAt", "SecurityStamp" },
                values: new object[] { "0267e665-b6c5-4558-bb72-4bea965431b0", "AQAAAAIAAYagAAAAENS3bzZftavKPTkgdQgZcUEH1jyvbMZTapNTw4TThgTT133F+lixGYVyirhMRIGEgQ==", new DateTime(2025, 3, 10, 10, 33, 44, 439, DateTimeKind.Local).AddTicks(7095), "95fabc62-7c57-4cba-955c-9018434ca9fa" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisterAt", "SecurityStamp" },
                values: new object[] { "b31228ac-cdc7-4553-b55f-571a65c7009a", "AQAAAAIAAYagAAAAEPIUU2CpMozIKQplJQMxGF/Eah+6VaU5yEbTUcvgmI74Q6+CI5BNiOwLxsNFN2lCNA==", new DateTime(2025, 3, 10, 10, 33, 44, 439, DateTimeKind.Local).AddTicks(7118), "6a6c34fe-75d1-4be1-8d10-a6103a51ae16" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisterAt", "SecurityStamp" },
                values: new object[] { "e46584dc-5d29-4694-a9f9-a4a9d1710d11", "AQAAAAIAAYagAAAAEJtLjXlvkCOf7TmB9zzjuKcMsLaeNzqIS8eYCsoWYTYFbZ5yQANNS9zwcsbefsE0jg==", new DateTime(2025, 3, 10, 10, 33, 44, 439, DateTimeKind.Local).AddTicks(7144), "0f5a7253-345c-48c3-8bcc-688b45ea0f2c" });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2025, 3, 10, 10, 33, 44, 437, DateTimeKind.Local).AddTicks(9096));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateAt",
                value: new DateTime(2025, 3, 10, 10, 33, 44, 437, DateTimeKind.Local).AddTicks(9104));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateAt",
                value: new DateTime(2025, 3, 10, 10, 33, 44, 437, DateTimeKind.Local).AddTicks(9106));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2025, 3, 10, 10, 33, 44, 437, DateTimeKind.Local).AddTicks(4415));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateAt",
                value: new DateTime(2025, 3, 10, 10, 33, 44, 437, DateTimeKind.Local).AddTicks(4435));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateAt",
                value: new DateTime(2025, 3, 10, 10, 33, 44, 437, DateTimeKind.Local).AddTicks(4438));

            migrationBuilder.UpdateData(
                table: "Suggestions",
                keyColumn: "Id",
                keyValue: 1,
                column: "IsPresented",
                value: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsPresented",
                table: "Suggestions");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisterAt", "SecurityStamp" },
                values: new object[] { "801f538a-26eb-4d66-ac49-4fb09353ae66", "AQAAAAIAAYagAAAAEAceSZIlIzNYAfrV+dxNXhs5LkLieN/DfLrkuVA0ItfYEPo5+Sqv3to57VQU2UiGlg==", new DateTime(2025, 3, 10, 10, 10, 24, 704, DateTimeKind.Local).AddTicks(9883), "5fc78915-7831-4249-b818-6d1a1cf6387f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisterAt", "SecurityStamp" },
                values: new object[] { "3d6bdd7f-ed73-447a-bc17-98236a6593c5", "AQAAAAIAAYagAAAAEECrBICu94bJl/AIKAtyMeZMs2WiHIbe50pxtqQpF00nDO0Er4E7uMz9z6Y4ygY9+g==", new DateTime(2025, 3, 10, 10, 10, 24, 704, DateTimeKind.Local).AddTicks(9905), "4c863325-bf3f-4e53-b726-c2aa80735eb3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisterAt", "SecurityStamp" },
                values: new object[] { "975fe391-947b-45fa-b462-7e69ca4f56e9", "AQAAAAIAAYagAAAAEE4B99BSg/gIdwQPw2hSb269O+xew+Oz9nobqOtBb49C1JnGP2nsaZBjYyHPSxz8ig==", new DateTime(2025, 3, 10, 10, 10, 24, 704, DateTimeKind.Local).AddTicks(9930), "0f32816a-e38b-4ca2-b538-2c273e9770f3" });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2025, 3, 10, 10, 10, 24, 702, DateTimeKind.Local).AddTicks(9882));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateAt",
                value: new DateTime(2025, 3, 10, 10, 10, 24, 702, DateTimeKind.Local).AddTicks(9889));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateAt",
                value: new DateTime(2025, 3, 10, 10, 10, 24, 702, DateTimeKind.Local).AddTicks(9892));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2025, 3, 10, 10, 10, 24, 702, DateTimeKind.Local).AddTicks(5968));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateAt",
                value: new DateTime(2025, 3, 10, 10, 10, 24, 702, DateTimeKind.Local).AddTicks(5989));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateAt",
                value: new DateTime(2025, 3, 10, 10, 10, 24, 702, DateTimeKind.Local).AddTicks(5991));
        }
    }
}
