using AH.Metadata.Domain.Entities;
using AH.Shared.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AH.Metadata.Persistence.Configurations;

public class CountryConfiguration : IEntityTypeConfiguration<Country>
{
    public void Configure(EntityTypeBuilder<Country> builder)
    {
        builder.ToTable("Country");
        builder.ConfigureBaseAuditableEntity();
        
        builder.Property(x=>x.Id).HasColumnName("CountryId");
        builder.Property(x=>x.UId).HasColumnName("CountryUId");
         builder.Property(e => e.Name).HasColumnName("CountryName")
                    .HasMaxLength(250)
                    .IsRequired();
        
        builder.HasIndex(x=>x.UId, "IX_Metadata_CountryUId");
    }
}