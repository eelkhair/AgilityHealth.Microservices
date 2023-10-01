namespace AH.Metadata.Shared.V1.Models.Responses;

/// <summary>
/// Represents a Survey Type.
/// </summary>
public class SurveyTypeResponse : BaseModel
{
    /// <summary>
    /// The name of the survey type.
    /// </summary>
    public string Name { get; set; } = string.Empty;
}