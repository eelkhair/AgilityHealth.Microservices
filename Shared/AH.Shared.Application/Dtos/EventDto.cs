namespace AH.Shared.Application.Dtos;

public class EventDto
{
    public EventDto(string userId, object? data )
    {
        UserId = userId;
        Data = data;
    }
    public string UserId { get; set; }
    public object? Data { get; set; }
    public DateTime Created { get; set; } = DateTime.UtcNow;
}