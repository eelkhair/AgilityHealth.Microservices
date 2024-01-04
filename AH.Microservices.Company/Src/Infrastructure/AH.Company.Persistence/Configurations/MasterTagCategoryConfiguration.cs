using AH.Company.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AH.Company.Persistence.Configurations;

public class MasterTagCategoryConfiguration : IEntityTypeConfiguration<MasterTagCategory>
{
    public void Configure(EntityTypeBuilder<MasterTagCategory> builder)
    {
        builder.ToTable("MasterTagCategory");
        builder.ConfigureBaseAuditableEntity();

        builder.Property(c => c.Name)
            .HasColumnName("Name")
            .HasMaxLength(250)
            .IsRequired();

        builder.Property(c => c.Type)
            .HasColumnName("Type")
            .HasMaxLength(25);

        builder.Property(c=>c.ClassName)
            .HasMaxLength(100)
            .IsRequired();
        
        builder.HasMany(c => c.CompanyTeamCategories)
            .WithOne(c => c.MasterTagCategory)
            .HasForeignKey(c => c.MasterTagCategoryId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(c => c.CompanyTeamMemberCategories)
            .WithOne(c => c.MasterTagCategory)
            .HasForeignKey(c => c.MasterTagCategoryId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasMany(c => c.MasterTags)
            .WithOne(c => c.MasterTagCategory)
            .HasForeignKey(c => c.MasterTagCategoryId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasMany(c => c.CompanySkillCategories)
            .WithOne(c => c.MasterTagCategory)
            .HasForeignKey(c => c.MasterTagCategoryId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasMany(c => c.CompanyStakeholderCategories)
            .WithOne(c => c.MasterTagCategory)
            .HasForeignKey(c => c.MasterTagCategoryId)
            .OnDelete(DeleteBehavior.Cascade);
        
        
    }
}