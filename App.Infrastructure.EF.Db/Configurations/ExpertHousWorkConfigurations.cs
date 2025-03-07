using App.Domain.Core.Entites.Service;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

public class ExpertHouseWorkConfigurations : IEntityTypeConfiguration<ExpertHouseWork>
{
    public void Configure(EntityTypeBuilder<ExpertHouseWork> builder)
    {
        builder.HasKey(eh => new { eh.ExpertId, eh.HouseWorkId });

        builder.HasOne(eh => eh.Expert)
            .WithMany(e => e.ExpertWorksSkills) 
            .HasForeignKey(eh => eh.ExpertId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(eh => eh.HouseWork)
            .WithMany(h => h.ExpertHouseWorks) 
            .HasForeignKey(eh => eh.HouseWorkId)
            .OnDelete(DeleteBehavior.Cascade);


        builder.HasData(new List<ExpertHouseWork>
                  {
                      new ExpertHouseWork{HouseWorkId = 1 , ExpertId = 2},
                      new ExpertHouseWork{HouseWorkId= 2 , ExpertId = 2},
                  });
    }
}
