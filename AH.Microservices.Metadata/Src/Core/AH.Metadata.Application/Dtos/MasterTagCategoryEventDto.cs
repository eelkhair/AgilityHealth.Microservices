namespace AH.Metadata.Application.Dtos;

public class MasterTagCategoryEventDto
{
    public string EventType { get; set; } = string.Empty;
    public MasterTagCategoryDto MasterTagCategory { get; set; } = new();
    public string Domain { get; set; }
}