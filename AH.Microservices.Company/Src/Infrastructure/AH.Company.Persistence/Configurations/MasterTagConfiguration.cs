using AH.Company.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AH.Company.Persistence.Configurations;

public class MasterTagConfiguration : IEntityTypeConfiguration<MasterTag>
{
    public void Configure(EntityTypeBuilder<MasterTag> builder)
    {
        builder.ToTable("MasterTag");
        builder.ConfigureBaseAuditableEntity();
        builder.Property(e => e.Name).HasMaxLength(250).IsRequired();
        builder.Property(e => e.ClassName).HasMaxLength(100).IsRequired();
        builder.Property(e => e.ParentMasterTagId).HasDefaultValue(0);
        builder.HasOne(e=>e.MasterTagCategory)
            .WithMany(x=>x.MasterTags)
            .HasForeignKey(x=>x.MasterTagCategoryId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasMany(c => c.CompanyTeamMemberTags)
            .WithOne(c => c.MasterTag)
            .HasForeignKey(c => c.MasterTagId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasMany(c => c.CompanyTeamTags)
            .WithOne(c => c.MasterTag)
            .HasForeignKey(c => c.MasterTagId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasMany(c => c.CompanySkillTags)
            .WithOne(c => c.MasterTag)
            .HasForeignKey(c => c.MasterTagId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasMany(c => c.CompanyStakeholderTags) 
            .WithOne(c => c.MasterTag)
            .HasForeignKey(c => c.MasterTagId)
            .OnDelete(DeleteBehavior.Cascade);
        
        
    }
}