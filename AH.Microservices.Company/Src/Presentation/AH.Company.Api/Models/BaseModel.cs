namespace AH.Company.Api.Models;

public abstract class BaseModel
{
    public Guid UId { get; set; } = Guid.Empty;
}