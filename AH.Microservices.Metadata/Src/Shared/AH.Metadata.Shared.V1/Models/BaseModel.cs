namespace AH.Metadata.Shared.V1.Models;

public abstract class BaseModel
{
    public Guid UId { get; set; }
    
}

public abstract class BaseAuditableModel
{
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public string CreatedBy { get; set; } = string.Empty;
    public string UpdatedBy { get; set; } = string.Empty; 
    public string RecordStatus { get; set; } = "Active";
}