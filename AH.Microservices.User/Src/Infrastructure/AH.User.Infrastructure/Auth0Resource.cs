using AH.Integration.Auth0.ServiceAgent;
using AH.User.Application.Interfaces;

namespace AH.User.Infrastructure;

public class Auth0Resource(IAuth0Resource auth0Resource) : IAuthResource
{
    public Task<string> GetTokenAsync() => auth0Resource.GetTokenAsync();
}