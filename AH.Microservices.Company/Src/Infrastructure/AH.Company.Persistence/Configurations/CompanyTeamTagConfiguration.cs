using AH.Company.Domain.Entities;
using AH.Shared.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AH.Company.Persistence.Configurations;

public class CompanyTeamTagConfiguration : IEntityTypeConfiguration<CompanyTeamTag>
{
    public void Configure(EntityTypeBuilder<CompanyTeamTag> builder)
    {
        builder.ToTable("CompanyTeamTag");
        builder.ConfigureBaseAuditableEntity();
        
        builder.Property(c => c.Name)
            .HasColumnName("Name")
            .HasMaxLength(255)
            .IsRequired();
        
        builder.Property(c => c.CompanyTeamCategoryId)
            .HasColumnName("CompanyTeamCategoryId")
            .IsRequired();

        builder.Property(c => c.MasterTagId);
        
        builder.HasOne(c => c.CompanyTeamCategory)
            .WithMany(c => c.CompanyTeamTags)
            .HasForeignKey(c => c.CompanyTeamCategoryId)
            .OnDelete(DeleteBehavior.ClientNoAction);
        
        builder.HasOne(c => c.MasterTag)
            .WithMany(c=>c.CompanyTeamTags)
            .HasForeignKey(c => c.MasterTagId)
            .OnDelete(DeleteBehavior.ClientNoAction);
    }
}