using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.Infrastructure.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class _3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisterAt", "SecurityStamp" },
                values: new object[] { "d849a7cc-da1e-4239-a440-512e4708929f", "AQAAAAIAAYagAAAAEHZWc/OeSjvpsiFlFiZLIhSTjAZxVIMTt1EUtdJEPYEfUZgeNJR+vhzn1ZbOKxJFUQ==", new DateTime(2025, 2, 14, 13, 7, 1, 634, DateTimeKind.Local).AddTicks(4376), "f9683057-55c5-49db-9efb-4e8ed7516cd6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisterAt", "SecurityStamp" },
                values: new object[] { "077c13e3-00de-4f38-a8fe-3bfbeff21b7c", "AQAAAAIAAYagAAAAEJOwfoRfey8c9+hKSt+9J5XnRNxhYvYCUNjUZiCmH3fF3b2++l4Y+CKPfmcLbwjTWA==", new DateTime(2025, 2, 14, 13, 7, 1, 634, DateTimeKind.Local).AddTicks(4421), "5316fa3e-67e2-4e40-a710-546d0a140de9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisterAt", "SecurityStamp" },
                values: new object[] { "f89aa78a-748f-44a0-ab59-94e2404780dc", "AQAAAAIAAYagAAAAEInZRjNp+iTOsRW94W6QWhqcgQlCTiNWnF62XfDbSJ/b88Y5eZqgLGMIb+rzYVoGTg==", new DateTime(2025, 2, 14, 13, 7, 1, 634, DateTimeKind.Local).AddTicks(4434), "276fdad5-ee0f-406d-a720-ba4cb0733bc1" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "IsActive", "PasswordHash", "RegisterAt", "SecurityStamp" },
                values: new object[] { "b44573d5-801e-4e99-b1d2-4e05cfc039f9", false, "AQAAAAIAAYagAAAAENuImFk9dkVW6GcoO+LfsAxNgwiKwE9b8QhflkPz5Xys4sTgmqI6lzEBO8ANxk0Kcg==", new DateTime(2025, 2, 14, 12, 9, 34, 462, DateTimeKind.Local).AddTicks(3179), "e06d9631-2568-423d-96b5-3f5bc356475e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "IsActive", "PasswordHash", "RegisterAt", "SecurityStamp" },
                values: new object[] { "ae56c95c-e345-47bd-a5ad-b3a85f3a01b1", false, "AQAAAAIAAYagAAAAECUDueXMYmu0FTLcyD3vPhEZZ/HD7WdPTuMBWqQz5AMdtVLvlWhX6Hjt5OlpjgMxiQ==", new DateTime(2025, 2, 14, 12, 9, 34, 462, DateTimeKind.Local).AddTicks(3199), "ec549ff5-4c31-4b49-8e26-ea73a7ceeaef" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "IsActive", "PasswordHash", "RegisterAt", "SecurityStamp" },
                values: new object[] { "5e92eef0-f9fb-48e9-bb0d-0e85e145885c", false, "AQAAAAIAAYagAAAAEOT5/yjMgYk0XMO/goHwJHxCX/UHb/n+6Z3ISCg89bYcF5Iif7K3YGa5+JigfSdNhg==", new DateTime(2025, 2, 14, 12, 9, 34, 462, DateTimeKind.Local).AddTicks(3217), "e1f131e4-e163-4591-a09f-d360716116a8" });
        }
    }
}
