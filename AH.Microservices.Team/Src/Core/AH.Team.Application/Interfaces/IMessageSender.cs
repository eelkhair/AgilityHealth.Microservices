namespace AH.Team.Application.Interfaces;

public interface IMessageSender
{
    Task SendEventAsync(string pubSubName, string topic, string userId, string message);
}