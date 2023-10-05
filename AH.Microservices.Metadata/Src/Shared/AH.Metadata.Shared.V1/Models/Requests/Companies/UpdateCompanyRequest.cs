using System.ComponentModel.DataAnnotations;

namespace AH.Metadata.Shared.V1.Models.Requests.Companies;

public class UpdateCompanyRequest
{
    /// <summary>
    /// Name of the company
    /// </summary>
    [Required]
    public required string Name { get; set; }
}