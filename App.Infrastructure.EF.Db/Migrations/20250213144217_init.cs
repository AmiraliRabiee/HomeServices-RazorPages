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
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Experts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Points = table.Column<int>(type: "int", nullable: true),
                    Biographi = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Experts", x => x.Id);
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
                name: "HomeServices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ViewCount = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    BasePrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 10000m),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: true),
                    CategoryId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HomeServices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HomeServices_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HomeServices_Categories_CategoryId1",
                        column: x => x.CategoryId1,
                        principalTable: "Categories",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HomeServices_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id");
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
                    Address = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Balance = table.Column<float>(type: "real", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    ActivationUser = table.Column<int>(type: "int", nullable: true),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RegisterAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CustomerId = table.Column<int>(type: "int", nullable: true),
                    ExpertId = table.Column<int>(type: "int", nullable: true),
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
                        name: "FK_AspNetUsers_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Experts_ExpertId",
                        column: x => x.ExpertId,
                        principalTable: "Experts",
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
                    ExpertId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Experts_ExpertId",
                        column: x => x.ExpertId,
                        principalTable: "Experts",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ExpertHomeService",
                columns: table => new
                {
                    ExpertId = table.Column<int>(type: "int", nullable: false),
                    SkillsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpertHomeService", x => new { x.ExpertId, x.SkillsId });
                    table.ForeignKey(
                        name: "FK_ExpertHomeService_Experts_ExpertId",
                        column: x => x.ExpertId,
                        principalTable: "Experts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExpertHomeService_HomeServices_SkillsId",
                        column: x => x.SkillsId,
                        principalTable: "HomeServices",
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
                    HomeServiceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Images_HomeServices_HomeServiceId",
                        column: x => x.HomeServiceId,
                        principalTable: "HomeServices",
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
                    HomeServiceId = table.Column<int>(type: "int", nullable: false),
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
                        name: "FK_Orders_Experts_ExpertId",
                        column: x => x.ExpertId,
                        principalTable: "Experts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Orders_HomeServices_HomeServiceId",
                        column: x => x.HomeServiceId,
                        principalTable: "HomeServices",
                        principalColumn: "Id");
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
                name: "Suggestions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    SuggestPrice = table.Column<float>(type: "real", nullable: false),
                    DeliverDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    HomeServiceId = table.Column<int>(type: "int", nullable: false),
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
                        name: "FK_Suggestions_Experts_ExpertId",
                        column: x => x.ExpertId,
                        principalTable: "Experts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Suggestions_HomeServices_HomeServiceId",
                        column: x => x.HomeServiceId,
                        principalTable: "HomeServices",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Suggestions_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                columns: new[] { "Id", "AccessFailedCount", "ActivationUser", "Address", "Balance", "ConcurrencyStamp", "CustomerId", "Email", "EmailConfirmed", "ExpertId", "FirstName", "ImagePath", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "Password", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RegisterAt", "RoleId", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { 1, 0, 3, null, 1000f, "cdc34af2-1f7c-4cfc-b45a-76b72ffffb62", null, null, false, null, "Admin", null, "Admin", false, null, null, null, "123456", "AQAAAAIAAYagAAAAEOnqijCQu5ibRNa0VrCsDiAcB7LAALLs1H66YbzcUsw/d0jWxhIPhPHdF3ltlbg/fw==", null, false, null, 1, "3e65f16d-23f7-4d72-bd78-5e2b526240f5", false, "Admin@gmail.com" },
                    { 2, 0, 3, null, 1000f, "d9dcf52f-1a27-4850-8faa-8fb1b204088d", null, null, false, null, "Amir", null, "Amiri", false, null, null, null, "456789", "AQAAAAIAAYagAAAAEOwY0Q/CTG7wQuLssdGKHTlr2o1uZPndDUX3akwBPcUOJgR3ZzwueQMDHPUyVqjYEg==", null, false, null, 2, "bbae154d-37d5-42d7-8185-f5fb0fb7639b", false, "Customer@gmail.com" },
                    { 3, 0, 3, null, 1000f, "c2ecf634-36f0-4552-8bcc-194309435ed5", null, null, false, null, "Amir", null, "Amiri", false, null, null, null, "258852", "AQAAAAIAAYagAAAAEOYkvyG61qe5plYE9YJbjesSiVyVSO7vKeFHDKdPJ5nyExqX06AMWgh2OvUAvKYF/Q==", null, false, null, 3, "0f888b50-71ff-4250-baec-06e13d3f995c", false, "Expert@gmail.com" }
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
                table: "HomeServices",
                columns: new[] { "Id", "BasePrice", "CategoryId", "CategoryId1", "CustomerId", "Description", "ImagePath", "Title" },
                values: new object[,]
                {
                    { 1, 5000m, 10, null, null, "نیاز به توضیحات تکمیلی مشکل", null, "تعمیر و سرویس پکیج" },
                    { 2, 3000m, 10, null, null, "", null, "تعمیر و سرویس آبگرمکن" },
                    { 3, 3500m, 10, null, null, "", null, "نصب و تعمیر رادیاتور شوفاژ" },
                    { 4, 4000m, 10, null, null, "پرتقاضا", null, "تعمیر و سرویس کولر آبی" },
                    { 5, 2500m, 10, null, null, "", null, "تعمیر و نصب کولر گازی" },
                    { 6, 5000m, 9, null, null, "نیاز به توضیحات تکمیلی مشکل", null, "نصب و تعمیر شیرآلات" },
                    { 7, 4000m, 9, null, null, "", null, "تخلیه چاه و لوله بازکنی" },
                    { 8, 1000m, 9, null, null, "", null, "نصب و تعمیر دستگاه تصفیه آب" },
                    { 9, 2000m, 9, null, null, "", null, "لوله کشی گاز" },
                    { 10, 4000m, 9, null, null, "به صورت تخصصی", null, "اتصال به شبکه فاضلاب شهری" },
                    { 11, 1000m, 8, null, null, "به صورت تخصصی", null, "سیم و کابل کشی" },
                    { 12, 3500m, 8, null, null, "", null, "رفع اتصالی" },
                    { 13, 1000m, 8, null, null, "", null, "کلید و پریز" },
                    { 14, 3500m, 8, null, null, "", null, "نصب و تعویض فیوز" },
                    { 15, 2000m, 8, null, null, "", null, "نصب و تعمیر دوربین مداربسته" },
                    { 16, 1000m, 11, null, null, "به صورت تخصصی", null, "نقاشی ساختمان" },
                    { 17, 3500m, 11, null, null, "", null, "نصب کاغذ دیواری" },
                    { 18, 2000m, 11, null, null, "", null, "ساخت و نصب توری" },
                    { 19, 1000m, 11, null, null, "", null, "بنایی" },
                    { 20, 3500m, 11, null, null, "به صورت تخصصی", null, "کفسابی" },
                    { 21, 1000m, 12, null, null, "", null, "ساخت و نصب درب و پنجره" },
                    { 22, 3500m, 12, null, null, "", null, "شیشه بری و آینه کاری" },
                    { 23, 2000m, 12, null, null, "جدید", null, "هندریل شیشه ای" },
                    { 24, 1000m, 12, null, null, "", null, "پارتیشن شیشه ای" },
                    { 25, 3500m, 12, null, null, "", null, "نصب و تعمیر درب اتوماتیک" },
                    { 26, 1000m, 13, null, null, "به صورت تخصصی", null, " مشاوره گل و گیاه" },
                    { 27, 3500m, 13, null, null, "", null, "تشخیص و کنترل آفت" },
                    { 28, 2000m, 13, null, null, "", null, "رسیگی به فضای سبز" },
                    { 29, 1000m, 14, null, null, "", null, "سرویس عادی نظافت" },
                    { 30, 3500m, 14, null, null, "", null, "سرویس لوکس نظافت" },
                    { 31, 2000m, 14, null, null, "", null, "پذیرایی" },
                    { 32, 1000m, 14, null, null, "", null, "کارگر ساده" },
                    { 33, 3500m, 14, null, null, "", null, "نظافت راه پله" },
                    { 34, 1000m, 15, null, null, "(فرش ، موکت ، مبل)", null, "شستشو در منزل" },
                    { 35, 3500m, 15, null, null, "", null, "قالیشویی" },
                    { 36, 2000m, 15, null, null, "", null, "خشکشویی" },
                    { 37, 1000m, 15, null, null, "", null, "پرده شویی" },
                    { 38, 1000m, 16, null, null, "(آب ، نانو)", null, "کارواش" },
                    { 39, 3500m, 16, null, null, "", null, "صفرشویی خودرو" },
                    { 40, 2000m, 16, null, null, "جدید", null, "سرامیک حودرو" },
                    { 41, 1000m, 16, null, null, "", null, "واکس و پولیش" },
                    { 42, 3500m, 16, null, null, "به صورت تخصصی", null, "صافکاری و نقاشی" },
                    { 43, 1000m, 17, null, null, "", null, "خدمات ناخن" },
                    { 44, 3500m, 17, null, null, "", null, " رنگ مو در منزل" },
                    { 45, 2000m, 17, null, null, "جدید", null, "پاکسازی و لایه برداری پوست" },
                    { 46, 1000m, 17, null, null, "", null, "آرایش صورت در منزل" },
                    { 47, 3500m, 17, null, null, "", null, "لیفت و لیمنت مژه" },
                    { 48, 1000m, 18, null, null, "", null, "کوتاهی مو و اصلاح صورت" },
                    { 49, 3500m, 18, null, null, "", null, "مراقب و زیبایی آقایان" },
                    { 50, 2000m, 18, null, null, "", null, "گریم داماد" },
                    { 51, 1000m, 19, null, null, "به صورت تخصصی", null, "برنامه ورزشی و تغذیه" },
                    { 52, 3500m, 19, null, null, "", null, "کلاس یوگا در خانه" },
                    { 53, 2000m, 19, null, null, "", null, "کلاس پیلاتس در خانه" },
                    { 54, 1000m, 19, null, null, "جدید", null, "کلاس سی ایکس در خانه" },
                    { 55, 3500m, 19, null, null, "", null, "حرکات اصلاحی" },
                    { 56, 1000m, 20, null, null, "", null, "نصب و تعمیر یخچال فریزر" },
                    { 57, 3500m, 20, null, null, "", null, " نصب و تعمیر ماشین ظرفشویی" },
                    { 58, 2000m, 20, null, null, "", null, "نصب و تعمیر ماشین لباسشویی" },
                    { 59, 1000m, 20, null, null, "", null, "نصب و تعمیر فر" },
                    { 60, 3500m, 20, null, null, "", null, "نصب و تعمیر هود آشپرخانه" },
                    { 61, 1000m, 20, null, null, "", null, "نصب و تعمیر اجاق گاز" },
                    { 62, 3500m, 20, null, null, "به صورت تخصصی", null, " تعمیرات تلویزیون" },
                    { 63, 2000m, 20, null, null, "جدید", null, "تعمیر چای ساز و قهوه ساز" },
                    { 64, 1000m, 20, null, null, "", null, "تعمیر جاروبرقی" },
                    { 65, 3500m, 20, null, null, "", null, "نصب و تعویض فیلتر آب" },
                    { 66, 1000m, 21, null, null, "", null, "تعمیر کامپیوتر و لپتاپ" },
                    { 67, 3500m, 21, null, null, "", null, " تعمیر ماشین های اداری" },
                    { 68, 2000m, 21, null, null, "", null, "پشتیبانی شبکه وسرور" },
                    { 69, 1000m, 21, null, null, "به صورت تخصصی", null, "طراحی سایت و لوگو" },
                    { 70, 3500m, 21, null, null, "", null, "مودم و اینترنت" },
                    { 71, 1000m, 22, null, null, "", null, "خدمات تاچ و ال سی دی" },
                    { 72, 3500m, 22, null, null, "", null, " خدمات باتری" },
                    { 73, 2000m, 22, null, null, "جدید", null, "خدمات نرم افزاری" },
                    { 74, 1000m, 22, null, null, "", null, "خدمات اسپیکر" },
                    { 75, 3500m, 22, null, null, "", null, "خدمات دوربین" },
                    { 76, 1000m, 23, null, null, "زیر قیمت کارخانه", null, "تعویض باتری خودرو" },
                    { 77, 3500m, 23, null, null, "", null, " برق و باتری خودرو" },
                    { 78, 2000m, 23, null, null, "", null, "مکانیکی خودرو" },
                    { 79, 1000m, 23, null, null, "", null, "امداد خودرو" },
                    { 80, 3500m, 23, null, null, "", null, "پنچرگیری" },
                    { 81, 1000m, 23, null, null, "", null, "کارشناسی خودرو" },
                    { 82, 3500m, 23, null, null, "", null, "تعویض لاستیک" },
                    { 83, 2000m, 23, null, null, "", null, "تعویض لنت خودرو" },
                    { 84, 1000m, 23, null, null, "", null, "سوخت رسانی" },
                    { 85, 3500m, 23, null, null, "", null, "تعمیر موتور سیکلت" },
                    { 86, 1000m, 24, null, null, "", null, "اسباب کشی با خاور و کامیون" },
                    { 87, 3500m, 24, null, null, "", null, " اسباب کشی با وانت و نیسان" },
                    { 88, 2000m, 24, null, null, "نیاز به توضیح", null, "اسباب کشی و حمل بین شهری" },
                    { 89, 1000m, 24, null, null, "", null, "کارگر جابجایی" },
                    { 90, 3500m, 24, null, null, "", null, "حمل نخاله و ضایعات ساختمانی" },
                    { 91, 1000m, 25, null, null, "", null, "مراقبت و نگهداری" },
                    { 92, 3500m, 25, null, null, "", null, " پرستاری و تزریقات" },
                    { 93, 2000m, 25, null, null, "", null, "معاینه پزشکی" },
                    { 94, 1000m, 25, null, null, "", null, "پیراپزشکی" },
                    { 95, 3500m, 25, null, null, "", null, "آزمایش و نمونه گیری" },
                    { 96, 1000m, 26, null, null, "جدید", null, "هتل های حیوانات خانگی" },
                    { 97, 3500m, 26, null, null, "", null, " خدماتدامپزشکی در محل" },
                    { 98, 2000m, 26, null, null, "به صورت تخصصی", null, "خدمات تربیتی حیوانات خانگی" },
                    { 99, 1000m, 26, null, null, "", null, "خدمات شستشو و آرایشی" },
                    { 100, 3500m, 26, null, null, "", null, "پت شاپ" }
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
                name: "IX_AspNetUsers_CustomerId",
                table: "AspNetUsers",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ExpertId",
                table: "AspNetUsers",
                column: "ExpertId");

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
                name: "IX_ExpertHomeService_SkillsId",
                table: "ExpertHomeService",
                column: "SkillsId");

            migrationBuilder.CreateIndex(
                name: "IX_HomeServices_CategoryId",
                table: "HomeServices",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_HomeServices_CategoryId1",
                table: "HomeServices",
                column: "CategoryId1");

            migrationBuilder.CreateIndex(
                name: "IX_HomeServices_CustomerId",
                table: "HomeServices",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Images_HomeServiceId",
                table: "Images",
                column: "HomeServiceId",
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
                name: "IX_Orders_HomeServiceId",
                table: "Orders",
                column: "HomeServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Suggestions_CityId",
                table: "Suggestions",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Suggestions_ExpertId",
                table: "Suggestions",
                column: "ExpertId");

            migrationBuilder.CreateIndex(
                name: "IX_Suggestions_HomeServiceId",
                table: "Suggestions",
                column: "HomeServiceId");

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
                name: "ExpertHomeService");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "Suggestions");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Experts");

            migrationBuilder.DropTable(
                name: "HomeServices");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
