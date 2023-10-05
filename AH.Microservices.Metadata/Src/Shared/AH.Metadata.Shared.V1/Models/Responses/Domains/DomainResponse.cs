namespace AH.Metadata.Shared.V1.Models.Responses.Domains;

/// <summary>
/// Represents an Domain.
/// </summary>
public class DomainResponse : BaseModel
{
    /// <summary>
    /// Domain Name
    /// </summary>
    public required string Name { get; set; }
}
