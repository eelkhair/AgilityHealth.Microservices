namespace AH.Team.Application.Dtos;

public class EventDto<T>(string userId, T data)
{
    public string UserId { get; set; } = userId;
    public T Data { get; set; } = data;
    public DateTime Created { get; set; } = DateTime.UtcNow;
}