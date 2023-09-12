namespace AH.Metadata.Api.Models;

public abstract class BaseModel
{
    public Guid UId { get; set; } = Guid.Empty;
}