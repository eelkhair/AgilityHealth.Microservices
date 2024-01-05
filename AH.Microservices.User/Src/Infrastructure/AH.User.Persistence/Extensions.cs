using AH.User.Domain.Constants;
using AH.User.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AH.User.Persistence;

public static class Extensions
{
    public static void ConfigureBaseEntity<TBaseEntity>(this EntityTypeBuilder<TBaseEntity> builder) where TBaseEntity : BaseEntity
    {
        builder.Property(e => e.UId).HasDefaultValueSql("newsequentialid()");
        builder.ToTable(x =>
        {
            x.IsTemporal();
        });
    }

    public static void ConfigureBaseAuditableEntity<TBaseAuditableEntity>(this EntityTypeBuilder<TBaseAuditableEntity> builder) where TBaseAuditableEntity : BaseAuditableEntity
    {
        ConfigureBaseEntity(builder);

        builder.Property(e => e.CreatedAt).HasColumnType("datetime2").IsRequired();
        builder.Property(e => e.UpdatedAt).HasColumnType("datetime2").IsRequired();
        builder.Property(e => e.CreatedBy).HasMaxLength(50).IsRequired();
        builder.Property(e => e.UpdatedBy).HasMaxLength(50).IsRequired();
        builder.Property(e => e.RecordStatus).HasMaxLength(25).HasDefaultValue(RecordStatuses.Active);
        builder.HasQueryFilter(e => e.RecordStatus == RecordStatuses.Active);
    }
}