namespace AH.Shared.Application.Interfaces;

public interface IMessageSender
{
    Task SendEventAsync<T>(string pubSubName, string topic, string userId, T data);
}