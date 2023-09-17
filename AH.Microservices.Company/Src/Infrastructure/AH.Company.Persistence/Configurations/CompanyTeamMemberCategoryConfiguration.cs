using AH.Company.Domain.Entities;
using AH.Shared.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AH.Company.Persistence.Configurations;

public class CompanyTeamMemberCategoryConfiguration : IEntityTypeConfiguration<CompanyTeamMemberCategory>
{
    public void Configure(EntityTypeBuilder<CompanyTeamMemberCategory> builder)
    {
        builder.ToTable("CompanyTeamMemberCategory");
        builder.ConfigureBaseAuditableEntity();

        builder.Property(c => c.Name)
            .HasColumnName("Name")
            .HasMaxLength(255)
            .IsRequired();

        builder.Property(c => c.Type)
            .HasColumnName("Type")
            .HasMaxLength(10)
            .IsRequired(false);

        builder.Property(c => c.CompanyId)
            .HasColumnName("CompanyId")
            .IsRequired();

        builder.Property(c => c.MasterTagCategoryId)
            .HasColumnName("MasterTagCategoryId")
            .IsRequired(false);

        builder.HasOne(c => c.Company)
            .WithMany(c => c.CompanyTeamMemberCategories)
            .HasForeignKey(c => c.CompanyId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(c => c.MasterTagCategory)
            .WithMany(c=>c.CompanyTeamMemberCategories)
            .HasForeignKey(c => c.MasterTagCategoryId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasMany(c => c.CompanyTeamMemberTags)    
            .WithOne(c=>c.CompanyTeamMemberCategory)
            .HasForeignKey(c=>c.CompanyTeamMemberCategoryId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}