using AH.Metadata.Domain.Entities;
using AH.Shared.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AH.Metadata.Persistence.Configurations;

public class MasterTagCategoryConfiguration : IEntityTypeConfiguration<MasterTagCategory>
{
    public void Configure(EntityTypeBuilder<MasterTagCategory> builder)
    {
        builder.ToTable("MasterTagCategory");
        builder.ConfigureBaseAuditableEntity();
        builder.Property(x=>x.Id).HasColumnName("MasterTagCategoryId");
        builder.Property(x=>x.UId).HasColumnName("MasterTagCategoryUId");
   
        builder.Property(e => e.Name)
            .HasColumnName("MasterTagCategoryName")
            .HasMaxLength(250)
            .IsRequired();
        builder.Property(e => e.ClassName).HasMaxLength(100).IsRequired();
    builder.Property(e => e.Type).HasMaxLength(25).IsRequired(false);
        builder.HasMany(e => e.MasterTags)
            .WithOne(x => x.MasterTagCategory)
            .HasForeignKey(x => x.MasterTagCategoryId)
            .OnDelete(DeleteBehavior.ClientSetNull); 
        builder.HasIndex(x=>x.UId, "IX_Metadata_MasterTagCategoryUId");
    }
}