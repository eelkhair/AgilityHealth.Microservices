namespace AH.Company.Application.Interfaces;

public interface IMessageSender
{
    Task SendEventAsync<T>(string topic, string userId, T message);
}