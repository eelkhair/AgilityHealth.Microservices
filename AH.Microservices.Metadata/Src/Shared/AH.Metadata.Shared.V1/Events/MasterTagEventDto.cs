using AH.Metadata.Shared.V1.Models.Responses.MasterTags;

namespace AH.Metadata.Shared.V1.Events;

public class MasterTagEventDto
{
    public MasterTagResponse MasterTag{ get; set; } = new();
    public string Domain { get; set; } = string.Empty;
}