namespace AH.Metadata.Shared.V1.Models.Responses.Companies;

/// <summary>
/// Represents an Company.
/// </summary>
public class CompanyResponse : BaseResponse
{
    /// <summary>
    /// Company Name
    /// </summary>
    public string Name { get; set; } = string.Empty;
}