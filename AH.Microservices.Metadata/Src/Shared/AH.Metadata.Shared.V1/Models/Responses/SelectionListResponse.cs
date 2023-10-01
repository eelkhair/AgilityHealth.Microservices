namespace AH.Metadata.Shared.V1.Models.Responses;

/// <summary>
/// Represents a SelectionListViewModel.
/// </summary>
public class SelectionListResponse
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