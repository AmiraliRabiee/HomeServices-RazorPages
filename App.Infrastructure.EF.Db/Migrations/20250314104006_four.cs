using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.Infrastructure.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class four : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisterAt", "SecurityStamp" },
                values: new object[] { "2084300e-9c19-45ff-8012-ab3fa043f127", "AQAAAAIAAYagAAAAEHU+7OS4gPymjgclc+dokeJYcwLJaJwAFVJHhp/aRsI/KBl2Dr9UjU9Sfy6d5ejwGA==", new DateTime(2025, 3, 14, 14, 10, 6, 40, DateTimeKind.Local).AddTicks(1770), "3a7bd0d4-df2f-4561-a957-28c4af4519b9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisterAt", "SecurityStamp" },
                values: new object[] { "cd37a005-92c2-4ce2-90bb-515eda1ead82", "AQAAAAIAAYagAAAAEE61AuheTg5ilFR6LXPWuFHF8qqeywU26RBWBXQpdcFxXZUmj/uRgxDA0YCo4tjf6g==", new DateTime(2025, 3, 14, 14, 10, 6, 40, DateTimeKind.Local).AddTicks(1799), "2fea647e-6b3e-49ea-b9cc-529da6eb4e2a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisterAt", "SecurityStamp" },
                values: new object[] { "ec677470-b91f-4581-bf15-ef8563a13b6f", "AQAAAAIAAYagAAAAEBBxlUasWv/sOTxSZkthv1hXFq2ioU3MrKNeTN0OtM0BuwvxMN+Ysd4DyNwggMi2ug==", new DateTime(2025, 3, 14, 14, 10, 6, 40, DateTimeKind.Local).AddTicks(1812), "2f5fc472-3f33-41b0-b24c-68d800c07142" });

            migrationBuilder.UpdateData(
                table: "HouseWorks",
                keyColumn: "Id",
                keyValue: 76,
                column: "ImagePath",
                value: "\\Images\\HomeServices\\76h.JPG");

            migrationBuilder.UpdateData(
                table: "HouseWorks",
                keyColumn: "Id",
                keyValue: 88,
                column: "ImagePath",
                value: "\\Images\\HomeServices\\88h.jpg");

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2025, 3, 14, 14, 10, 6, 37, DateTimeKind.Local).AddTicks(9332));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateAt",
                value: new DateTime(2025, 3, 14, 14, 10, 6, 37, DateTimeKind.Local).AddTicks(9410));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateAt",
                value: new DateTime(2025, 3, 14, 14, 10, 6, 37, DateTimeKind.Local).AddTicks(9413));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisterAt", "SecurityStamp" },
                values: new object[] { "d1240e06-0fba-4c82-9296-342038e2a44d", "AQAAAAIAAYagAAAAEFdNmCy7qnFu9qKKsJIgEildm6xVMDhSHdtMhZaNHHf6KOxNILgYOk/cBozcFdtFiw==", new DateTime(2025, 3, 13, 16, 16, 18, 150, DateTimeKind.Local).AddTicks(8687), "e4aa746a-11ef-4553-bd91-a4882bc07131" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisterAt", "SecurityStamp" },
                values: new object[] { "be9ba985-c039-4070-995c-1ff7f5a46de3", "AQAAAAIAAYagAAAAEESWoJDNDGWj9mHPCR9LBdjL9WQEbUduaLSuFH7/VNqrUg+7z12IemRtNL1afz2Tfw==", new DateTime(2025, 3, 13, 16, 16, 18, 150, DateTimeKind.Local).AddTicks(8715), "8bf078df-0abf-43c6-81a4-9b3f8ecfb536" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisterAt", "SecurityStamp" },
                values: new object[] { "4ec494d1-0b49-45f7-b86c-8e4104448055", "AQAAAAIAAYagAAAAEOJIxDpSMDCbc7bi/a2Giph0Rz2eKFXMfxs4d6qXRbZE8xMNUzdVpwTCrn428RJetg==", new DateTime(2025, 3, 13, 16, 16, 18, 150, DateTimeKind.Local).AddTicks(8728), "dedffc9d-2927-470c-89d7-28fad014ff68" });

            migrationBuilder.UpdateData(
                table: "HouseWorks",
                keyColumn: "Id",
                keyValue: 76,
                column: "ImagePath",
                value: "");

            migrationBuilder.UpdateData(
                table: "HouseWorks",
                keyColumn: "Id",
                keyValue: 88,
                column: "ImagePath",
                value: "");

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2025, 3, 13, 16, 16, 18, 148, DateTimeKind.Local).AddTicks(6764));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateAt",
                value: new DateTime(2025, 3, 13, 16, 16, 18, 148, DateTimeKind.Local).AddTicks(6781));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateAt",
                value: new DateTime(2025, 3, 13, 16, 16, 18, 148, DateTimeKind.Local).AddTicks(6783));
        }
    }
}
