using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.Infrastructure.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class two : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisterAt", "SecurityStamp" },
                values: new object[] { "b44573d5-801e-4e99-b1d2-4e05cfc039f9", "AQAAAAIAAYagAAAAENuImFk9dkVW6GcoO+LfsAxNgwiKwE9b8QhflkPz5Xys4sTgmqI6lzEBO8ANxk0Kcg==", new DateTime(2025, 2, 14, 12, 9, 34, 462, DateTimeKind.Local).AddTicks(3179), "e06d9631-2568-423d-96b5-3f5bc356475e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisterAt", "SecurityStamp" },
                values: new object[] { "ae56c95c-e345-47bd-a5ad-b3a85f3a01b1", "AQAAAAIAAYagAAAAECUDueXMYmu0FTLcyD3vPhEZZ/HD7WdPTuMBWqQz5AMdtVLvlWhX6Hjt5OlpjgMxiQ==", new DateTime(2025, 2, 14, 12, 9, 34, 462, DateTimeKind.Local).AddTicks(3199), "ec549ff5-4c31-4b49-8e26-ea73a7ceeaef" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisterAt", "SecurityStamp" },
                values: new object[] { "5e92eef0-f9fb-48e9-bb0d-0e85e145885c", "AQAAAAIAAYagAAAAEOT5/yjMgYk0XMO/goHwJHxCX/UHb/n+6Z3ISCg89bYcF5Iif7K3YGa5+JigfSdNhg==", new DateTime(2025, 2, 14, 12, 9, 34, 462, DateTimeKind.Local).AddTicks(3217), "e1f131e4-e163-4591-a09f-d360716116a8" });

            migrationBuilder.InsertData(
                table: "Expert",
                columns: new[] { "Id", "Address", "Biographi", "IsDeleted", "Points" },
                values: new object[] { 1, "اینجا", "بیوگرافی", false, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Expert",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisterAt", "SecurityStamp" },
                values: new object[] { "a297aa3a-520d-4f9c-a1c3-422ef3b55427", "AQAAAAIAAYagAAAAEDXLO092AuBNTSvZTgVQ5dyKjZPrVK4rtBWTMcCVP/lxNsuL9F6aqq3d4p0/3fDTdw==", new DateTime(2025, 2, 14, 12, 8, 0, 260, DateTimeKind.Local).AddTicks(3232), "5c781d48-5e65-46b7-b444-15781e50a19c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisterAt", "SecurityStamp" },
                values: new object[] { "3fe0360c-e645-4e4c-b207-42c2cb79ad83", "AQAAAAIAAYagAAAAEEZCbR0yabfWPhrdwVG2pTzsnKk1aCcvcGdD0x3Z9ECQqcGSjYXpP16blRdJ4HYsog==", new DateTime(2025, 2, 14, 12, 8, 0, 260, DateTimeKind.Local).AddTicks(3266), "bb75d03c-dfa6-403a-8e1d-fed87a45ce34" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisterAt", "SecurityStamp" },
                values: new object[] { "9eabcc45-0321-483c-a622-53a893a2314c", "AQAAAAIAAYagAAAAEJTHUPv+19dVQOvhwqrJA9RxcNAAaGAQThrY7CAHn6ZxfFudG0r5cgkM04d/xmIXEQ==", new DateTime(2025, 2, 14, 12, 8, 0, 260, DateTimeKind.Local).AddTicks(3276), "e2f14191-b6a1-4901-b4a8-96ea2e2cee2a" });
        }
    }
}
