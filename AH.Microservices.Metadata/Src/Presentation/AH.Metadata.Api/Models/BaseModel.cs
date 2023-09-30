namespace AH.Metadata.Api.Models;

/// <summary>
/// 
/// </summary>
public abstract class BaseModel
{
    public Guid UId { get; set; } = Guid.Empty;
}