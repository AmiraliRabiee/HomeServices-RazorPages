using System;
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
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Balance = table.Column<float>(type: "real", nullable: false, defaultValue: 1000f),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    ActivationUser = table.Column<int>(type: "int", nullable: true),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RegisterAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Discriminator = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
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
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
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
                    Address = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customers_AspNetUsers_Id",
                        column: x => x.Id,
                        principalTable: "AspNetUsers",
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
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expert", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Expert_AspNetUsers_Id",
                        column: x => x.Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
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
                    BasePrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 10000m),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HouseWorks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HouseWorks_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HouseWorks_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    stausService = table.Column<int>(type: "int", nullable: true),
                    ExpertRating = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    ExpertId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Expert_ExpertId",
                        column: x => x.ExpertId,
                        principalTable: "Expert",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ExpertHouseWork",
                columns: table => new
                {
                    ExpertId = table.Column<int>(type: "int", nullable: false),
                    SkillsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpertHouseWork", x => new { x.ExpertId, x.SkillsId });
                    table.ForeignKey(
                        name: "FK_ExpertHouseWork_Expert_ExpertId",
                        column: x => x.ExpertId,
                        principalTable: "Expert",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExpertHouseWork_HouseWorks_SkillsId",
                        column: x => x.SkillsId,
                        principalTable: "HouseWorks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    CompletionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RunningTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    StausService = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<float>(type: "real", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    HouseWorkId = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    ExpertId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id");
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
                    DeliverDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    HouseWorkId = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    ExpertId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suggestions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Suggestions_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Suggestions_Expert_ExpertId",
                        column: x => x.ExpertId,
                        principalTable: "Expert",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Suggestions_HouseWorks_HouseWorkId",
                        column: x => x.HouseWorkId,
                        principalTable: "HouseWorks",
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
                columns: new[] { "Id", "AccessFailedCount", "ActivationUser", "Balance", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "FirstName", "ImagePath", "IsDeleted", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "Password", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RegisterAt", "RoleId", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { 1, 0, 3, 1000f, "fabbb91b-8010-4e98-9a21-b23e848ab922", "AppUser", null, false, "Admin", null, false, "Admin", false, null, null, null, "123456", "AQAAAAIAAYagAAAAEK4QBzofRMeV5JnM+yI0r9C3G8ZXQrXjMF9AeSukQazNpppBpCYt2oNhZxRrhWGtOA==", null, false, new DateTime(2025, 2, 14, 14, 24, 56, 531, DateTimeKind.Local).AddTicks(5141), 1, "1d5c482e-02c5-4bf6-b7cb-e6b35b945a81", false, "Admin@gmail.com" },
                    { 2, 0, 3, 1000f, "7a85e93f-8963-4f98-ab86-37e54a7dbe58", "AppUser", null, false, "Amir", null, false, "Amiri", false, null, null, null, "456789", "AQAAAAIAAYagAAAAEPpu54YZ7Ez+HqDHrbiHT8TRpBfy5G6iAYFWI6cFKuLUGW1Z/zn0h/cTrCKSAbBk0g==", null, false, new DateTime(2025, 2, 14, 14, 24, 56, 531, DateTimeKind.Local).AddTicks(5190), 2, "e5cf9ce2-f194-4395-8aa5-dbb41c068f95", false, "Customer@gmail.com" },
                    { 3, 0, 3, 1000f, "d453e607-653c-4c62-a458-4e4be18e7aff", "AppUser", null, false, "Amir", null, false, "Amiri", false, null, null, null, "258852", "AQAAAAIAAYagAAAAEH9uKI3vgY4nNKotAG50NtrDYoCg43x9qVCT44EkQBm2DId14MCwsDHtDSHia0zdpw==", null, false, new DateTime(2025, 2, 14, 14, 24, 56, 531, DateTimeKind.Local).AddTicks(5203), 3, "7ed85f6e-ebea-4914-8bbe-5953300c05dd", false, "Expert@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "ImagePath", "ParentId", "Title" },
                values: new object[,]
                {
                    { 1, "", null, "تاسیسات" },
                    { 2, "", null, "خانه" },
                    { 3, "", null, "نظافت" },
                    { 4, "", null, "زیبایی" },
                    { 5, "", null, "تعمیرات اشیا" },
                    { 6, "", null, " خودرو و حمل بار" },
                    { 7, "", null, "سلامت" }
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
                columns: new[] { "Id", "ImagePath", "ParentId", "Title" },
                values: new object[,]
                {
                    { 8, "D:\\photos\\برقکاری کوچک.png", 1, "برقکاری" },
                    { 9, "D:\\photos\\لوله کشی.png", 1, "لوله کشی" },
                    { 10, "D:\\photos\\سرمایش گرمایش.png", 1, "سرمایش و گرمایش" },
                    { 11, "D:\\photos\\تعمیرات ساختمان.png", 2, "تعمیرات ساختمان" },
                    { 12, "D:\\photos\\بازسازی.png", 2, "شیشه کاری" },
                    { 13, "D:\\photos\\باغبانی.png", 2, "باغبانی" },
                    { 14, "", 3, "نظافت و پذیرایی" },
                    { 15, "", 3, "شستشو" },
                    { 16, "", 3, "کارواش و دیتیلینگ" },
                    { 17, "", 4, "زیبایی بانوان" },
                    { 18, "", 4, "پیرایش و زیبایی آقایان" },
                    { 19, "", 4, "تندرستی و ورزش" },
                    { 20, "", 5, "نصب و تعمیر لوازم خانگی" },
                    { 21, "", 5, "خدمات کامپیوتری" },
                    { 22, "", 5, "تعمیرات موبایل" },
                    { 23, "", 6, "خدمات و تعمیرات خودرو" },
                    { 24, "", 6, "باربری و جابجایی" },
                    { 25, "", 7, "پرشکی و پرستاری" },
                    { 26, "", 7, "حیوانات خانگی" }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Address", "IsDeleted" },
                values: new object[] { 1, "اینجا", false });

            migrationBuilder.InsertData(
                table: "Expert",
                columns: new[] { "Id", "Address", "Biographi", "IsDeleted", "Points" },
                values: new object[] { 1, "اینجا", "بیوگرافی", false, null });

            migrationBuilder.InsertData(
                table: "HouseWorks",
                columns: new[] { "Id", "BasePrice", "CategoryId", "CustomerId", "Description", "ImagePath", "IsDeleted", "Title" },
                values: new object[,]
                {
                    { 1, 5000m, 10, null, "نیاز به توضیحات تکمیلی مشکل", null, false, "تعمیر و سرویس پکیج" },
                    { 2, 3000m, 10, null, "", null, false, "تعمیر و سرویس آبگرمکن" },
                    { 3, 3500m, 10, null, "", null, false, "نصب و تعمیر رادیاتور شوفاژ" },
                    { 4, 4000m, 10, null, "پرتقاضا", null, false, "تعمیر و سرویس کولر آبی" },
                    { 5, 2500m, 10, null, "", null, false, "تعمیر و نصب کولر گازی" },
                    { 6, 5000m, 9, null, "نیاز به توضیحات تکمیلی مشکل", null, false, "نصب و تعمیر شیرآلات" },
                    { 7, 4000m, 9, null, "", null, false, "تخلیه چاه و لوله بازکنی" },
                    { 8, 1000m, 9, null, "", null, false, "نصب و تعمیر دستگاه تصفیه آب" },
                    { 9, 2000m, 9, null, "", null, false, "لوله کشی گاز" },
                    { 10, 4000m, 9, null, "به صورت تخصصی", null, false, "اتصال به شبکه فاضلاب شهری" },
                    { 11, 1000m, 8, null, "به صورت تخصصی", null, false, "سیم و کابل کشی" },
                    { 12, 3500m, 8, null, "", null, false, "رفع اتصالی" },
                    { 13, 1000m, 8, null, "", null, false, "کلید و پریز" },
                    { 14, 3500m, 8, null, "", null, false, "نصب و تعویض فیوز" },
                    { 15, 2000m, 8, null, "", null, false, "نصب و تعمیر دوربین مداربسته" },
                    { 16, 1000m, 11, null, "به صورت تخصصی", null, false, "نقاشی ساختمان" },
                    { 17, 3500m, 11, null, "", null, false, "نصب کاغذ دیواری" },
                    { 18, 2000m, 11, null, "", null, false, "ساخت و نصب توری" },
                    { 19, 1000m, 11, null, "", null, false, "بنایی" },
                    { 20, 3500m, 11, null, "به صورت تخصصی", null, false, "کفسابی" },
                    { 21, 1000m, 12, null, "", null, false, "ساخت و نصب درب و پنجره" },
                    { 22, 3500m, 12, null, "", null, false, "شیشه بری و آینه کاری" },
                    { 23, 2000m, 12, null, "جدید", null, false, "هندریل شیشه ای" },
                    { 24, 1000m, 12, null, "", null, false, "پارتیشن شیشه ای" },
                    { 25, 3500m, 12, null, "", null, false, "نصب و تعمیر درب اتوماتیک" },
                    { 26, 1000m, 13, null, "به صورت تخصصی", null, false, " مشاوره گل و گیاه" },
                    { 27, 3500m, 13, null, "", null, false, "تشخیص و کنترل آفت" },
                    { 28, 2000m, 13, null, "", null, false, "رسیگی به فضای سبز" },
                    { 29, 1000m, 14, null, "", null, false, "سرویس عادی نظافت" },
                    { 30, 3500m, 14, null, "", null, false, "سرویس لوکس نظافت" },
                    { 31, 2000m, 14, null, "", null, false, "پذیرایی" },
                    { 32, 1000m, 14, null, "", null, false, "کارگر ساده" },
                    { 33, 3500m, 14, null, "", null, false, "نظافت راه پله" },
                    { 34, 1000m, 15, null, "(فرش ، موکت ، مبل)", null, false, "شستشو در منزل" },
                    { 35, 3500m, 15, null, "", null, false, "قالیشویی" },
                    { 36, 2000m, 15, null, "", null, false, "خشکشویی" },
                    { 37, 1000m, 15, null, "", null, false, "پرده شویی" },
                    { 38, 1000m, 16, null, "(آب ، نانو)", null, false, "کارواش" },
                    { 39, 3500m, 16, null, "", null, false, "صفرشویی خودرو" },
                    { 40, 2000m, 16, null, "جدید", null, false, "سرامیک حودرو" },
                    { 41, 1000m, 16, null, "", null, false, "واکس و پولیش" },
                    { 42, 3500m, 16, null, "به صورت تخصصی", null, false, "صافکاری و نقاشی" },
                    { 43, 1000m, 17, null, "", null, false, "خدمات ناخن" },
                    { 44, 3500m, 17, null, "", null, false, " رنگ مو در منزل" },
                    { 45, 2000m, 17, null, "جدید", null, false, "پاکسازی و لایه برداری پوست" },
                    { 46, 1000m, 17, null, "", null, false, "آرایش صورت در منزل" },
                    { 47, 3500m, 17, null, "", null, false, "لیفت و لیمنت مژه" },
                    { 48, 1000m, 18, null, "", null, false, "کوتاهی مو و اصلاح صورت" },
                    { 49, 3500m, 18, null, "", null, false, "مراقب و زیبایی آقایان" },
                    { 50, 2000m, 18, null, "", null, false, "گریم داماد" },
                    { 51, 1000m, 19, null, "به صورت تخصصی", null, false, "برنامه ورزشی و تغذیه" },
                    { 52, 3500m, 19, null, "", null, false, "کلاس یوگا در خانه" },
                    { 53, 2000m, 19, null, "", null, false, "کلاس پیلاتس در خانه" },
                    { 54, 1000m, 19, null, "جدید", null, false, "کلاس سی ایکس در خانه" },
                    { 55, 3500m, 19, null, "", null, false, "حرکات اصلاحی" },
                    { 56, 1000m, 20, null, "", null, false, "نصب و تعمیر یخچال فریزر" },
                    { 57, 3500m, 20, null, "", null, false, " نصب و تعمیر ماشین ظرفشویی" },
                    { 58, 2000m, 20, null, "", null, false, "نصب و تعمیر ماشین لباسشویی" },
                    { 59, 1000m, 20, null, "", null, false, "نصب و تعمیر فر" },
                    { 60, 3500m, 20, null, "", null, false, "نصب و تعمیر هود آشپرخانه" },
                    { 61, 1000m, 20, null, "", null, false, "نصب و تعمیر اجاق گاز" },
                    { 62, 3500m, 20, null, "به صورت تخصصی", null, false, " تعمیرات تلویزیون" },
                    { 63, 2000m, 20, null, "جدید", null, false, "تعمیر چای ساز و قهوه ساز" },
                    { 64, 1000m, 20, null, "", null, false, "تعمیر جاروبرقی" },
                    { 65, 3500m, 20, null, "", null, false, "نصب و تعویض فیلتر آب" },
                    { 66, 1000m, 21, null, "", null, false, "تعمیر کامپیوتر و لپتاپ" },
                    { 67, 3500m, 21, null, "", null, false, " تعمیر ماشین های اداری" },
                    { 68, 2000m, 21, null, "", null, false, "پشتیبانی شبکه وسرور" },
                    { 69, 1000m, 21, null, "به صورت تخصصی", null, false, "طراحی سایت و لوگو" },
                    { 70, 3500m, 21, null, "", null, false, "مودم و اینترنت" },
                    { 71, 1000m, 22, null, "", null, false, "خدمات تاچ و ال سی دی" },
                    { 72, 3500m, 22, null, "", null, false, " خدمات باتری" },
                    { 73, 2000m, 22, null, "جدید", null, false, "خدمات نرم افزاری" },
                    { 74, 1000m, 22, null, "", null, false, "خدمات اسپیکر" },
                    { 75, 3500m, 22, null, "", null, false, "خدمات دوربین" },
                    { 76, 1000m, 23, null, "زیر قیمت کارخانه", null, false, "تعویض باتری خودرو" },
                    { 77, 3500m, 23, null, "", null, false, " برق و باتری خودرو" },
                    { 78, 2000m, 23, null, "", null, false, "مکانیکی خودرو" },
                    { 79, 1000m, 23, null, "", null, false, "امداد خودرو" },
                    { 80, 3500m, 23, null, "", null, false, "پنچرگیری" },
                    { 81, 1000m, 23, null, "", null, false, "کارشناسی خودرو" },
                    { 82, 3500m, 23, null, "", null, false, "تعویض لاستیک" },
                    { 83, 2000m, 23, null, "", null, false, "تعویض لنت خودرو" },
                    { 84, 1000m, 23, null, "", null, false, "سوخت رسانی" },
                    { 85, 3500m, 23, null, "", null, false, "تعمیر موتور سیکلت" },
                    { 86, 1000m, 24, null, "", null, false, "اسباب کشی با خاور و کامیون" },
                    { 87, 3500m, 24, null, "", null, false, " اسباب کشی با وانت و نیسان" },
                    { 88, 2000m, 24, null, "نیاز به توضیح", null, false, "اسباب کشی و حمل بین شهری" },
                    { 89, 1000m, 24, null, "", null, false, "کارگر جابجایی" },
                    { 90, 3500m, 24, null, "", null, false, "حمل نخاله و ضایعات ساختمانی" },
                    { 91, 1000m, 25, null, "", null, false, "مراقبت و نگهداری" },
                    { 92, 3500m, 25, null, "", null, false, " پرستاری و تزریقات" },
                    { 93, 2000m, 25, null, "", null, false, "معاینه پزشکی" },
                    { 94, 1000m, 25, null, "", null, false, "پیراپزشکی" },
                    { 95, 3500m, 25, null, "", null, false, "آزمایش و نمونه گیری" },
                    { 96, 1000m, 26, null, "جدید", null, false, "هتل های حیوانات خانگی" },
                    { 97, 3500m, 26, null, "", null, false, " خدماتدامپزشکی در محل" },
                    { 98, 2000m, 26, null, "به صورت تخصصی", null, false, "خدمات تربیتی حیوانات خانگی" },
                    { 99, 1000m, 26, null, "", null, false, "خدمات شستشو و آرایشی" },
                    { 100, 3500m, 26, null, "", null, false, "پت شاپ" }
                });

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
                name: "IX_Comments_ExpertId",
                table: "Comments",
                column: "ExpertId");

            migrationBuilder.CreateIndex(
                name: "IX_ExpertHouseWork_SkillsId",
                table: "ExpertHouseWork",
                column: "SkillsId");

            migrationBuilder.CreateIndex(
                name: "IX_HouseWorks_CategoryId",
                table: "HouseWorks",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_HouseWorks_CustomerId",
                table: "HouseWorks",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Images_HouseWorkId",
                table: "Images",
                column: "HouseWorkId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CityId",
                table: "Orders",
                column: "CityId");

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
                name: "IX_Suggestions_CityId",
                table: "Suggestions",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Suggestions_ExpertId",
                table: "Suggestions",
                column: "ExpertId");

            migrationBuilder.CreateIndex(
                name: "IX_Suggestions_HouseWorkId",
                table: "Suggestions",
                column: "HouseWorkId");

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
                name: "ExpertHouseWork");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "Suggestions");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Expert");

            migrationBuilder.DropTable(
                name: "HouseWorks");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
