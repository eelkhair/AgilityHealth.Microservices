using AH.Metadata.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AH.Metadata.Persistence.Configurations;

public class SurveyTypeConfiguration : IEntityTypeConfiguration<SurveyType>
{
    public void Configure(EntityTypeBuilder<SurveyType> builder)
    {
        builder.ToTable("SurveyType"); 
        builder.ConfigureBaseAuditableEntity();
        builder.Property(x=>x.Id).HasColumnName("SurveyTypeId");
        builder.Property(x=>x.UId).HasColumnName("SurveyTypeUId");

        builder.Property(e => e.Name)
            .HasMaxLength(250)
            .IsRequired()
            .HasColumnName("SurveyTypeName");      
        builder.HasIndex(x=>x.UId, "IX_Metadata_SurveyTypeUId");
        
    }
}