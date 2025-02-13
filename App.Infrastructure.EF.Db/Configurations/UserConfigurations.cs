using App.Domain.Core.Entites;
using App.Domain.Core.Entites.User;
using App.Domain.Core.Enums;
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

            builder.HasOne(u => u.Expert)
            .WithOne()
            .HasForeignKey<Expert>(e => e.Id)
            .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(u => u.Customer)
            .WithOne()
            .HasForeignKey<Customer>(c => c.Id)
            .OnDelete(DeleteBehavior.NoAction);

            builder.Property(u => u.Address).HasMaxLength(255);

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
                LockoutEnabled = false,
                Password = "123456",
                RePassword = "123456",
                Balance = 1000,
                FirstName = "Admin",
                LastName = "Admin",
                SecurityStamp = Guid.NewGuid().ToString(),
                RoleId = 1
            },
            new AppUser()
            {
                 Id = 2,
                UserName = "Customer@gmail.com",
                LockoutEnabled = false,
                Password = "456789",
                RePassword = "456789",
                FirstName = "Amir",
                LastName = "Amiri",
                SecurityStamp = Guid.NewGuid().ToString(),
                Balance = 1000 ,
                RoleId = 2

            },
            new AppUser()
            {
                 Id = 3,
                UserName = "Expert@gmail.com",
                LockoutEnabled = false,
                Password = "258852",
                RePassword = "258852",
                FirstName = "Amir",
                LastName = "Amiri",
                SecurityStamp = Guid.NewGuid().ToString(),
                Balance = 1000,
                RoleId = 3
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
