using App.Domain.Core.Entites;
using App.Domain.Core.Entites.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Net;

namespace App.Infrastructure.EFCore.Configurations
{
    public class ExpertConfigurations : IEntityTypeConfiguration<Expert>
    {
        public void Configure(EntityTypeBuilder<Expert> builder)
        {
            builder.ToTable(nameof(Expert));

            builder.HasKey(e => e.Id);

            builder.Property(u => u.Address).HasMaxLength(255);
            builder.Property(u => u.Biographi).HasMaxLength(2000);

            builder.HasData(new List<Expert>{
                new Expert { Id = 1, Address = "اینجا", Biographi = "بیوگرافی" ,IsDeleted = false}
            });

        }

    }
}
