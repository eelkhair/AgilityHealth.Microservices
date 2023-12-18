using AH.Metadata.Application.Dtos;
using AH.Metadata.Domain.Constants;
using AH.Metadata.Domain.Entities;
namespace Tests.Unit.Application.Setup;

public static class Extensions
{
    private static void SetCommonEntityProps<TEntity>(this TEntity entity) where TEntity : BaseEntity
    {
        entity.UId = Guid.NewGuid();
    }

    public static TEntity SetCommonAuditableEntityProps<TEntity>(this TEntity entity)
        where TEntity : BaseAuditableEntity
    {
        entity.SetCommonEntityProps();
        entity.CreatedAt = DateTime.UtcNow;
        entity.CreatedBy = "TestHarness";
        entity.UpdatedAt = DateTime.UtcNow;
        entity.UpdatedBy = "TestHarness";
        entity.RecordStatus = RecordStatuses.Active;
        return entity;
    }

    public static TDto SetCommonDtoProps<TDto>(this TDto dto , bool newGuid = true) where TDto : BaseDto
    {
        if (newGuid) dto.UId = Guid.NewGuid();
        dto.CreatedAt = DateTime.UtcNow;
        dto.CreatedBy = "TestHarness";
        dto.UpdatedAt = DateTime.UtcNow;
        dto.UpdatedBy = "TestHarness";
        dto.RecordStatus = RecordStatuses.Active;
        return dto;
    }
}