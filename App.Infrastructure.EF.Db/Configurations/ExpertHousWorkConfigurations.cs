using App.Domain.Core.Entites.Service;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

public class ExpertHouseWorkConfigurations : IEntityTypeConfiguration<ExpertHouseWork>
{
    public void Configure(EntityTypeBuilder<ExpertHouseWork> builder)
    {
        // Set composite key
        builder.HasKey(eh => new { eh.ExpertId, eh.HouseWorkId });

        // Relationship with Expert
        builder.HasOne(eh => eh.Expert)
            .WithMany(e => e.ExpertWorksSkills) // Ensure Expert has this navigation property
            .HasForeignKey(eh => eh.ExpertId)
            .OnDelete(DeleteBehavior.Cascade);

        // Relationship with HouseWork
        builder.HasOne(eh => eh.HouseWork)
            .WithMany(h => h.ExpertHouseWorks) // Ensure HouseWork has this navigation property
            .HasForeignKey(eh => eh.HouseWorkId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
