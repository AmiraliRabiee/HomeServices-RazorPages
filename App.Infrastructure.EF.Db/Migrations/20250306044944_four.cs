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
            migrationBuilder.AddColumn<bool>(
                name: "IsAccept",
                table: "Suggestions",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisterAt", "SecurityStamp" },
                values: new object[] { "df6adee0-b17d-4d4d-b5d6-9967aeb77380", "AQAAAAIAAYagAAAAELIrJGTo0dzk+G0AzkgRFNUVnOqUIy5QlJxebon/nFEJ5jqkjLgld9ivWABdVAbE+g==", new DateTime(2025, 3, 6, 8, 19, 44, 15, DateTimeKind.Local).AddTicks(2867), "a4081bc6-7e70-4c55-ba10-be3f0602c169" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisterAt", "SecurityStamp" },
                values: new object[] { "0dfaac9f-01cf-4e28-b401-574197ad3874", "AQAAAAIAAYagAAAAEBUMV4fM0sBfIa+4qsr3DRP572zdYzF2beGj8gahV5BxRFg4HsV6UsbCQMLgDOvxhg==", new DateTime(2025, 3, 6, 8, 19, 44, 15, DateTimeKind.Local).AddTicks(2900), "f1f7b0e2-ee85-473e-b20d-4821970ab1c4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisterAt", "SecurityStamp" },
                values: new object[] { "8b080c7e-a30a-4a1d-9630-3cc68dda25d1", "AQAAAAIAAYagAAAAEFIcTmn8t8FX49SQftusoKFZcVS+nVP96Stm3Eef4oF/meAFfKpOWd+2fUFtCyMnPw==", new DateTime(2025, 3, 6, 8, 19, 44, 15, DateTimeKind.Local).AddTicks(2914), "54b5416a-7885-4dd9-bf56-4e56d8415cdf" });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2025, 3, 6, 8, 19, 44, 13, DateTimeKind.Local).AddTicks(2354));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateAt",
                value: new DateTime(2025, 3, 6, 8, 19, 44, 13, DateTimeKind.Local).AddTicks(2367));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateAt",
                value: new DateTime(2025, 3, 6, 8, 19, 44, 13, DateTimeKind.Local).AddTicks(2370));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2025, 3, 6, 8, 19, 44, 12, DateTimeKind.Local).AddTicks(6368));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateAt",
                value: new DateTime(2025, 3, 6, 8, 19, 44, 12, DateTimeKind.Local).AddTicks(6393));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateAt",
                value: new DateTime(2025, 3, 6, 8, 19, 44, 12, DateTimeKind.Local).AddTicks(6396));

            migrationBuilder.UpdateData(
                table: "Suggestions",
                keyColumn: "Id",
                keyValue: 1,
                column: "IsAccept",
                value: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAccept",
                table: "Suggestions");

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
    }
}
