using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Infrastructure.EFCore.Configurations
{
    public class SuggestionConfigurations : IEntityTypeConfiguration<Suggestion>
    {
        public void Configure(EntityTypeBuilder<Suggestion> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Description).HasMaxLength(2000).IsRequired();
            builder.Property(x => x.DeliverDate).IsRequired();

            builder.HasOne(x => x.Expert)
                .WithMany(x => x.Suggestions)
                .HasForeignKey(x => x.ExpertId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.Order)
                .WithMany(x => x.Suggestions)
                .HasForeignKey(x => x.OrderId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasData(new List<Suggestion>
            {
                new Suggestion { Id = 1, Description = "آمادگی برای انجام کار با قیمت پایین تر" , DeliverDate = new DateTime(2025,2 ,25), OrderId = 1, ExpertId = 1 }
            });
        }
    }
}
