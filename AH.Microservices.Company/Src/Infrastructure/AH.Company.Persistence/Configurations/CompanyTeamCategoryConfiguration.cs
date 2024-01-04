using AH.Company.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AH.Company.Persistence.Configurations;

public class CompanyTeamCategoryConfiguration : IEntityTypeConfiguration<CompanyTeamCategory>
{
    public void Configure(EntityTypeBuilder<CompanyTeamCategory> builder)
    {
        builder.ToTable("CompanyTeamCategory");
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
            .WithMany(c => c.CompanyTeamCategories)
            .HasForeignKey(c => c.CompanyId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(c => c.MasterTagCategory)
            .WithMany(c=>c.CompanyTeamCategories)
            .HasForeignKey(c => c.MasterTagCategoryId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasMany(c => c.CompanyTeamTags)    
            .WithOne(c=>c.CompanyTeamCategory)
            .HasForeignKey(c=>c.CompanyTeamCategoryId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}