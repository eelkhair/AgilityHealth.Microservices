using AH.Metadata.Domain.Entities;
using AH.Shared.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AH.Metadata.Persistence.Configurations;

public class CompanyConfiguration : IEntityTypeConfiguration<Company>
{
    public void Configure(EntityTypeBuilder<Company> builder)
    {
        builder.ToTable("Company");
        builder.ConfigureBaseAuditableEntity();

        builder.Property(x => x.Id).HasColumnName("CompanyId");
        
        builder.Property(x => x.UId).HasColumnName("CompanyUId");
        
        builder.Property(e => e.Name)
            .HasColumnName("CompanyName")
            .HasMaxLength(250)
            .IsRequired();

        builder.HasIndex(x => x.UId, "IX_Metadata_CompanyUId");

        builder.HasOne(e => e.Domain)
            .WithMany(e => e.Companies)
            .HasForeignKey(e => e.DomainId);
    }
}