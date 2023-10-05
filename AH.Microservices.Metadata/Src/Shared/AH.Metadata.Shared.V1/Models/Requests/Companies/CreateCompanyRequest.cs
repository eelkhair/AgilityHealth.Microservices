using System.ComponentModel.DataAnnotations;

namespace AH.Metadata.Shared.V1.Models.Requests.Companies;

public class CreateCompanyRequest
{
    /// <summary>
    /// Name of the company
    /// </summary>
    [Required]
    public required string Name { get; set; }

    /// <summary>
    /// The UId of the domain
    /// </summary>
    [Required]
    public required Guid DomainUId { get; set; }
}