using AH.Company.Domain.Entities;
using AH.Shared.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AH.Company.Persistence.Configurations;

public class CompanyTeamMemberTagConfiguration : IEntityTypeConfiguration<CompanyTeamMemberTag>
{
    public void Configure(EntityTypeBuilder<CompanyTeamMemberTag> builder)
    {
        builder.ToTable("CompanyTeamMemberTag");
        builder.ConfigureBaseAuditableEntity();
        
        builder.Property(c => c.Name)
            .HasColumnName("Name")
            .HasMaxLength(255)
            .IsRequired();
        
        builder.Property(c => c.CompanyTeamMemberCategoryId)
            .HasColumnName("CompanyTeamMemberCategoryId")
            .IsRequired();

        builder.Property(c => c.MasterTagId);
        
        builder.HasOne(c => c.CompanyTeamMemberCategory)
            .WithMany(c => c.CompanyTeamMemberTags)
            .HasForeignKey(c => c.CompanyTeamMemberCategoryId)
            .OnDelete(DeleteBehavior.ClientNoAction);
        
        builder.HasOne(c => c.MasterTag)
            .WithMany(c=>c.CompanyTeamMemberTags)
            .HasForeignKey(c => c.MasterTagId)
            .OnDelete(DeleteBehavior.ClientNoAction);
    }
}