using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.Infrastructure.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class five : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Expert_ExpertId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_ExpertId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ExpertId",
                table: "Orders");

            migrationBuilder.AddColumn<bool>(
                name: "IsPayment",
                table: "Orders",
                type: "bit",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisterAt", "SecurityStamp" },
                values: new object[] { "3da122ce-5046-4d80-8a20-d8277e85210e", "AQAAAAIAAYagAAAAEEKZCEGlbdpb42cREmtMWeLz36u7cNDjOzLp6cNhEaBuCHmwVE9KaC7ZUo8YQKJDPw==", new DateTime(2025, 3, 6, 14, 7, 30, 875, DateTimeKind.Local).AddTicks(4301), "e693e5c5-c216-4e43-994f-4b6c0f55478d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisterAt", "SecurityStamp" },
                values: new object[] { "38e40d5e-ed88-4fe2-b4b9-7dd68ee58b2a", "AQAAAAIAAYagAAAAEL9K+RbIEGYfU5UAs7G2Cq8c/kAQa+3L4102UW50B9HF1jJGrA8uXI92wWnnzIyzig==", new DateTime(2025, 3, 6, 14, 7, 30, 875, DateTimeKind.Local).AddTicks(4373), "98e20bf0-0c5f-4808-80b1-0fb04c4b49cf" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisterAt", "SecurityStamp" },
                values: new object[] { "85991bce-1ac5-4221-a4e1-9fbf9dfd347f", "AQAAAAIAAYagAAAAEFrFJuRkQnNUn2bg5jn1vvZM53E1bKs3Ulrg2R2WAIwJQi1oo3iqMJzSxSP2EruALA==", new DateTime(2025, 3, 6, 14, 7, 30, 875, DateTimeKind.Local).AddTicks(4387), "804e51d1-b529-457d-aeb0-1da13312915a" });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2025, 3, 6, 14, 7, 30, 873, DateTimeKind.Local).AddTicks(8287));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateAt",
                value: new DateTime(2025, 3, 6, 14, 7, 30, 873, DateTimeKind.Local).AddTicks(8296));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateAt",
                value: new DateTime(2025, 3, 6, 14, 7, 30, 873, DateTimeKind.Local).AddTicks(8298));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateAt", "IsPayment" },
                values: new object[] { new DateTime(2025, 3, 6, 14, 7, 30, 873, DateTimeKind.Local).AddTicks(3998), false });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreateAt", "IsPayment" },
                values: new object[] { new DateTime(2025, 3, 6, 14, 7, 30, 873, DateTimeKind.Local).AddTicks(4023), false });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreateAt", "IsPayment" },
                values: new object[] { new DateTime(2025, 3, 6, 14, 7, 30, 873, DateTimeKind.Local).AddTicks(4027), false });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsPayment",
                table: "Orders");

            migrationBuilder.AddColumn<int>(
                name: "ExpertId",
                table: "Orders",
                type: "int",
                nullable: true);

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
                columns: new[] { "CreateAt", "ExpertId" },
                values: new object[] { new DateTime(2025, 3, 6, 8, 19, 44, 12, DateTimeKind.Local).AddTicks(6368), null });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreateAt", "ExpertId" },
                values: new object[] { new DateTime(2025, 3, 6, 8, 19, 44, 12, DateTimeKind.Local).AddTicks(6393), null });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreateAt", "ExpertId" },
                values: new object[] { new DateTime(2025, 3, 6, 8, 19, 44, 12, DateTimeKind.Local).AddTicks(6396), null });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ExpertId",
                table: "Orders",
                column: "ExpertId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Expert_ExpertId",
                table: "Orders",
                column: "ExpertId",
                principalTable: "Expert",
                principalColumn: "Id");
        }
    }
}
