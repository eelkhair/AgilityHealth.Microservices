using AH.Shared.Application.Dtos;
using AH.Shared.Domain.Constants;
using AH.Shared.Domain.Entities;

namespace Tests.Unit.Application.Setup;

public static class Extensions
{
    public static TEntity SetCommonEntityProps<TEntity>(this TEntity entity) where TEntity : BaseEntity
    {
        entity.UId = Guid.NewGuid();
        return entity;
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

    public static TDto SetCommonDtoProps<TDto>(this TDto dto) where TDto : BaseDto
    {
        dto.UId = Guid.NewGuid();
        dto.CreatedAt = DateTime.UtcNow;
        dto.CreatedBy = "TestHarness";
        dto.UpdatedAt = DateTime.UtcNow;
        dto.UpdatedBy = "TestHarness";
        dto.RecordStatus = RecordStatuses.Active;
        return dto;
    }
}