using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Xml.Linq;

namespace App.Infrastructure.EFCore.Configurations
{
    public class CommentConfigurations : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.CreateAt).IsRequired();
            builder.Property(c => c.Opinion).IsRequired();

            builder.HasOne(e => e.Expert)
                .WithMany()
                .HasForeignKey(e => e.ExpertId)
                .OnDelete(DeleteBehavior.NoAction);

            //builder.HasOne(e => e.RegisteredCustomer)
            //    .WithMany()
            //    .HasForeignKey(e => e.CustomerId)
            //    .OnDelete(DeleteBehavior.NoAction);


            builder.HasData(new List<Comment>
                  {
                      new Comment {Id = 1 , CreateAt = DateTime.Now ,Opinion = "بسیار تمیز و بادقت",Points = 9 , ExpertId = 1 ,CustomerId = 4},
                      new Comment {Id = 2 , CreateAt = DateTime.Now ,Opinion = "تحویل به موقع",Points = 9, ExpertId = 1 , CustomerId = 4},
                      new Comment {Id = 3 , CreateAt = DateTime.Now ,Opinion = "پاسخگویی بد", Points = 6, ExpertId = 1 ,CustomerId = 4},
                });
        }

    }
}
