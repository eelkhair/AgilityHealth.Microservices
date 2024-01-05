namespace AH.Integration.Auth0.ServiceAgent;

public interface IAuth0Resource
{
    Task<string> GetTokenAsync();
}