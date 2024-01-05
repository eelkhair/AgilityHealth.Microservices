﻿using AH.User.Domain.Constants;

namespace AH.User.Domain.Entities;

public abstract class BaseAuditableEntity : BaseEntity
{
    public DateTime CreatedAt { get; set; }
    public string CreatedBy { get; set; } = string.Empty;
    public DateTime? UpdatedAt { get; set; }
    public string UpdatedBy { get; set; } = string.Empty;
    public string RecordStatus { get; set; } = RecordStatuses.Active;
}