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
            migrationBuilder.AddColumn<int>(
                name: "Activation",
                table: "Comments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisterAt", "SecurityStamp" },
                values: new object[] { "429a7695-aab3-4c8a-8ca1-01b37858424c", "AQAAAAIAAYagAAAAECgnh1il/HrIiduhWtfwkybZLGg53H+huuVEg8Id3d+eODIp/178e4ikWr63Lcl3Iw==", new DateTime(2025, 4, 10, 1, 25, 24, 73, DateTimeKind.Local).AddTicks(5990), "58595991-43bc-4a64-abeb-1ab82b716e31" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisterAt", "SecurityStamp" },
                values: new object[] { "e2324316-f908-4e11-876d-d3ef0f94bad4", "AQAAAAIAAYagAAAAEDWex0fygKg7uHIzfShXzpye7I5ihL/KGEvHIoflGMxrETWoH71UdU2UY3GcfxU3OQ==", new DateTime(2025, 4, 10, 1, 25, 24, 73, DateTimeKind.Local).AddTicks(6029), "9884ac03-49ae-45ca-954c-3f2410d0e47f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisterAt", "SecurityStamp" },
                values: new object[] { "4f1dc548-fe65-4c1b-afa2-00477465639b", "AQAAAAIAAYagAAAAEG/aos4mIRnk2IVGwP+c35hyCdmNqsddFdb4QST6x5dus+CAPSxwH87FS8ufffTWNw==", new DateTime(2025, 4, 10, 1, 25, 24, 73, DateTimeKind.Local).AddTicks(6045), "bca4fd34-8a93-40ca-b7e4-d47c086fe8c8" });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2025, 4, 10, 1, 25, 24, 71, DateTimeKind.Local).AddTicks(1671));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateAt",
                value: new DateTime(2025, 4, 10, 1, 25, 24, 71, DateTimeKind.Local).AddTicks(1690));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateAt",
                value: new DateTime(2025, 4, 10, 1, 25, 24, 71, DateTimeKind.Local).AddTicks(1694));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Activation",
                table: "Comments");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisterAt", "SecurityStamp" },
                values: new object[] { "723f8ac0-5faa-481d-9731-c1c68a74dfc4", "AQAAAAIAAYagAAAAEJiFNF7ROctZxBcreJmXGkDMZL4rgRSdqfqaoGkMaHYnp0iBo25OQt1gmeAGz5R46w==", new DateTime(2025, 4, 8, 11, 29, 53, 614, DateTimeKind.Local).AddTicks(6938), "669cf128-cb08-43f2-a8a5-64d6b3927dd8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisterAt", "SecurityStamp" },
                values: new object[] { "70a2ec06-a5f4-48ac-8d6a-2805d5f6a8ad", "AQAAAAIAAYagAAAAEDsA04/fkGqvKcN9Qnd5FOqZt+Kc4Edy1WEeKvXBIqsCYPCjXO6YkwJGo4tG/dqUxw==", new DateTime(2025, 4, 8, 11, 29, 53, 614, DateTimeKind.Local).AddTicks(6982), "7b287a6f-a6ff-41a6-91c8-cb77587b65e4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisterAt", "SecurityStamp" },
                values: new object[] { "56ffa6e7-bbdb-43a3-ba1a-b8677e0d6bca", "AQAAAAIAAYagAAAAEBXWsGwIvBhf2LWPOynb5lNAJzD4s92W6jXbWR5kHN+YeYVc/hTYdng3Ehr/30aeIw==", new DateTime(2025, 4, 8, 11, 29, 53, 614, DateTimeKind.Local).AddTicks(7001), "6ce01fda-2d58-48a8-99ff-cd25ef5de818" });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2025, 4, 8, 11, 29, 53, 609, DateTimeKind.Local).AddTicks(5727));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateAt",
                value: new DateTime(2025, 4, 8, 11, 29, 53, 609, DateTimeKind.Local).AddTicks(5759));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateAt",
                value: new DateTime(2025, 4, 8, 11, 29, 53, 609, DateTimeKind.Local).AddTicks(5764));
        }
    }
}
