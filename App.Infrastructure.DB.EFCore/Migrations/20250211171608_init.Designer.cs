﻿// <auto-generated />
using System;
using App.Infrastructure.DataBase.EFCore;
using App.Infrastructure.DB.EFCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace App.Infrastructure.DB.EFCore.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20250211171608_init")]
    partial class init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("App.Domain.Core.Entites.AppUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<int>("Balance")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CustomerId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<int?>("ExpertId")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("ExpertId");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AccessFailedCount = 0,
                            Balance = 1000,
                            ConcurrencyStamp = "b4527fec-5e52-4371-83c9-0ace81cc6b11",
                            Email = "Admin@gmail.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "ADMIN@GMAIL.COM",
                            NormalizedUserName = "ADMIN@GMAIL.COM",
                            PasswordHash = "AQAAAAIAAYagAAAAEMCquHaaFJkCyHMMw5948v1csgimmyIXWiPSFBKqY0wSOXX9m83TEgGorrkejWsX0g==",
                            PhoneNumberConfirmed = false,
                            Role = 1,
                            TwoFactorEnabled = false,
                            UserName = "Admin@gmail.com"
                        },
                        new
                        {
                            Id = 2,
                            AccessFailedCount = 0,
                            Balance = 1000,
                            ConcurrencyStamp = "8bd18f63-ed1f-4a5d-9a4c-321ec14e550a",
                            Email = "Customer@gmail.com",
                            EmailConfirmed = false,
                            FirstName = "Amir",
                            LastName = "Amiri",
                            LockoutEnabled = false,
                            NormalizedEmail = "CUSTOMER@GMAIL.COM",
                            NormalizedUserName = "CUSTOMER@GMAIL.COM",
                            PasswordHash = "AQAAAAIAAYagAAAAEGCaowIXZal9otaateoJxoTn6d8lt4ccoPnFXQyH0OR2rE1ypuN+PmLTaQJfXtWl/A==",
                            PhoneNumberConfirmed = false,
                            Role = 2,
                            TwoFactorEnabled = false,
                            UserName = "Customer@gmail.com"
                        },
                        new
                        {
                            Id = 3,
                            AccessFailedCount = 0,
                            Balance = 1000,
                            ConcurrencyStamp = "1c35290d-1c3b-491e-87e0-06aca0c1e7d5",
                            Email = "Expert@gmail.com",
                            EmailConfirmed = false,
                            FirstName = "Amir",
                            LastName = "Amiri",
                            LockoutEnabled = false,
                            NormalizedEmail = "EXPERT@GMAIL.COM",
                            NormalizedUserName = "EXPERT@GMAIL.COM",
                            PasswordHash = "AQAAAAIAAYagAAAAEDF/miGsNnb88dcRBpKlr4Ywt6Gw6dil/OQGUabD3UWrHmsVUvE5ombGHdnzoqTqZw==",
                            PhoneNumberConfirmed = false,
                            Role = 3,
                            TwoFactorEnabled = false,
                            UserName = "Expert@gmail.com"
                        });
                });

            modelBuilder.Entity("App.Domain.Core.Entites.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ImagePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ParentId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("App.Domain.Core.Entites.Expert", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Biographi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Points")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Expert");
                });

            modelBuilder.Entity("App.Domain.Core.Entites.HomeService", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("CategoryId")
                        .HasColumnType("int");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<int>("SubCategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Tiltle")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("ViewCount")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(1);

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("SubCategoryId");

                    b.ToTable("HomeServices");
                });

            modelBuilder.Entity("App.Domain.Core.Entites.User.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.HasKey("Id");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Cities");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "تهران"
                        },
                        new
                        {
                            Id = 2,
                            Name = "مشهد"
                        },
                        new
                        {
                            Id = 3,
                            Name = "اصفهان"
                        },
                        new
                        {
                            Id = 4,
                            Name = "شیراز"
                        },
                        new
                        {
                            Id = 5,
                            Name = "تبریز"
                        },
                        new
                        {
                            Id = 6,
                            Name = "کرج"
                        },
                        new
                        {
                            Id = 7,
                            Name = "قم"
                        },
                        new
                        {
                            Id = 8,
                            Name = "اهواز"
                        },
                        new
                        {
                            Id = 9,
                            Name = "رشت"
                        },
                        new
                        {
                            Id = 10,
                            Name = "کرمانشاه"
                        },
                        new
                        {
                            Id = 11,
                            Name = "زاهدان"
                        },
                        new
                        {
                            Id = 12,
                            Name = "ارومیه"
                        },
                        new
                        {
                            Id = 13,
                            Name = "یزد"
                        },
                        new
                        {
                            Id = 14,
                            Name = "همدان"
                        },
                        new
                        {
                            Id = 15,
                            Name = "قزوین"
                        },
                        new
                        {
                            Id = 16,
                            Name = "سنندج"
                        },
                        new
                        {
                            Id = 17,
                            Name = "بندرعباس"
                        },
                        new
                        {
                            Id = 18,
                            Name = "زنجان"
                        },
                        new
                        {
                            Id = 19,
                            Name = "ساری"
                        },
                        new
                        {
                            Id = 20,
                            Name = "بوشهر"
                        },
                        new
                        {
                            Id = 21,
                            Name = "مازندران"
                        },
                        new
                        {
                            Id = 22,
                            Name = "گرگان"
                        },
                        new
                        {
                            Id = 23,
                            Name = "کرمان"
                        },
                        new
                        {
                            Id = 24,
                            Name = "خرم آباد"
                        },
                        new
                        {
                            Id = 25,
                            Name = "سمنان"
                        });
                });

            modelBuilder.Entity("Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("ExpertId")
                        .HasColumnType("int");

                    b.Property<int?>("ExpertRating")
                        .HasColumnType("int");

                    b.Property<int?>("stausService")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ExpertId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("ExpertHomeService", b =>
                {
                    b.Property<int>("ExpertId")
                        .HasColumnType("int");

                    b.Property<int>("SkillsId")
                        .HasColumnType("int");

                    b.HasKey("ExpertId", "SkillsId");

                    b.HasIndex("SkillsId");

                    b.ToTable("ExpertHomeService");
                });

            modelBuilder.Entity("Image", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("HomeServiceId")
                        .HasColumnType("int");

                    b.Property<int>("HomeServicesId")
                        .HasColumnType("int");

                    b.Property<string>("Path")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("HomeServiceId");

                    b.HasIndex("HomeServicesId");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Customer",
                            NormalizedName = "CUSTOMER"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Expert",
                            NormalizedName = "EXPERT"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            RoleId = 1
                        },
                        new
                        {
                            UserId = 2,
                            RoleId = 2
                        },
                        new
                        {
                            UserId = 3,
                            RoleId = 3
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BasePrice")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(10000);

                    b.Property<int>("CityId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CompletionDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("CreateAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)");

                    b.Property<int?>("ExpertId")
                        .HasColumnType("int");

                    b.Property<int>("HomeServiceId")
                        .HasColumnType("int");

                    b.Property<DateTime>("RunningTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("StausService")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("ExpertId");

                    b.HasIndex("HomeServiceId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Suggestion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CityId")
                        .HasColumnType("int");

                    b.Property<int?>("CustomerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DeliverDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)");

                    b.Property<int>("ExpertId")
                        .HasColumnType("int");

                    b.Property<int>("HomeServiceId")
                        .HasColumnType("int");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<float>("SuggestPrice")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("ExpertId");

                    b.HasIndex("HomeServiceId");

                    b.HasIndex("OrderId");

                    b.ToTable("Suggestions");
                });

            modelBuilder.Entity("App.Domain.Core.Entites.AppUser", b =>
                {
                    b.HasOne("App.Domain.Core.Entites.User.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId");

                    b.HasOne("App.Domain.Core.Entites.Expert", "Expert")
                        .WithMany()
                        .HasForeignKey("ExpertId");

                    b.Navigation("Customer");

                    b.Navigation("Expert");
                });

            modelBuilder.Entity("App.Domain.Core.Entites.Category", b =>
                {
                    b.HasOne("App.Domain.Core.Entites.Category", "ParentCategory")
                        .WithMany("SubCategories")
                        .HasForeignKey("ParentId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("ParentCategory");
                });

            modelBuilder.Entity("App.Domain.Core.Entites.HomeService", b =>
                {
                    b.HasOne("App.Domain.Core.Entites.Category", null)
                        .WithMany("HomeServices")
                        .HasForeignKey("CategoryId");

                    b.HasOne("App.Domain.Core.Entites.User.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("App.Domain.Core.Entites.Category", "SubCategory")
                        .WithMany()
                        .HasForeignKey("SubCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("SubCategory");
                });

            modelBuilder.Entity("Comment", b =>
                {
                    b.HasOne("App.Domain.Core.Entites.Expert", "Expert")
                        .WithMany("Comments")
                        .HasForeignKey("ExpertId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Expert");
                });

            modelBuilder.Entity("ExpertHomeService", b =>
                {
                    b.HasOne("App.Domain.Core.Entites.Expert", null)
                        .WithMany()
                        .HasForeignKey("ExpertId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("App.Domain.Core.Entites.HomeService", null)
                        .WithMany()
                        .HasForeignKey("SkillsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Image", b =>
                {
                    b.HasOne("App.Domain.Core.Entites.HomeService", null)
                        .WithMany("Images")
                        .HasForeignKey("HomeServiceId");

                    b.HasOne("App.Domain.Core.Entites.HomeService", "HomeService")
                        .WithMany()
                        .HasForeignKey("HomeServicesId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("HomeService");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<int>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.HasOne("App.Domain.Core.Entites.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.HasOne("App.Domain.Core.Entites.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<int>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("App.Domain.Core.Entites.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.HasOne("App.Domain.Core.Entites.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Order", b =>
                {
                    b.HasOne("City", "City")
                        .WithMany("Orders")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("App.Domain.Core.Entites.User.Customer", "Customer")
                        .WithMany("Orders")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("App.Domain.Core.Entites.Expert", null)
                        .WithMany("AcceptedOrders")
                        .HasForeignKey("ExpertId");

                    b.HasOne("App.Domain.Core.Entites.HomeService", "HomeService")
                        .WithMany("Orders")
                        .HasForeignKey("HomeServiceId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("City");

                    b.Navigation("Customer");

                    b.Navigation("HomeService");
                });

            modelBuilder.Entity("Suggestion", b =>
                {
                    b.HasOne("City", "City")
                        .WithMany("Suggestions")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("App.Domain.Core.Entites.User.Customer", null)
                        .WithMany("SuggestionsReceived")
                        .HasForeignKey("CustomerId");

                    b.HasOne("App.Domain.Core.Entites.Expert", "Expert")
                        .WithMany("Suggestions")
                        .HasForeignKey("ExpertId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("App.Domain.Core.Entites.HomeService", "HomeService")
                        .WithMany("Suggestions")
                        .HasForeignKey("HomeServiceId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Order", "Order")
                        .WithMany()
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");

                    b.Navigation("Expert");

                    b.Navigation("HomeService");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("App.Domain.Core.Entites.Category", b =>
                {
                    b.Navigation("HomeServices");

                    b.Navigation("SubCategories");
                });

            modelBuilder.Entity("App.Domain.Core.Entites.Expert", b =>
                {
                    b.Navigation("AcceptedOrders");

                    b.Navigation("Comments");

                    b.Navigation("Suggestions");
                });

            modelBuilder.Entity("App.Domain.Core.Entites.HomeService", b =>
                {
                    b.Navigation("Images");

                    b.Navigation("Orders");

                    b.Navigation("Suggestions");
                });

            modelBuilder.Entity("App.Domain.Core.Entites.User.Customer", b =>
                {
                    b.Navigation("Orders");

                    b.Navigation("SuggestionsReceived");
                });

            modelBuilder.Entity("City", b =>
                {
                    b.Navigation("Orders");

                    b.Navigation("Suggestions");
                });
#pragma warning restore 612, 618
        }
    }
}
