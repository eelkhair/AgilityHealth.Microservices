using AH.Metadata.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AH.Metadata.Persistence.Configurations;

public class GrowthPlanStatusConfiguration : IEntityTypeConfiguration<GrowthPlanStatus>
{
    public void Configure(EntityTypeBuilder<GrowthPlanStatus> builder)
    {
        builder.ToTable("GrowthPlanStatus");
        builder.ConfigureBaseAuditableEntity();
        
        builder.Property(x=>x.Id).HasColumnName("GrowthPlanStatusId");
        builder.Property(x=>x.UId).HasColumnName("GrowthPlanStatusUId");
        builder.Property(e => e.Status)
                    .HasColumnName("GrowthPlanStatusName")
                    .HasMaxLength(250)
                    .IsRequired();
        
        builder.HasIndex(x=>x.UId, "IX_Metadata_GrowthPlanStatusUId");
    }
}