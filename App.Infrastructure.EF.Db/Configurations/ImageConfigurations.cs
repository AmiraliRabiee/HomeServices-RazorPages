using App.Domain.Core.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Infrastructure.EFCore.Configurations
{
    public class ImageConfigurations : IEntityTypeConfiguration<Image>
    {
        public void Configure(EntityTypeBuilder<Image> builder)
        {
            builder.HasKey(i => i.Id);

            builder.Property(i => i.Path)
                .IsRequired()
                .HasMaxLength(500); 

            builder.HasOne(i => i.Order)
                .WithMany(o => o.Images)
                .HasForeignKey(o => o.OrderId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
