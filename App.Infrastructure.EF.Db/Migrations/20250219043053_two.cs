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
            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisterAt", "SecurityStamp" },
                values: new object[] { "afbfff0d-d628-4a0b-871c-86c60629c664", "AQAAAAIAAYagAAAAEGhm6r22F/+mIVxq+0Hz2wU7XbsKOqOxfJNpUev6DO3cQYqw6M/Pdi1cSXy8pxAi+A==", new DateTime(2025, 2, 19, 8, 0, 52, 656, DateTimeKind.Local).AddTicks(175), "98c12414-aab6-47dc-b11f-840b55789791" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisterAt", "SecurityStamp" },
                values: new object[] { "d743dab0-ee28-4896-aab4-63f7c28c7492", "AQAAAAIAAYagAAAAEM6WL1NCX7x5M2RIwlithW+2wNJX21S8pylNbbxxt/7q1FdLuiCc7jaWPeIaGkjLrA==", new DateTime(2025, 2, 19, 8, 0, 52, 656, DateTimeKind.Local).AddTicks(218), "082a55a5-a73e-4c27-8837-7450c00033af" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisterAt", "SecurityStamp" },
                values: new object[] { "db92e008-c455-4ee5-8c54-deba5d19ddb9", "AQAAAAIAAYagAAAAEI/MaxgcYeRz3EzA0SOm6Py9MiJ2kpUb9ap43Ckf49fEErniEdnw5yo2RAsp4VpjTQ==", new DateTime(2025, 2, 19, 8, 0, 52, 656, DateTimeKind.Local).AddTicks(257), "4ceee6fb-96d2-48c6-8ae8-f5aca53c01a8" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisterAt", "SecurityStamp" },
                values: new object[] { "82b293ed-7225-4771-b98a-67c5d1294ba9", "AQAAAAIAAYagAAAAEPWbAbUm5M2+XMQu5GsSCT5qLNSSOYTrr7Un6vdTNYUXbn1pmk3Lb1LVWFytotg/Ew==", new DateTime(2025, 2, 19, 7, 47, 56, 216, DateTimeKind.Local).AddTicks(4870), "6f4bc1bc-4853-4601-9dbc-f408e98dcb2d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisterAt", "SecurityStamp" },
                values: new object[] { "848a9b58-e478-4c79-87f5-642de9e373e8", "AQAAAAIAAYagAAAAEHIWS75Jdki0h+vQr5FUf7xyrTyhNdclJruQj68xqRWMxnQ58WOtftpcnyg9vB0F0g==", new DateTime(2025, 2, 19, 7, 47, 56, 216, DateTimeKind.Local).AddTicks(4901), "2096055b-1155-461e-9fc7-c86b3524f492" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisterAt", "SecurityStamp" },
                values: new object[] { "7608a4f9-799e-47d7-a73e-ed08b9380b33", "AQAAAAIAAYagAAAAEL1fMPK82Mk+Er3Ikyuazncg8bS4PqsV7rTcHGDjRJ7p28bULo4+tADcG63Kbv628w==", new DateTime(2025, 2, 19, 7, 47, 56, 216, DateTimeKind.Local).AddTicks(4926), "2f14651a-33a3-4f25-94da-3b1461c84298" });
        }
    }
}
