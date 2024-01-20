using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AH.User.Persistence.Configurations;

public class ApplicationUser : IEntityTypeConfiguration<Domain.Entities.ApplicationUser>
{
    public void Configure(EntityTypeBuilder<Domain.Entities.ApplicationUser> builder)
    {
        builder.ConfigureBaseAuditableEntity();
        builder.Property(e => e.FirstName).HasMaxLength(50).IsRequired();
        builder.Property(e => e.LastName).HasMaxLength(50).IsRequired();
        builder.Property(e => e.Email).HasMaxLength(256).IsRequired();
        builder.Property(e => e.Bio).HasMaxLength(1000);
        builder.Property(e => e.AvatarUrl).HasMaxLength(500);
        builder.Property(e => e.LinkedIn).HasMaxLength(500);
        builder.Property(e => e.TimeZoneInfoId).HasMaxLength(100);
        builder.HasMany(e => e.UserClaims)
            .WithOne(e => e.User)
            .HasForeignKey(e => e.UserId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}