﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace App.Infrastructure.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    ParentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Categories_Categories_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Categories",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Balance = table.Column<float>(type: "real", nullable: false, defaultValue: 1000f),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    ActivationUser = table.Column<int>(type: "int", nullable: true),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RegisterAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AdminId = table.Column<int>(type: "int", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Admins_AdminId",
                        column: x => x.AdminId,
                        principalTable: "Admins",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HouseWorks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ViewCount = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    BasePrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HouseWorks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HouseWorks_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", maxLength: 255, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    CityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customers_AspNetUsers_Id",
                        column: x => x.Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Customers_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Expert",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Points = table.Column<int>(type: "int", nullable: true),
                    Biographi = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expert", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Expert_AspNetUsers_Id",
                        column: x => x.Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Expert_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Path = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    HouseWorkId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Images_HouseWorks_HouseWorkId",
                        column: x => x.HouseWorkId,
                        principalTable: "HouseWorks",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Opinion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Points = table.Column<int>(type: "int", nullable: true),
                    stausService = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsPlayable = table.Column<bool>(type: "bit", nullable: false),
                    ExpertId = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Comments_Expert_ExpertId",
                        column: x => x.ExpertId,
                        principalTable: "Expert",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ExpertHouseWorks",
                columns: table => new
                {
                    ExpertId = table.Column<int>(type: "int", nullable: false),
                    HouseWorkId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpertHouseWorks", x => new { x.ExpertId, x.HouseWorkId });
                    table.ForeignKey(
                        name: "FK_ExpertHouseWorks_Expert_ExpertId",
                        column: x => x.ExpertId,
                        principalTable: "Expert",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExpertHouseWorks_HouseWorks_HouseWorkId",
                        column: x => x.HouseWorkId,
                        principalTable: "HouseWorks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    CompletionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RunningTime = table.Column<TimeOnly>(type: "time", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    StausService = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsConfrim = table.Column<bool>(type: "bit", nullable: true),
                    IsFinish = table.Column<bool>(type: "bit", nullable: true),
                    HouseWorkId = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    ExpertId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Orders_Expert_ExpertId",
                        column: x => x.ExpertId,
                        principalTable: "Expert",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Orders_HouseWorks_HouseWorkId",
                        column: x => x.HouseWorkId,
                        principalTable: "HouseWorks",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Suggestions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    SuggestPrice = table.Column<float>(type: "real", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    ExpertId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suggestions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Suggestions_Expert_ExpertId",
                        column: x => x.ExpertId,
                        principalTable: "Expert",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Suggestions_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { 1, null, "Admin", "ADMIN" },
                    { 2, null, "Customer", "CUSTOMER" },
                    { 3, null, "Expert", "EXPERT" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ActivationUser", "AdminId", "Balance", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "ImagePath", "IsDeleted", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RegisterAt", "RoleId", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { 1, 0, 3, null, 1000f, "a48a1cca-8905-478f-be05-34d85810f6d7", "Admin@gmail.com", false, "Admin", null, false, "Admin", false, null, "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAIAAYagAAAAEHcmKdUvop4wXHcq1Jy3vD7my+edJ3Wkjp0XZW12zbYCRbbaz2tBA6AHL/9uG1aljA==", null, false, new DateTime(2025, 3, 5, 16, 39, 0, 196, DateTimeKind.Local).AddTicks(2833), 1, "a9f0af26-a4ef-498e-b320-2c487d8c2e2b", false, "Admin@gmail.com" },
                    { 2, 0, 3, null, 1000f, "bad1d0d9-65cb-4d09-bfc7-6255025e0515", "Customer@gmail.com", false, "Amir", null, false, "Amiri", false, null, "CUSTOMER@GMAIL.COM", "CUSTOMER@GMAIL.COM", "AQAAAAIAAYagAAAAECBjHgKNmpUDAO/Gdv0RPW/x/wciK2yWtLohgWmajexQZSZmSY72vBXALw2BL7aAVw==", null, false, new DateTime(2025, 3, 5, 16, 39, 0, 196, DateTimeKind.Local).AddTicks(2866), 2, "ea54b7d0-05c7-48fe-815e-dda8c88e9640", false, "Customer@gmail.com" },
                    { 3, 0, 3, null, 1000f, "d83dc7aa-c5e0-4362-bff6-8fe3defb31aa", "Expert@gmail.com", false, "Amir", null, false, "Amiri", false, null, "EXPERT@GMAIL.COM", "EXPERT@GMAIL.COM", "AQAAAAIAAYagAAAAEMlFaGSs8EnkOoxDEG7J55ImqodavL3JkTmxFw7jxYvcTaxy3Zgd/9qZ8cuCScy8yw==", null, false, new DateTime(2025, 3, 5, 16, 39, 0, 196, DateTimeKind.Local).AddTicks(2884), 3, "6fb43307-1060-4bc9-adcf-c829b90c8e57", false, "Expert@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "ImagePath", "IsDeleted", "ParentId", "Title" },
                values: new object[,]
                {
                    { 1, "\\Images\\Categories\\tasisat1.jpg", false, null, "تاسیسات" },
                    { 3, "\\Images\\Categories\\3 فعلی.jpg", false, null, "نظافت" },
                    { 4, "\\Images\\Categories\\zibaii.jpg", false, null, "زیبایی" },
                    { 5, "\\Images\\Categories\\tamirat.jpg", false, null, "تعمیرات اشیا" },
                    { 6, "\\Images\\Categories\\6 فعلی (2).jpg", false, null, "خودرو" },
                    { 7, "\\Images\\Categories\\7 فعلی.jpg", false, null, "سلامت" }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "تهران" },
                    { 2, "مشهد" },
                    { 3, "اصفهان" },
                    { 4, "شیراز" },
                    { 5, "تبریز" },
                    { 6, "کرج" },
                    { 7, "قم" },
                    { 8, "اهواز" },
                    { 9, "رشت" },
                    { 10, "کرمانشاه" },
                    { 11, "زاهدان" },
                    { 12, "ارومیه" },
                    { 13, "یزد" },
                    { 14, "همدان" },
                    { 15, "قزوین" },
                    { 16, "سنندج" },
                    { 17, "بندرعباس" },
                    { 18, "زنجان" },
                    { 19, "ساری" },
                    { 20, "بوشهر" },
                    { 21, "مازندران" },
                    { 22, "گرگان" },
                    { 23, "کرمان" },
                    { 24, "خرم آباد" },
                    { 25, "سمنان" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 3, 3 }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "ImagePath", "IsDeleted", "ParentId", "Title" },
                values: new object[,]
                {
                    { 8, "\\Images\\Categories\\8 فعلی.png", false, 1, "برقکاری" },
                    { 9, "\\Images\\Categories\\9 فعلی.png", false, 1, "لوله کشی" },
                    { 10, "\\Images\\Categories\\10 فعلی.png", false, 1, "سرمایش و گرمایش" },
                    { 14, "\\Images\\Categories\\916efcce-9fdb-45ac-9d9b-8b821748a1f5-category_image (2).png", false, 3, "نظافت و پذیرایی" },
                    { 15, "\\Images\\Categories\\15فعلی.png", false, 3, "شستشو" },
                    { 16, "\\Images\\Categories\\16 فعلی.png", false, 3, "کارواش و دیتیلینگ" },
                    { 17, "\\Images\\Categories\\17.png", false, 4, "زیبایی بانوان" },
                    { 18, "\\Images\\Categories\\18.png", false, 4, "پیرایش و زیبایی آقایان" },
                    { 19, "\\Images\\Categories\\19.png", false, 4, "تندرستی و ورزش" },
                    { 20, "\\Images\\Categories\\20.png", false, 5, "نصب و تعمیر لوازم خانگی" },
                    { 21, "\\Images\\Categories\\21.png", false, 5, "خدمات کامپیوتری" },
                    { 22, "\\Images\\Categories\\22.png", false, 5, "تعمیرات موبایل" },
                    { 23, "\\Images\\Categories\\23.png", false, 6, "خدمات و تعمیرات خودرو" },
                    { 24, "\\Images\\Categories\\24.png", false, 6, "باربری و جابجایی" },
                    { 25, "\\Images\\Categories\\25.png", false, 7, "پرشکی و پرستاری" },
                    { 26, "\\Images\\Categories\\26.png", false, 7, "حیوانات خانگی" }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Address", "CityId", "IsDeleted" },
                values: new object[] { 1, "اینجا", 1, false });

            migrationBuilder.InsertData(
                table: "Expert",
                columns: new[] { "Id", "Address", "Biographi", "CityId", "IsDeleted", "Points" },
                values: new object[,]
                {
                    { 1, "اینجا", "بیوگرافی", 1, false, null },
                    { 2, "اینجا", "بیوگرافی", 1, false, null }
                });

            migrationBuilder.InsertData(
                table: "HouseWorks",
                columns: new[] { "Id", "BasePrice", "CategoryId", "Description", "ImagePath", "IsDeleted", "Title" },
                values: new object[,]
                {
                    { 1, 5000m, 10, "نیاز به توضیحات تکمیلی مشکل", "\\Images\\HomeServices\\1h.jpg", false, "تعمیر و سرویس پکیج" },
                    { 2, 3000m, 10, "", "\\Images\\HomeServices\\2h.jpg", false, "تعمیر و سرویس آبگرمکن" },
                    { 3, 3500m, 10, "", "\\Images\\HomeServices\\3h.jpg", false, "نصب و تعمیر رادیاتور شوفاژ" },
                    { 4, 4000m, 10, "پرتقاضا", "\\Images\\HomeServices\\4h.jpg", false, "تعمیر و سرویس کولر آبی" },
                    { 5, 2500m, 10, "", "\\Images\\HomeServices\\5h.jpg", false, "تعمیر و نصب کولر گازی" },
                    { 6, 5000m, 9, "نیاز به توضیحات تکمیلی مشکل", "\\Images\\HomeServices\\6h.jpg", false, "نصب و تعمیر شیرآلات" },
                    { 7, 4000m, 9, "", "\\Images\\HomeServices\\7h.jpg", false, "تخلیه چاه و لوله بازکنی" },
                    { 8, 1000m, 9, "", "\\Images\\HomeServices\\8h.jpg", false, "نصب و تعمیر دستگاه تصفیه آب" },
                    { 9, 2000m, 9, "", "\\Images\\HomeServices\\9h.jpg", false, "لوله کشی گاز" },
                    { 10, 4000m, 9, "به صورت تخصصی", "\\Images\\HomeServices\\10h.jpg", false, "اتصال به شبکه فاضلاب شهری" },
                    { 11, 1000m, 8, "به صورت تخصصی", "\\Images\\HomeServices\\11h.png", false, "سیم و کابل کشی" },
                    { 12, 3500m, 8, "", "\\Images\\HomeServices\\12h.jpg", false, "رفع اتصالی" },
                    { 13, 1000m, 8, "", "\\Images\\HomeServices\\13h.jpg", false, "کلید و پریز" },
                    { 14, 3500m, 8, "", "\\Images\\HomeServices\\14h.jpg", false, "نصب و تعویض فیوز" },
                    { 15, 2000m, 8, "", "\\Images\\HomeServices\\15h.jpg", false, "نصب و تعمیر دوربین مداربسته" },
                    { 29, 1000m, 14, "", "\\Images\\HomeServices\\29h.jpg", false, "سرویس عادی نظافت" },
                    { 30, 3500m, 14, "", "\\Images\\HomeServices\\30h.jpg", false, "سرویس لوکس نظافت" },
                    { 31, 2000m, 14, "", "\\Images\\HomeServices\\31h.jpg", false, "پذیرایی" },
                    { 32, 1000m, 14, "", "\\Images\\HomeServices\\32h.jpg", false, "کارگر ساده" },
                    { 33, 3500m, 14, "", "\\Images\\HomeServices\\33h.jpg", false, "نظافت راه پله" },
                    { 34, 1000m, 15, "(فرش ، موکت ، مبل)", "", false, "شستشو در منزل" },
                    { 35, 3500m, 15, "", "", false, "قالیشویی" },
                    { 36, 2000m, 15, "", "", false, "خشکشویی" },
                    { 37, 1000m, 15, "", "", false, "پرده شویی" },
                    { 38, 1000m, 16, "(آب ، نانو)", "", false, "کارواش" },
                    { 39, 3500m, 16, "", "", false, "صفرشویی خودرو" },
                    { 40, 2000m, 16, "جدید", "", false, "سرامیک حودرو" },
                    { 41, 1000m, 16, "", "", false, "واکس و پولیش" },
                    { 42, 3500m, 16, "به صورت تخصصی", "", false, "صافکاری و نقاشی" },
                    { 43, 1000m, 17, "", null, false, "خدمات ناخن" },
                    { 44, 3500m, 17, "", null, false, " رنگ مو در منزل" },
                    { 45, 2000m, 17, "جدید", null, false, "پاکسازی و لایه برداری پوست" },
                    { 46, 1000m, 17, "", null, false, "آرایش صورت در منزل" },
                    { 47, 3500m, 17, "", null, false, "لیفت و لیمنت مژه" },
                    { 48, 1000m, 18, "", null, false, "کوتاهی مو و اصلاح صورت" },
                    { 49, 3500m, 18, "", null, false, "مراقب و زیبایی آقایان" },
                    { 50, 2000m, 18, "", null, false, "گریم داماد" },
                    { 51, 1000m, 19, "به صورت تخصصی", null, false, "برنامه ورزشی و تغذیه" },
                    { 52, 3500m, 19, "", null, false, "کلاس یوگا در خانه" },
                    { 53, 2000m, 19, "", null, false, "کلاس پیلاتس در خانه" },
                    { 54, 1000m, 19, "جدید", null, false, "کلاس سی ایکس در خانه" },
                    { 55, 3500m, 19, "", null, false, "حرکات اصلاحی" },
                    { 56, 1000m, 20, "", null, false, "نصب و تعمیر یخچال فریزر" },
                    { 57, 3500m, 20, "", null, false, " نصب و تعمیر ماشین ظرفشویی" },
                    { 58, 2000m, 20, "", null, false, "نصب و تعمیر ماشین لباسشویی" },
                    { 59, 1000m, 20, "", null, false, "نصب و تعمیر فر" },
                    { 60, 3500m, 20, "", null, false, "نصب و تعمیر هود آشپرخانه" },
                    { 61, 1000m, 20, "", null, false, "نصب و تعمیر اجاق گاز" },
                    { 62, 3500m, 20, "به صورت تخصصی", null, false, " تعمیرات تلویزیون" },
                    { 63, 2000m, 20, "جدید", null, false, "تعمیر چای ساز و قهوه ساز" },
                    { 64, 1000m, 20, "", null, false, "تعمیر جاروبرقی" },
                    { 65, 3500m, 20, "", null, false, "نصب و تعویض فیلتر آب" },
                    { 66, 1000m, 21, "", null, false, "تعمیر کامپیوتر و لپتاپ" },
                    { 67, 3500m, 21, "", null, false, " تعمیر ماشین های اداری" },
                    { 68, 2000m, 21, "", null, false, "پشتیبانی شبکه وسرور" },
                    { 69, 1000m, 21, "به صورت تخصصی", null, false, "طراحی سایت و لوگو" },
                    { 70, 3500m, 21, "", null, false, "مودم و اینترنت" },
                    { 71, 1000m, 22, "", null, false, "خدمات تاچ و ال سی دی" },
                    { 72, 3500m, 22, "", null, false, " خدمات باتری" },
                    { 73, 2000m, 22, "جدید", null, false, "خدمات نرم افزاری" },
                    { 74, 1000m, 22, "", null, false, "خدمات اسپیکر" },
                    { 75, 3500m, 22, "", null, false, "خدمات دوربین" },
                    { 76, 1000m, 23, "زیر قیمت کارخانه", null, false, "تعویض باتری خودرو" },
                    { 77, 3500m, 23, "", null, false, " برق و باتری خودرو" },
                    { 78, 2000m, 23, "", null, false, "مکانیکی خودرو" },
                    { 79, 1000m, 23, "", null, false, "امداد خودرو" },
                    { 80, 3500m, 23, "", null, false, "پنچرگیری" },
                    { 81, 1000m, 23, "", null, false, "کارشناسی خودرو" },
                    { 82, 3500m, 23, "", null, false, "تعویض لاستیک" },
                    { 83, 2000m, 23, "", null, false, "تعویض لنت خودرو" },
                    { 84, 1000m, 23, "", null, false, "سوخت رسانی" },
                    { 85, 3500m, 23, "", null, false, "تعمیر موتور سیکلت" },
                    { 86, 1000m, 24, "", null, false, "اسباب کشی با خاور و کامیون" },
                    { 87, 3500m, 24, "", null, false, " اسباب کشی با وانت و نیسان" },
                    { 88, 2000m, 24, "نیاز به توضیح", null, false, "اسباب کشی و حمل بین شهری" },
                    { 89, 1000m, 24, "", null, false, "کارگر جابجایی" },
                    { 90, 3500m, 24, "", null, false, "حمل نخاله و ضایعات ساختمانی" },
                    { 91, 1000m, 25, "", null, false, "مراقبت و نگهداری" },
                    { 92, 3500m, 25, "", null, false, " پرستاری و تزریقات" },
                    { 93, 2000m, 25, "", null, false, "معاینه پزشکی" },
                    { 94, 1000m, 25, "", null, false, "پیراپزشکی" },
                    { 95, 3500m, 25, "", null, false, "آزمایش و نمونه گیری" },
                    { 96, 1000m, 26, "جدید", null, false, "هتل های حیوانات خانگی" },
                    { 97, 3500m, 26, "", null, false, " خدماتدامپزشکی در محل" },
                    { 98, 2000m, 26, "به صورت تخصصی", null, false, "خدمات تربیتی حیوانات خانگی" },
                    { 99, 1000m, 26, "", null, false, "خدمات شستشو و آرایشی" },
                    { 100, 3500m, 26, "", null, false, "پت شاپ" }
                });

            migrationBuilder.InsertData(
                table: "ExpertHouseWorks",
                columns: new[] { "ExpertId", "HouseWorkId" },
                values: new object[,]
                {
                    { 2, 1 },
                    { 2, 2 }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "CompletionDate", "CreateAt", "CustomerId", "Description", "ExpertId", "HouseWorkId", "IsConfrim", "IsDeleted", "IsFinish", "RunningTime", "StausService" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 2, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 3, 5, 16, 39, 0, 193, DateTimeKind.Local).AddTicks(4565), 1, "فوری", null, 5, false, false, false, new TimeOnly(0, 0, 0).Add(TimeSpan.FromTicks(11)), 1 },
                    { 2, new DateTime(2025, 2, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 3, 5, 16, 39, 0, 193, DateTimeKind.Local).AddTicks(4596), 1, "", null, 6, false, false, false, new TimeOnly(10, 30, 0), 1 },
                    { 3, new DateTime(2025, 2, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 3, 5, 16, 39, 0, 193, DateTimeKind.Local).AddTicks(4601), 1, "فوری", null, 30, false, false, false, new TimeOnly(4, 30, 0), 1 }
                });

            migrationBuilder.InsertData(
                table: "Suggestions",
                columns: new[] { "Id", "Description", "ExpertId", "IsDeleted", "OrderId", "SuggestPrice" },
                values: new object[] { 1, "آمادگی برای انجام کار با قیمت پایین تر", 1, false, 1, 1000f });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_AdminId",
                table: "AspNetUsers",
                column: "AdminId");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_ParentId",
                table: "Categories",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_CustomerId",
                table: "Comments",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ExpertId",
                table: "Comments",
                column: "ExpertId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_CityId",
                table: "Customers",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Expert_CityId",
                table: "Expert",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_ExpertHouseWorks_HouseWorkId",
                table: "ExpertHouseWorks",
                column: "HouseWorkId");

            migrationBuilder.CreateIndex(
                name: "IX_HouseWorks_CategoryId",
                table: "HouseWorks",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Images_HouseWorkId",
                table: "Images",
                column: "HouseWorkId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerId",
                table: "Orders",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ExpertId",
                table: "Orders",
                column: "ExpertId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_HouseWorkId",
                table: "Orders",
                column: "HouseWorkId");

            migrationBuilder.CreateIndex(
                name: "IX_Suggestions_ExpertId",
                table: "Suggestions",
                column: "ExpertId");

            migrationBuilder.CreateIndex(
                name: "IX_Suggestions_OrderId",
                table: "Suggestions",
                column: "OrderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "ExpertHouseWorks");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "Suggestions");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Expert");

            migrationBuilder.DropTable(
                name: "HouseWorks");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Admins");
        }
    }
}
