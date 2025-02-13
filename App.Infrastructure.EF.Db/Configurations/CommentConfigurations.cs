using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Infrastructure.EFCore.Configurations
{
    public class CommentConfigurations : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.CreateAt).IsRequired();

            builder.HasOne(e => e.Expert)
                .WithMany(expert => expert.Comments)
                .HasForeignKey(e => e.ExpertId)
                .OnDelete(DeleteBehavior.NoAction);
        }

    }
}
