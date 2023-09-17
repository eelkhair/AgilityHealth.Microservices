using AH.Company.Domain.Entities;
using AH.Shared.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AH.Company.Persistence.Configurations;

public class CompanyStakeholderCategoryConfiguration : IEntityTypeConfiguration<CompanyStakeholderCategory>
{
    public void Configure(EntityTypeBuilder<CompanyStakeholderCategory> builder)
    {
        builder.ToTable("CompanyStakeholderCategory");
        builder.ConfigureBaseAuditableEntity();

        builder.Property(c => c.Name)
            .HasColumnName("Name")
            .HasMaxLength(255)
            .IsRequired();

        builder.Property(c => c.Type)
            .HasColumnName("Type")
            .HasMaxLength(10);

        builder.Property(c => c.CompanyId)
            .HasColumnName("CompanyId")
            .IsRequired();

        builder.Property(c => c.MasterTagCategoryId)
            .HasColumnName("MasterTagCategoryId")
            .IsRequired(false);

        builder.HasOne(c => c.Company)
            .WithMany(c => c.CompanyStakeholderCategories)
            .HasForeignKey(c => c.CompanyId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(c => c.MasterTagCategory)
            .WithMany(c => c.CompanyStakeholderCategories)
            .HasForeignKey(c => c.MasterTagCategoryId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasMany(c => c.CompanyStakeholderTags)
            .WithOne(c=>c.CompanyStakeholderCategory)
            .HasForeignKey(c=>c.CompanyStakeholderCategoryId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}