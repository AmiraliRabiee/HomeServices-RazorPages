using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.Infrastructure.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class three : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisterAt", "SecurityStamp" },
                values: new object[] { "1591090f-9430-449d-84e3-3bce4e39d85e", "AQAAAAIAAYagAAAAEHfurX2dGoWcF9vzU0QsV41zcLsbVRXWJxCCY5uI4GUJE/Rnsfcbx4/JeRcPZGDbww==", new DateTime(2025, 3, 5, 19, 51, 30, 667, DateTimeKind.Local).AddTicks(71), "c2de49d3-285f-4d57-884b-806022251dea" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisterAt", "SecurityStamp" },
                values: new object[] { "45b09c61-cf52-4f69-8480-081d7edb6865", "AQAAAAIAAYagAAAAELn1O2Ruf83IatQF+0PC5wUkb1g1ZqVDV+oFk3ZSQD/DJgmvSb3wY6XJ3wuvtMKP3Q==", new DateTime(2025, 3, 5, 19, 51, 30, 667, DateTimeKind.Local).AddTicks(92), "b967bdf0-a538-4a4f-97f3-08b49540c553" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisterAt", "SecurityStamp" },
                values: new object[] { "f0725eee-9804-4d20-ae55-591cc87ca548", "AQAAAAIAAYagAAAAEKqU16Kqt3SLxfbT1SwcRF3l64nAEuhhHPu9Txhc1G2mbgxo50V/SnYjKHQJZVWBQQ==", new DateTime(2025, 3, 5, 19, 51, 30, 667, DateTimeKind.Local).AddTicks(105), "dc99728f-cb57-49c0-a51d-2892da289109" });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2025, 3, 5, 19, 51, 30, 665, DateTimeKind.Local).AddTicks(4268));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateAt",
                value: new DateTime(2025, 3, 5, 19, 51, 30, 665, DateTimeKind.Local).AddTicks(4274));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateAt",
                value: new DateTime(2025, 3, 5, 19, 51, 30, 665, DateTimeKind.Local).AddTicks(4276));

            migrationBuilder.UpdateData(
                table: "HouseWorks",
                keyColumn: "Id",
                keyValue: 34,
                column: "ImagePath",
                value: "\\Images\\HomeServices\\34h.jpg");

            migrationBuilder.UpdateData(
                table: "HouseWorks",
                keyColumn: "Id",
                keyValue: 35,
                column: "ImagePath",
                value: "\\Images\\HomeServices\\35h.jpg");

            migrationBuilder.UpdateData(
                table: "HouseWorks",
                keyColumn: "Id",
                keyValue: 36,
                column: "ImagePath",
                value: "\\Images\\HomeServices\\36h.jpg");

            migrationBuilder.UpdateData(
                table: "HouseWorks",
                keyColumn: "Id",
                keyValue: 37,
                column: "ImagePath",
                value: "\\Images\\HomeServices\\37h.jpg");

            migrationBuilder.UpdateData(
                table: "HouseWorks",
                keyColumn: "Id",
                keyValue: 38,
                column: "ImagePath",
                value: "\\Images\\HomeServices\\38h.jpg");

            migrationBuilder.UpdateData(
                table: "HouseWorks",
                keyColumn: "Id",
                keyValue: 39,
                column: "ImagePath",
                value: "\\Images\\HomeServices\\39h.jpg");

            migrationBuilder.UpdateData(
                table: "HouseWorks",
                keyColumn: "Id",
                keyValue: 40,
                column: "ImagePath",
                value: "\\Images\\HomeServices\\40h.jpg");

            migrationBuilder.UpdateData(
                table: "HouseWorks",
                keyColumn: "Id",
                keyValue: 41,
                column: "ImagePath",
                value: "\\Images\\HomeServices\\41h.jpg");

            migrationBuilder.UpdateData(
                table: "HouseWorks",
                keyColumn: "Id",
                keyValue: 42,
                column: "ImagePath",
                value: "\\Images\\HomeServices\\42h.jpg");

            migrationBuilder.UpdateData(
                table: "HouseWorks",
                keyColumn: "Id",
                keyValue: 43,
                column: "ImagePath",
                value: "\\Images\\HomeServices\\43h.jpg");

            migrationBuilder.UpdateData(
                table: "HouseWorks",
                keyColumn: "Id",
                keyValue: 44,
                column: "ImagePath",
                value: "\\Images\\HomeServices\\44h.jpg");

            migrationBuilder.UpdateData(
                table: "HouseWorks",
                keyColumn: "Id",
                keyValue: 45,
                column: "ImagePath",
                value: "\\Images\\HomeServices\\45h.jpg");

            migrationBuilder.UpdateData(
                table: "HouseWorks",
                keyColumn: "Id",
                keyValue: 46,
                column: "ImagePath",
                value: "\\Images\\HomeServices\\46h.jpg");

            migrationBuilder.UpdateData(
                table: "HouseWorks",
                keyColumn: "Id",
                keyValue: 47,
                column: "ImagePath",
                value: "\\Images\\HomeServices\\47h.jpg");

            migrationBuilder.UpdateData(
                table: "HouseWorks",
                keyColumn: "Id",
                keyValue: 48,
                column: "ImagePath",
                value: "\\Images\\HomeServices\\48h.jpg");

            migrationBuilder.UpdateData(
                table: "HouseWorks",
                keyColumn: "Id",
                keyValue: 49,
                column: "ImagePath",
                value: "\\Images\\HomeServices\\49h.jpg");

            migrationBuilder.UpdateData(
                table: "HouseWorks",
                keyColumn: "Id",
                keyValue: 50,
                column: "ImagePath",
                value: "\\Images\\HomeServices\\50h.jpg");

            migrationBuilder.UpdateData(
                table: "HouseWorks",
                keyColumn: "Id",
                keyValue: 51,
                column: "ImagePath",
                value: "\\Images\\HomeServices\\51h.jpg");

            migrationBuilder.UpdateData(
                table: "HouseWorks",
                keyColumn: "Id",
                keyValue: 52,
                column: "ImagePath",
                value: "\\Images\\HomeServices\\52h.jpg");

            migrationBuilder.UpdateData(
                table: "HouseWorks",
                keyColumn: "Id",
                keyValue: 53,
                column: "ImagePath",
                value: "\\Images\\HomeServices\\53h.jpg");

            migrationBuilder.UpdateData(
                table: "HouseWorks",
                keyColumn: "Id",
                keyValue: 54,
                column: "ImagePath",
                value: "\\Images\\HomeServices\\54h.jpg");

            migrationBuilder.UpdateData(
                table: "HouseWorks",
                keyColumn: "Id",
                keyValue: 55,
                column: "ImagePath",
                value: "\\Images\\HomeServices\\55h.jpg");

            migrationBuilder.UpdateData(
                table: "HouseWorks",
                keyColumn: "Id",
                keyValue: 56,
                column: "ImagePath",
                value: "\\Images\\HomeServices\\56h.jpg");

            migrationBuilder.UpdateData(
                table: "HouseWorks",
                keyColumn: "Id",
                keyValue: 57,
                column: "ImagePath",
                value: "\\Images\\HomeServices\\57h.jpg");

            migrationBuilder.UpdateData(
                table: "HouseWorks",
                keyColumn: "Id",
                keyValue: 58,
                column: "ImagePath",
                value: "\\Images\\HomeServices\\58h.jpg");

            migrationBuilder.UpdateData(
                table: "HouseWorks",
                keyColumn: "Id",
                keyValue: 59,
                column: "ImagePath",
                value: "\\Images\\HomeServices\\59h (2).jpg");

            migrationBuilder.UpdateData(
                table: "HouseWorks",
                keyColumn: "Id",
                keyValue: 60,
                column: "ImagePath",
                value: "\\Images\\HomeServices\\60h.jpg");

            migrationBuilder.UpdateData(
                table: "HouseWorks",
                keyColumn: "Id",
                keyValue: 61,
                column: "ImagePath",
                value: "\\Images\\HomeServices\\61h.jpg");

            migrationBuilder.UpdateData(
                table: "HouseWorks",
                keyColumn: "Id",
                keyValue: 62,
                column: "ImagePath",
                value: "\\Images\\HomeServices\\62h.jpg");

            migrationBuilder.UpdateData(
                table: "HouseWorks",
                keyColumn: "Id",
                keyValue: 63,
                column: "ImagePath",
                value: "\\Images\\HomeServices\\63h.jpg");

            migrationBuilder.UpdateData(
                table: "HouseWorks",
                keyColumn: "Id",
                keyValue: 64,
                column: "ImagePath",
                value: "\\Images\\HomeServices\\64h.jpg");

            migrationBuilder.UpdateData(
                table: "HouseWorks",
                keyColumn: "Id",
                keyValue: 65,
                column: "ImagePath",
                value: "\\Images\\HomeServices\\65h.jpg");

            migrationBuilder.UpdateData(
                table: "HouseWorks",
                keyColumn: "Id",
                keyValue: 66,
                column: "ImagePath",
                value: "");

            migrationBuilder.UpdateData(
                table: "HouseWorks",
                keyColumn: "Id",
                keyValue: 67,
                column: "ImagePath",
                value: "");

            migrationBuilder.UpdateData(
                table: "HouseWorks",
                keyColumn: "Id",
                keyValue: 68,
                column: "ImagePath",
                value: "");

            migrationBuilder.UpdateData(
                table: "HouseWorks",
                keyColumn: "Id",
                keyValue: 69,
                column: "ImagePath",
                value: "");

            migrationBuilder.UpdateData(
                table: "HouseWorks",
                keyColumn: "Id",
                keyValue: 70,
                column: "ImagePath",
                value: "");

            migrationBuilder.UpdateData(
                table: "HouseWorks",
                keyColumn: "Id",
                keyValue: 71,
                column: "ImagePath",
                value: "");

            migrationBuilder.UpdateData(
                table: "HouseWorks",
                keyColumn: "Id",
                keyValue: 72,
                column: "ImagePath",
                value: "");

            migrationBuilder.UpdateData(
                table: "HouseWorks",
                keyColumn: "Id",
                keyValue: 73,
                column: "ImagePath",
                value: "");

            migrationBuilder.UpdateData(
                table: "HouseWorks",
                keyColumn: "Id",
                keyValue: 74,
                column: "ImagePath",
                value: "");

            migrationBuilder.UpdateData(
                table: "HouseWorks",
                keyColumn: "Id",
                keyValue: 75,
                column: "ImagePath",
                value: "");

            migrationBuilder.UpdateData(
                table: "HouseWorks",
                keyColumn: "Id",
                keyValue: 76,
                column: "ImagePath",
                value: "");

            migrationBuilder.UpdateData(
                table: "HouseWorks",
                keyColumn: "Id",
                keyValue: 77,
                column: "ImagePath",
                value: "");

            migrationBuilder.UpdateData(
                table: "HouseWorks",
                keyColumn: "Id",
                keyValue: 78,
                column: "ImagePath",
                value: "");

            migrationBuilder.UpdateData(
                table: "HouseWorks",
                keyColumn: "Id",
                keyValue: 79,
                column: "ImagePath",
                value: "");

            migrationBuilder.UpdateData(
                table: "HouseWorks",
                keyColumn: "Id",
                keyValue: 80,
                column: "ImagePath",
                value: "");

            migrationBuilder.UpdateData(
                table: "HouseWorks",
                keyColumn: "Id",
                keyValue: 81,
                column: "ImagePath",
                value: "");

            migrationBuilder.UpdateData(
                table: "HouseWorks",
                keyColumn: "Id",
                keyValue: 82,
                column: "ImagePath",
                value: "");

            migrationBuilder.UpdateData(
                table: "HouseWorks",
                keyColumn: "Id",
                keyValue: 83,
                column: "ImagePath",
                value: "");

            migrationBuilder.UpdateData(
                table: "HouseWorks",
                keyColumn: "Id",
                keyValue: 84,
                column: "ImagePath",
                value: "");

            migrationBuilder.UpdateData(
                table: "HouseWorks",
                keyColumn: "Id",
                keyValue: 85,
                column: "ImagePath",
                value: "");

            migrationBuilder.UpdateData(
                table: "HouseWorks",
                keyColumn: "Id",
                keyValue: 86,
                column: "ImagePath",
                value: "");

            migrationBuilder.UpdateData(
                table: "HouseWorks",
                keyColumn: "Id",
                keyValue: 87,
                column: "ImagePath",
                value: "");

            migrationBuilder.UpdateData(
                table: "HouseWorks",
                keyColumn: "Id",
                keyValue: 88,
                column: "ImagePath",
                value: "");

            migrationBuilder.UpdateData(
                table: "HouseWorks",
                keyColumn: "Id",
                keyValue: 89,
                column: "ImagePath",
                value: "");

            migrationBuilder.UpdateData(
                table: "HouseWorks",
                keyColumn: "Id",
                keyValue: 90,
                column: "ImagePath",
                value: "");

            migrationBuilder.UpdateData(
                table: "HouseWorks",
                keyColumn: "Id",
                keyValue: 91,
                column: "ImagePath",
                value: "");

            migrationBuilder.UpdateData(
                table: "HouseWorks",
                keyColumn: "Id",
                keyValue: 92,
                column: "ImagePath",
                value: "");

            migrationBuilder.UpdateData(
                table: "HouseWorks",
                keyColumn: "Id",
                keyValue: 93,
                column: "ImagePath",
                value: "");

            migrationBuilder.UpdateData(
                table: "HouseWorks",
                keyColumn: "Id",
                keyValue: 94,
                column: "ImagePath",
                value: "");

            migrationBuilder.UpdateData(
                table: "HouseWorks",
                keyColumn: "Id",
                keyValue: 95,
                column: "ImagePath",
                value: "");

            migrationBuilder.UpdateData(
                table: "HouseWorks",
                keyColumn: "Id",
                keyValue: 96,
                column: "ImagePath",
                value: "");

            migrationBuilder.UpdateData(
                table: "HouseWorks",
                keyColumn: "Id",
                keyValue: 97,
                column: "ImagePath",
                value: "");

            migrationBuilder.UpdateData(
                table: "HouseWorks",
                keyColumn: "Id",
                keyValue: 98,
                column: "ImagePath",
                value: "");

            migrationBuilder.UpdateData(
                table: "HouseWorks",
                keyColumn: "Id",
                keyValue: 99,
                column: "ImagePath",
                value: "");

            migrationBuilder.UpdateData(
                table: "HouseWorks",
                keyColumn: "Id",
                keyValue: 100,
                column: "ImagePath",
                value: "");

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2025, 3, 5, 19, 51, 30, 665, DateTimeKind.Local).AddTicks(635));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateAt",
                value: new DateTime(2025, 3, 5, 19, 51, 30, 665, DateTimeKind.Local).AddTicks(657));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateAt",
                value: new DateTime(2025, 3, 5, 19, 51, 30, 665, DateTimeKind.Local).AddTicks(660));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2025, 3, 5, 16, 41, 54, 449, DateTimeKind.Local).AddTicks(8789));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateAt",
                value: new DateTime(2025, 3, 5, 16, 41, 54, 449, DateTimeKind.Local).AddTicks(8798));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateAt",
                value: new DateTime(2025, 3, 5, 16, 41, 54, 449, DateTimeKind.Local).AddTicks(8800));

            migrationBuilder.UpdateData(
                table: "HouseWorks",
                keyColumn: "Id",
                keyValue: 34,
                column: "ImagePath",
                value: "");

            migrationBuilder.UpdateData(
                table: "HouseWorks",
                keyColumn: "Id",
                keyValue: 35,
                column: "ImagePath",
                value: "");

            migrationBuilder.UpdateData(
                table: "HouseWorks",
                keyColumn: "Id",
                keyValue: 36,
                column: "ImagePath",
                value: "");

            migrationBuilder.UpdateData(
                table: "HouseWorks",
                keyColumn: "Id",
                keyValue: 37,
                column: "ImagePath",
                value: "");

            migrationBuilder.UpdateData(
                table: "HouseWorks",
                keyColumn: "Id",
                keyValue: 38,
                column: "ImagePath",
                value: "");

            migrationBuilder.UpdateData(
                table: "HouseWorks",
                keyColumn: "Id",
                keyValue: 39,
                column: "ImagePath",
                value: "");

            migrationBuilder.UpdateData(
                table: "HouseWorks",
                keyColumn: "Id",
                keyValue: 40,
                column: "ImagePath",
                value: "");

            migrationBuilder.UpdateData(
                table: "HouseWorks",
                keyColumn: "Id",
                keyValue: 41,
                column: "ImagePath",
                value: "");

            migrationBuilder.UpdateData(
                table: "HouseWorks",
                keyColumn: "Id",
                keyValue: 42,
                column: "ImagePath",
                value: "");

            migrationBuilder.UpdateData(
                table: "HouseWorks",
                keyColumn: "Id",
                keyValue: 43,
                column: "ImagePath",
                value: null);

            migrationBuilder.UpdateData(
                table: "HouseWorks",
                keyColumn: "Id",
                keyValue: 44,
                column: "ImagePath",
                value: null);

            migrationBuilder.UpdateData(
                table: "HouseWorks",
                keyColumn: "Id",
                keyValue: 45,
                column: "ImagePath",
                value: null);

            migrationBuilder.UpdateData(
                table: "HouseWorks",
                keyColumn: "Id",
                keyValue: 46,
                column: "ImagePath",
                value: null);

            migrationBuilder.UpdateData(
                table: "HouseWorks",
                keyColumn: "Id",
                keyValue: 47,
                column: "ImagePath",
                value: null);

            migrationBuilder.UpdateData(
                table: "HouseWorks",
                keyColumn: "Id",
                keyValue: 48,
                column: "ImagePath",
                value: null);

            migrationBuilder.UpdateData(
                table: "HouseWorks",
                keyColumn: "Id",
                keyValue: 49,
                column: "ImagePath",
                value: null);

            migrationBuilder.UpdateData(
                table: "HouseWorks",
                keyColumn: "Id",
                keyValue: 50,
                column: "ImagePath",
                value: null);

            migrationBuilder.UpdateData(
                table: "HouseWorks",
                keyColumn: "Id",
                keyValue: 51,
                column: "ImagePath",
                value: null);

            migrationBuilder.UpdateData(
                table: "HouseWorks",
                keyColumn: "Id",
                keyValue: 52,
                column: "ImagePath",
                value: null);

            migrationBuilder.UpdateData(
                table: "HouseWorks",
                keyColumn: "Id",
                keyValue: 53,
                column: "ImagePath",
                value: null);

            migrationBuilder.UpdateData(
                table: "HouseWorks",
                keyColumn: "Id",
                keyValue: 54,
                column: "ImagePath",
                value: null);

            migrationBuilder.UpdateData(
                table: "HouseWorks",
                keyColumn: "Id",
                keyValue: 55,
                column: "ImagePath",
                value: null);

            migrationBuilder.UpdateData(
                table: "HouseWorks",
                keyColumn: "Id",
                keyValue: 56,
                column: "ImagePath",
                value: null);

            migrationBuilder.UpdateData(
                table: "HouseWorks",
                keyColumn: "Id",
                keyValue: 57,
                column: "ImagePath",
                value: null);

            migrationBuilder.UpdateData(
                table: "HouseWorks",
                keyColumn: "Id",
                keyValue: 58,
                column: "ImagePath",
                value: null);

            migrationBuilder.UpdateData(
                table: "HouseWorks",
                keyColumn: "Id",
                keyValue: 59,
                column: "ImagePath",
                value: null);

            migrationBuilder.UpdateData(
                table: "HouseWorks",
                keyColumn: "Id",
                keyValue: 60,
                column: "ImagePath",
                value: null);

            migrationBuilder.UpdateData(
                table: "HouseWorks",
                keyColumn: "Id",
                keyValue: 61,
                column: "ImagePath",
                value: null);

            migrationBuilder.UpdateData(
                table: "HouseWorks",
                keyColumn: "Id",
                keyValue: 62,
                column: "ImagePath",
                value: null);

            migrationBuilder.UpdateData(
                table: "HouseWorks",
                keyColumn: "Id",
                keyValue: 63,
                column: "ImagePath",
                value: null);

            migrationBuilder.UpdateData(
                table: "HouseWorks",
                keyColumn: "Id",
                keyValue: 64,
                column: "ImagePath",
                value: null);

            migrationBuilder.UpdateData(
                table: "HouseWorks",
                keyColumn: "Id",
                keyValue: 65,
                column: "ImagePath",
                value: null);

            migrationBuilder.UpdateData(
                table: "HouseWorks",
                keyColumn: "Id",
                keyValue: 66,
                column: "ImagePath",
                value: null);

            migrationBuilder.UpdateData(
                table: "HouseWorks",
                keyColumn: "Id",
                keyValue: 67,
                column: "ImagePath",
                value: null);

            migrationBuilder.UpdateData(
                table: "HouseWorks",
                keyColumn: "Id",
                keyValue: 68,
                column: "ImagePath",
                value: null);

            migrationBuilder.UpdateData(
                table: "HouseWorks",
                keyColumn: "Id",
                keyValue: 69,
                column: "ImagePath",
                value: null);

            migrationBuilder.UpdateData(
                table: "HouseWorks",
                keyColumn: "Id",
                keyValue: 70,
                column: "ImagePath",
                value: null);

            migrationBuilder.UpdateData(
                table: "HouseWorks",
                keyColumn: "Id",
                keyValue: 71,
                column: "ImagePath",
                value: null);

            migrationBuilder.UpdateData(
                table: "HouseWorks",
                keyColumn: "Id",
                keyValue: 72,
                column: "ImagePath",
                value: null);

            migrationBuilder.UpdateData(
                table: "HouseWorks",
                keyColumn: "Id",
                keyValue: 73,
                column: "ImagePath",
                value: null);

            migrationBuilder.UpdateData(
                table: "HouseWorks",
                keyColumn: "Id",
                keyValue: 74,
                column: "ImagePath",
                value: null);

            migrationBuilder.UpdateData(
                table: "HouseWorks",
                keyColumn: "Id",
                keyValue: 75,
                column: "ImagePath",
                value: null);

            migrationBuilder.UpdateData(
                table: "HouseWorks",
                keyColumn: "Id",
                keyValue: 76,
                column: "ImagePath",
                value: null);

            migrationBuilder.UpdateData(
                table: "HouseWorks",
                keyColumn: "Id",
                keyValue: 77,
                column: "ImagePath",
                value: null);

            migrationBuilder.UpdateData(
                table: "HouseWorks",
                keyColumn: "Id",
                keyValue: 78,
                column: "ImagePath",
                value: null);

            migrationBuilder.UpdateData(
                table: "HouseWorks",
                keyColumn: "Id",
                keyValue: 79,
                column: "ImagePath",
                value: null);

            migrationBuilder.UpdateData(
                table: "HouseWorks",
                keyColumn: "Id",
                keyValue: 80,
                column: "ImagePath",
                value: null);

            migrationBuilder.UpdateData(
                table: "HouseWorks",
                keyColumn: "Id",
                keyValue: 81,
                column: "ImagePath",
                value: null);

            migrationBuilder.UpdateData(
                table: "HouseWorks",
                keyColumn: "Id",
                keyValue: 82,
                column: "ImagePath",
                value: null);

            migrationBuilder.UpdateData(
                table: "HouseWorks",
                keyColumn: "Id",
                keyValue: 83,
                column: "ImagePath",
                value: null);

            migrationBuilder.UpdateData(
                table: "HouseWorks",
                keyColumn: "Id",
                keyValue: 84,
                column: "ImagePath",
                value: null);

            migrationBuilder.UpdateData(
                table: "HouseWorks",
                keyColumn: "Id",
                keyValue: 85,
                column: "ImagePath",
                value: null);

            migrationBuilder.UpdateData(
                table: "HouseWorks",
                keyColumn: "Id",
                keyValue: 86,
                column: "ImagePath",
                value: null);

            migrationBuilder.UpdateData(
                table: "HouseWorks",
                keyColumn: "Id",
                keyValue: 87,
                column: "ImagePath",
                value: null);

            migrationBuilder.UpdateData(
                table: "HouseWorks",
                keyColumn: "Id",
                keyValue: 88,
                column: "ImagePath",
                value: null);

            migrationBuilder.UpdateData(
                table: "HouseWorks",
                keyColumn: "Id",
                keyValue: 89,
                column: "ImagePath",
                value: null);

            migrationBuilder.UpdateData(
                table: "HouseWorks",
                keyColumn: "Id",
                keyValue: 90,
                column: "ImagePath",
                value: null);

            migrationBuilder.UpdateData(
                table: "HouseWorks",
                keyColumn: "Id",
                keyValue: 91,
                column: "ImagePath",
                value: null);

            migrationBuilder.UpdateData(
                table: "HouseWorks",
                keyColumn: "Id",
                keyValue: 92,
                column: "ImagePath",
                value: null);

            migrationBuilder.UpdateData(
                table: "HouseWorks",
                keyColumn: "Id",
                keyValue: 93,
                column: "ImagePath",
                value: null);

            migrationBuilder.UpdateData(
                table: "HouseWorks",
                keyColumn: "Id",
                keyValue: 94,
                column: "ImagePath",
                value: null);

            migrationBuilder.UpdateData(
                table: "HouseWorks",
                keyColumn: "Id",
                keyValue: 95,
                column: "ImagePath",
                value: null);

            migrationBuilder.UpdateData(
                table: "HouseWorks",
                keyColumn: "Id",
                keyValue: 96,
                column: "ImagePath",
                value: null);

            migrationBuilder.UpdateData(
                table: "HouseWorks",
                keyColumn: "Id",
                keyValue: 97,
                column: "ImagePath",
                value: null);

            migrationBuilder.UpdateData(
                table: "HouseWorks",
                keyColumn: "Id",
                keyValue: 98,
                column: "ImagePath",
                value: null);

            migrationBuilder.UpdateData(
                table: "HouseWorks",
                keyColumn: "Id",
                keyValue: 99,
                column: "ImagePath",
                value: null);

            migrationBuilder.UpdateData(
                table: "HouseWorks",
                keyColumn: "Id",
                keyValue: 100,
                column: "ImagePath",
                value: null);

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
    }
}
