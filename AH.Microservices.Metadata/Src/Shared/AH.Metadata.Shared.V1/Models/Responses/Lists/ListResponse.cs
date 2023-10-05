namespace AH.Metadata.Shared.V1.Models.Responses.Lists;

/// <summary>
/// Represents a List Response.
/// </summary>
public class ListResponse
{
    /// <summary>
    /// The list of countries.
    /// </summary>
    public List<CountryResponse> Countries { get; set; } = null!;
        
    /// <summary>
    /// The list of industries.
    /// </summary>
    public List<IndustryResponse> Industries { get; set; } = null!;
    
    /// <summary>
    /// The list of survey types.
    /// </summary>
    public List<SurveyTypeResponse> SurveyTypes { get; set; } = null!;
    
    /// <summary>
    /// The list of growth plan statuses.
    /// </summary>
    public List<GrowthPlanStatusResponse> GrowthPlanStatuses { get; set; } = null!;
}