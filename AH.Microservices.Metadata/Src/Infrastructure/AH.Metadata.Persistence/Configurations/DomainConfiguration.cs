using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AH.Metadata.Persistence.Configurations;

public class DomainConfiguration : IEntityTypeConfiguration<Domain.Entities.Domain>
{
    public void Configure(EntityTypeBuilder<Domain.Entities.Domain> builder)
    {
        builder.ToTable("Domain");
        builder.ConfigureBaseAuditableEntity();
        
        builder.Property(x=>x.Id).HasColumnName("DomainId");
        builder.Property(x => x.UId).HasColumnName("DomainUId");
        builder.Property(e => e.Name).HasColumnName("DomainName").HasMaxLength(250).IsRequired();  
         
        builder.HasIndex(x=>x.UId, "IX_Metadata_DomainUId");
        
        builder.HasMany(e => e.Companies)
            .WithOne(e => e.Domain)
            .HasForeignKey(e => e.DomainId);
    }
}