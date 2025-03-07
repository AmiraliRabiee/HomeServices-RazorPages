using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.Infrastructure.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class six : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "ProfitPercentage",
                table: "Admins",
                type: "real",
                nullable: false,
                defaultValue: 0f);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProfitPercentage",
                table: "Admins");

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
                column: "CreateAt",
                value: new DateTime(2025, 3, 6, 14, 7, 30, 873, DateTimeKind.Local).AddTicks(3998));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateAt",
                value: new DateTime(2025, 3, 6, 14, 7, 30, 873, DateTimeKind.Local).AddTicks(4023));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateAt",
                value: new DateTime(2025, 3, 6, 14, 7, 30, 873, DateTimeKind.Local).AddTicks(4027));
        }
    }
}
