using App.Domain.Core.Entites;
using App.Domain.Core.Enum;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace App.Infrastructure.EFCore.Configurations
{
    public class OrderConfigurations : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Description).HasMaxLength(2000).IsRequired();
            builder.Property(x => x.CompletionDate).IsRequired();
            builder.Property(x => x.RunningTime).IsRequired();


            builder.HasOne(h => h.HouseWork)
                .WithMany(h => h.Orders)
                .HasForeignKey(h => h.HouseWorkId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.Customer)
                .WithMany(x => x.Orders)
                .HasForeignKey(x => x.CustomerId);


            builder.HasData(new List<Order>
            {
                new Order {
                Id = 1,
                Description = "فوری",
                HouseWorkId = 5,
                CompletionDate = new DateTime(2025, 2, 21),
                RunningTime = new TimeOnly(11),
                CreateAt = DateTime.Now,
                IsDeleted = false,
                StausService = StausServiceEnum.NewlyRegistered,
                CustomerId = 1
                },

                new Order {
                Id = 2,
                Description = "",
                HouseWorkId = 6,
                CompletionDate = new DateTime(2025, 2, 21),
                RunningTime = new TimeOnly(10,30),
                CreateAt = DateTime.Now,
                IsDeleted = false,
                StausService = StausServiceEnum.NewlyRegistered,
                CustomerId = 1
                },

                new Order {
                Id = 3,
                Description = "فوری",
                HouseWorkId = 30,
                CompletionDate = new DateTime(2025, 2, 21),
                RunningTime = new TimeOnly(4,30),
                CreateAt = DateTime.Now,
                IsDeleted = false,
                StausService = StausServiceEnum.NewlyRegistered,
                CustomerId = 1
                }
            });
        }
    }
}
