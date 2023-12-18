using AH.Metadata.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AH.Metadata.Persistence.Configurations;

public class MasterTagConfiguration : IEntityTypeConfiguration<MasterTag>
{
    public void Configure(EntityTypeBuilder<MasterTag> builder)
    {
        builder.ToTable("MasterTag");   
        builder.ConfigureBaseAuditableEntity();
        builder.Property(x => x.Id).HasColumnName("MasterTagId");
        builder.Property(x => x.UId).HasColumnName("MasterTagUId");
        builder.Property(x => x.ParentMasterTagId).HasDefaultValue(0);
     
        builder.Property(e => e.Name).HasColumnName("MasterTagName")
            .HasMaxLength(250)
            .IsRequired();
        builder.Property(e
            => e.ClassName).HasMaxLength(100).IsRequired();
        builder.HasOne(e=>e.MasterTagCategory)
            .WithMany(x=>x.MasterTags)
            .HasForeignKey(x=>x.MasterTagCategoryId)
            .OnDelete(DeleteBehavior.Cascade);

                
        builder.HasIndex(x => x.UId, "IX_Metadata_MasterTagUId");
    }
}