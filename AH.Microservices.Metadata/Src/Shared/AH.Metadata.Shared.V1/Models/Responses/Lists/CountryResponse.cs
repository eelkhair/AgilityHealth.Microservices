namespace AH.Metadata.Shared.V1.Models.Responses.Lists;

/// <summary>
/// Represents a Country.
/// </summary>
public class CountryResponse : BaseResponse
{
    /// <summary>
    /// The name of the country.
    /// </summary>
    public string Name { get; set; } = string.Empty;
    
    /// <summary>
    /// The code of the country.
    /// </summary>
    public string Code { get; set; } = string.Empty;
}
