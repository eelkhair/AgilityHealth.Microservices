using AH.Company.Domain.Entities;
using AH.Shared.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AH.Company.Persistence.Configurations;

public class CompanyStakeholderTagConfiguration : IEntityTypeConfiguration<CompanyStakeholderTag>
{
    public void Configure(EntityTypeBuilder<CompanyStakeholderTag> builder)
    {
        builder.ToTable("CompanyStakeholderTag");
        builder.ConfigureBaseAuditableEntity();

        builder.Property(c => c.Name)
            .HasColumnName("Name")
            .HasMaxLength(255)
            .IsRequired();

        builder.Property(c => c.CompanyStakeholderCategoryId)
            .HasColumnName("CompanyStakeholderCategoryId")
            .IsRequired();

        builder.Property(c => c.MasterTagId);

        builder.HasOne(c => c.CompanyStakeholderCategory)
            .WithMany(c => c.CompanyStakeholderTags)
            .HasForeignKey(c => c.CompanyStakeholderCategoryId)
            .OnDelete(DeleteBehavior.ClientNoAction);
        
        builder.HasOne(c => c.MasterTag)
            .WithMany(c=>c.CompanyStakeholderTags)
            .HasForeignKey(c => c.MasterTagId)
            .OnDelete(DeleteBehavior.ClientNoAction);
    }
}
