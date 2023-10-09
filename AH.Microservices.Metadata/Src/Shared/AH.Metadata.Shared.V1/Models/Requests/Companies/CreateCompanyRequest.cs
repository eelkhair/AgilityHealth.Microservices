using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace AH.Metadata.Shared.V1.Models.Requests.Companies;

/// <summary>
/// Create company request
/// </summary>
[SuppressMessage("ReSharper", "ClassNeverInstantiated.Global")]
[SuppressMessage("ReSharper", "UnusedMember.Global")]
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