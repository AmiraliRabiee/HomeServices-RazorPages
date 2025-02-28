using App.Domain.Core.Entites.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Infrastructure.EFCore.Configurations
{
    public class UserConfigurations : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Balance).IsRequired().HasDefaultValue(1000);
        }

        public static void SeedUsers(ModelBuilder builder)
        {
            var hasher = new PasswordHasher<AppUser>();



            //SeedUsers
            var users = new List<AppUser>
        {
            new AppUser()
            {
                Id = 1,
                UserName = "Admin@gmail.com",
                NormalizedEmail = "ADMIN@GMAIL.COM",
                LockoutEnabled = false,
                Email = "Admin@gmail.com",
                NormalizedUserName = "ADMIN@GMAIL.COM",
                Balance = 1000,
                FirstName = "Admin",
                LastName = "Admin",
                SecurityStamp = Guid.NewGuid().ToString(),
                RoleId = 1,
                RegisterAt = DateTime.Now,

            },
            new AppUser()
            {
                 Id = 2,
                UserName = "Customer@gmail.com",
                NormalizedUserName = "CUSTOMER@GMAIL.COM",
                LockoutEnabled = false,
                Email = "Customer@gmail.com",
                NormalizedEmail ="CUSTOMER@GMAIL.COM",
                FirstName = "Amir",
                LastName = "Amiri",
                SecurityStamp = Guid.NewGuid().ToString(),
                Balance = 1000 ,
                RoleId = 2,
                RegisterAt = DateTime.Now,

            },
            new AppUser()
            {
                 Id = 3,
                UserName = "Expert@gmail.com",
                NormalizedUserName = "EXPERT@GMAIL.COM",
                LockoutEnabled = false,
                Email = "Expert@gmail.com",
                NormalizedEmail = "EXPERT@GMAIL.COM",
                FirstName = "Amir",
                LastName = "Amiri",
                SecurityStamp = Guid.NewGuid().ToString(),
                Balance = 1000,
                RoleId = 3,
                RegisterAt = DateTime.Now,
            }
        };

            foreach (var user in users)
            {
                var passwordHasher = new PasswordHasher<AppUser>();
                user.PasswordHash = passwordHasher.HashPassword(user, "123456");
                builder.Entity<AppUser>().HasData(user);
            }

            // Seed Roles
            builder.Entity<IdentityRole<int>>().HasData(
                new IdentityRole<int>() { Id = 1, Name = "Admin", NormalizedName = "ADMIN" },
                new IdentityRole<int>() { Id = 2, Name = "Customer", NormalizedName = "CUSTOMER" },
                new IdentityRole<int>() { Id = 3, Name = "Expert", NormalizedName = "EXPERT" }
            );

            //Seed Role To Users
            builder.Entity<IdentityUserRole<int>>().HasData(
                new IdentityUserRole<int>() { RoleId = 1, UserId = 1 },
                new IdentityUserRole<int>() { RoleId = 2, UserId = 2 },
                new IdentityUserRole<int>() { RoleId = 3, UserId = 3 }
            );
        }


    }
}
