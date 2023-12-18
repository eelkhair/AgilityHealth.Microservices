using AH.Metadata.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AH.Metadata.Persistence.Configurations;

public class IndustryConfiguration: IEntityTypeConfiguration<Industry>
{
    public void Configure(EntityTypeBuilder<Industry> builder)
    {
        builder.ToTable("Industry"); 
        builder.ConfigureBaseAuditableEntity();
        builder.Property(x=>x.Id).HasColumnName("IndustryId");
        builder.Property(x=>x.UId).HasColumnName("IndustryUId");
        builder.HasIndex(x=>x.UId, "IX_Metadata_IndustryUId");
        builder.Property(e => e.IsDefault).HasColumnName("IsDefault");
        builder.Property(e => e.Name).
            HasColumnName("IndustryName")
            .HasMaxLength(250)
            .IsRequired();
    }
}