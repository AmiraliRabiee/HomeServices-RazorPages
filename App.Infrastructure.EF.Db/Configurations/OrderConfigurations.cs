using App.Domain.Core.Entites;
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
                .HasForeignKey(x => x.CustomerId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(o => o.Expert)
                .WithMany(o => o.AcceptedOrders)
                .HasForeignKey(o => o.ExpertId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
