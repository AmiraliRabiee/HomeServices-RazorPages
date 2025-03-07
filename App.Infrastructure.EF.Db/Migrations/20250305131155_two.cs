using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

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
                values: new object[] { "185e6475-ba0c-41f1-8e21-9800b9b90d1e", "AQAAAAIAAYagAAAAELVvzthfg1MvBdX3ELIARg6ReciWmxkxT2KU69CJ/LRAMMOUM0Zs3uw4y2KYnRahuw==", new DateTime(2025, 3, 5, 16, 41, 54, 451, DateTimeKind.Local).AddTicks(9399), "0e769a93-726e-4af1-84c6-8787a9bb567d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisterAt", "SecurityStamp" },
                values: new object[] { "ecc8747b-7002-4a52-abd7-9e674e410103", "AQAAAAIAAYagAAAAEBL76kFMZWM+5sZaErUXT21Rbd+a1v/QYiE+dy3QrEhxjVvH4XZmpMxeXkBLlY/hQg==", new DateTime(2025, 3, 5, 16, 41, 54, 451, DateTimeKind.Local).AddTicks(9421), "2c0041c3-1c1b-40f8-8e7b-8a1b557799d0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisterAt", "SecurityStamp" },
                values: new object[] { "ff0723b6-68b5-4274-aa88-9d5e9bcc4a9e", "AQAAAAIAAYagAAAAEEsLJuJYiCfe+pJgujH5En7tKszSqIFQSmXT8EgZ1e94UIfHoSP2abOSc+2XctHiKg==", new DateTime(2025, 3, 5, 16, 41, 54, 451, DateTimeKind.Local).AddTicks(9449), "412cff43-2faf-4112-93f8-49090df32bb8" });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "CreateAt", "CustomerId", "ExpertId", "IsDeleted", "IsPlayable", "Opinion", "Points", "stausService" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 3, 5, 16, 41, 54, 449, DateTimeKind.Local).AddTicks(8789), 4, 1, false, false, "بسیار تمیز و بادقت", 9, null },
                    { 2, new DateTime(2025, 3, 5, 16, 41, 54, 449, DateTimeKind.Local).AddTicks(8798), 4, 1, false, false, "تحویل به موقع", 9, null },
                    { 3, new DateTime(2025, 3, 5, 16, 41, 54, 449, DateTimeKind.Local).AddTicks(8800), 4, 1, false, false, "پاسخگویی بد", 6, null }
                });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2025, 3, 5, 16, 41, 54, 449, DateTimeKind.Local).AddTicks(3866));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateAt",
                value: new DateTime(2025, 3, 5, 16, 41, 54, 449, DateTimeKind.Local).AddTicks(3890));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateAt",
                value: new DateTime(2025, 3, 5, 16, 41, 54, 449, DateTimeKind.Local).AddTicks(3893));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisterAt", "SecurityStamp" },
                values: new object[] { "a48a1cca-8905-478f-be05-34d85810f6d7", "AQAAAAIAAYagAAAAEHcmKdUvop4wXHcq1Jy3vD7my+edJ3Wkjp0XZW12zbYCRbbaz2tBA6AHL/9uG1aljA==", new DateTime(2025, 3, 5, 16, 39, 0, 196, DateTimeKind.Local).AddTicks(2833), "a9f0af26-a4ef-498e-b320-2c487d8c2e2b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisterAt", "SecurityStamp" },
                values: new object[] { "bad1d0d9-65cb-4d09-bfc7-6255025e0515", "AQAAAAIAAYagAAAAECBjHgKNmpUDAO/Gdv0RPW/x/wciK2yWtLohgWmajexQZSZmSY72vBXALw2BL7aAVw==", new DateTime(2025, 3, 5, 16, 39, 0, 196, DateTimeKind.Local).AddTicks(2866), "ea54b7d0-05c7-48fe-815e-dda8c88e9640" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisterAt", "SecurityStamp" },
                values: new object[] { "d83dc7aa-c5e0-4362-bff6-8fe3defb31aa", "AQAAAAIAAYagAAAAEMlFaGSs8EnkOoxDEG7J55ImqodavL3JkTmxFw7jxYvcTaxy3Zgd/9qZ8cuCScy8yw==", new DateTime(2025, 3, 5, 16, 39, 0, 196, DateTimeKind.Local).AddTicks(2884), "6fb43307-1060-4bc9-adcf-c829b90c8e57" });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2025, 3, 5, 16, 39, 0, 193, DateTimeKind.Local).AddTicks(4565));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateAt",
                value: new DateTime(2025, 3, 5, 16, 39, 0, 193, DateTimeKind.Local).AddTicks(4596));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateAt",
                value: new DateTime(2025, 3, 5, 16, 39, 0, 193, DateTimeKind.Local).AddTicks(4601));
        }
    }
}
