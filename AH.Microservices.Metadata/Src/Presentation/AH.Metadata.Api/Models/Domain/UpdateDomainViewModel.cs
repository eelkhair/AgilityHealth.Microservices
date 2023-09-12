namespace AH.Metadata.Api.Models.Domain;

/// <summary>
/// Update Domain View Model
/// </summary>
public class UpdateDomainViewModel
{
    /// <summary>
    /// Name of the domain
    /// </summary>
    public required string Name { get; set; }

    /// <summary>
    /// Unique identifier of the domain
    /// </summary>
    public required Guid UId { get; set; }
}