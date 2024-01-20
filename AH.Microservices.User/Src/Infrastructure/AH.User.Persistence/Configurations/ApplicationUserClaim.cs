using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AH.User.Persistence.Configurations;

public class ApplicationUserClaim : IEntityTypeConfiguration<Domain.Entities.ApplicationUserClaim>
{
    public void Configure(EntityTypeBuilder<Domain.Entities.ApplicationUserClaim> builder)
    {
        builder.ConfigureBaseAuditableEntity();
        builder.Property(e => e.ClaimType).HasMaxLength(50).IsRequired();
        builder.Property(e => e.ClaimValue).HasMaxLength(500).IsRequired();
        
        builder.HasOne(e => e.User)
            .WithMany(e => e.UserClaims)
            .HasForeignKey(e => e.UserId)
            .OnDelete(DeleteBehavior.Cascade);
        
    }
}