namespace AH.User.Application.Interfaces;

public interface IAuthResource
{
    Task<string> GetTokenAsync();
}