﻿using App.Domain.Core.Entites.Service;
using App.Domain.Core.Entites.User;
using App.Infrastructure.EFCore.Configurations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace App.Infrastructure.EFCore.DataBase.Common
{
    public class AppDbContext : IdentityDbContext<AppUser, IdentityRole<int>, int>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new HouseWorkConfigurations());
            modelBuilder.ApplyConfiguration(new SuggestionConfigurations());
            modelBuilder.ApplyConfiguration(new OrderConfigurations());
            modelBuilder.ApplyConfiguration(new CategoryConfigurations());
            modelBuilder.ApplyConfiguration(new CityConfigurations());
            modelBuilder.ApplyConfiguration(new CommentConfigurations());
            modelBuilder.ApplyConfiguration(new ImageConfigurations());
            modelBuilder.ApplyConfiguration(new CustomerConfigurations());
            modelBuilder.ApplyConfiguration(new ExpertConfigurations());
            modelBuilder.ApplyConfiguration(new UserConfigurations());
            modelBuilder.ApplyConfiguration(new ExpertHouseWorkConfigurations());

            UserConfigurations.SeedUsers(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<HouseWork> HouseWorks { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Suggestion> Suggestions { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<AppUser> Users { get; set; }
        public DbSet<Expert> Experts { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<ExpertHouseWork> ExpertHouseWorks { get; set; }
    }
}
