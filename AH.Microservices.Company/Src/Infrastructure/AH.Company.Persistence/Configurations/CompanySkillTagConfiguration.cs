using AH.Company.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AH.Company.Persistence.Configurations;

public class CompanySkillTagConfiguration : IEntityTypeConfiguration<CompanySkillTag>
{
    public void Configure(EntityTypeBuilder<CompanySkillTag> builder)
    {
        builder.ToTable("CompanySkillTag");
        builder.ConfigureBaseAuditableEntity();

        builder.Property(c => c.Name)
            .HasColumnName("Name")
            .HasMaxLength(255)
            .IsRequired();

        builder.Property(c => c.CompanySkillCategoryId)
            .HasColumnName("CompanySkillCategoryId")
            .IsRequired();

        builder.Property(c => c.MasterTagId);

        builder.HasOne(c => c.CompanySkillCategory)
            .WithMany(c => c.CompanySkillTags)
            .HasForeignKey(c => c.CompanySkillCategoryId)
            .OnDelete(DeleteBehavior.ClientNoAction);
        
        builder.HasOne(c => c.MasterTag)
            .WithMany(c=>c.CompanySkillTags)
            .HasForeignKey(c => c.MasterTagId)
            .OnDelete(DeleteBehavior.ClientNoAction);
    }
}