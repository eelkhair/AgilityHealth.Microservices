namespace AH.Shared.Application.Dtos;

public class BaseDto
{
    public int Id { get; set; }
    public Guid UId { get; set; }
    
    public DateTime CreatedAt { get; set; }
    public string CreatedBy { get; set; } = string.Empty;
    public DateTime? UpdatedAt { get; set; }
    public string UpdatedBy { get; set; } = string.Empty;
    public string RecordStatus { get; set; } = "Active";
}