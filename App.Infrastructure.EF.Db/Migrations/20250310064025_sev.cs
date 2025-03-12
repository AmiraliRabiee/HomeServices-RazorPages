using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.Infrastructure.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class sev : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreateAt",
                table: "Suggestions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateAt",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

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

            migrationBuilder.UpdateData(
                table: "Suggestions",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreateAt",
                table: "Suggestions");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateAt",
                table: "Orders",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisterAt", "SecurityStamp" },
                values: new object[] { "b8657b7d-45e4-42c2-8e85-1b00c2a4c377", "AQAAAAIAAYagAAAAEBl/dHIDXRYI5L7x0ubDyW7Mx/DoPwTEQ85oRlf7TzNRZoEEYL6WW3hlVEcit/k4qg==", new DateTime(2025, 3, 7, 9, 57, 21, 282, DateTimeKind.Local).AddTicks(6999), "a1edc64e-c3a0-4c57-adab-7f55a5f5b633" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisterAt", "SecurityStamp" },
                values: new object[] { "15717500-5b5b-4e3e-af34-fb6c0de5d3c0", "AQAAAAIAAYagAAAAEHr9MplrSS91ih0YKM2a7hp7II8ZhOGMLhKR9rkmoaBBJlcBaXRYGElJxiUgQ407hQ==", new DateTime(2025, 3, 7, 9, 57, 21, 282, DateTimeKind.Local).AddTicks(7040), "56163b22-50ad-4f5d-a7de-056137f36e40" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisterAt", "SecurityStamp" },
                values: new object[] { "a3284c38-76c1-48f3-87c4-fe862294b89a", "AQAAAAIAAYagAAAAEAmktvUstR/akgxRKAwN2MinzZvVXsauUnkfflP8nh/wdYr7VcCykC/J5utnVpaHXA==", new DateTime(2025, 3, 7, 9, 57, 21, 282, DateTimeKind.Local).AddTicks(7101), "8efe2d65-3e09-47ad-9a38-ad474aeaaf4f" });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2025, 3, 7, 9, 57, 21, 279, DateTimeKind.Local).AddTicks(8796));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateAt",
                value: new DateTime(2025, 3, 7, 9, 57, 21, 279, DateTimeKind.Local).AddTicks(8808));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateAt",
                value: new DateTime(2025, 3, 7, 9, 57, 21, 279, DateTimeKind.Local).AddTicks(8811));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2025, 3, 7, 9, 57, 21, 279, DateTimeKind.Local).AddTicks(4296));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateAt",
                value: new DateTime(2025, 3, 7, 9, 57, 21, 279, DateTimeKind.Local).AddTicks(4318));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateAt",
                value: new DateTime(2025, 3, 7, 9, 57, 21, 279, DateTimeKind.Local).AddTicks(4322));
        }
    }
}
