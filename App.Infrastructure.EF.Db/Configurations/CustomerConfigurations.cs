using App.Domain.Core.Entites.User;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
namespace App.Infrastructure.EFCore.Configurations
{
    public class CustomerConfigurations : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasMany(x => x.Orders)
                   .WithOne(x => x.Customer)
                   .HasForeignKey(x => x.CustomerId)
                   .OnDelete(DeleteBehavior.NoAction);

            builder.Property(u => u.Address).HasMaxLength(255);

            builder.HasData(new List<Customer>
            {
                new Customer{Id = 1 , Address = "اینجا"}
            });
        }
    }

}
