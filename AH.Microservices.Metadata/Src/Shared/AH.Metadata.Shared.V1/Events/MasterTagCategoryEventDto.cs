using AH.Metadata.Shared.V1.Models.Responses.MasterTagCategories;

namespace AH.Metadata.Shared.V1.Events;

public class MasterTagCategoryEventDto
{
    public MasterTagCategoryResponse MasterTagCategory { get; set; } = new();
    public string Domain { get; set; } = string.Empty;
}