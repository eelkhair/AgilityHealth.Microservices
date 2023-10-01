namespace AH.Metadata.Api.Models.Domain;

/// <summary>
/// Get Domain View Model
/// </summary>
public class GetDomainViewModel : BaseModel
{
    public string Name { get; set; } = string.Empty;
}