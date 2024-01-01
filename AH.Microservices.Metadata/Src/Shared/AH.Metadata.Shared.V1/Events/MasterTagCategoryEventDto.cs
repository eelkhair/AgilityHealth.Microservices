using AH.Metadata.Shared.V1.Models.Responses.MasterTagCategories;

namespace AH.Metadata.Shared.V1.Events;

/// <summary>
/// Event DTO for MasterTagCategory
/// </summary>
public class MasterTagCategoryEventDto
{
    public MasterTagCategoryResponse MasterTagCategory { get; set; } = new();
    public string Domain { get; set; } = string.Empty;
}