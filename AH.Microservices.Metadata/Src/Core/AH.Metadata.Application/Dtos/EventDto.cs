namespace AH.Metadata.Application.Dtos;

public class EventDto
{
    public EventDto(string userId, string data )
    {
        UserId = userId;
        Data = data;
    }
    public string UserId { get; set; }
    public string Data { get; set; }
    public DateTime Created { get; set; } = DateTime.UtcNow;
}