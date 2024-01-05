using AH.Integration.Auth0.ServiceAgent;
using AH.User.Application.Interfaces;

namespace AH.User.Infrastructure;

public class Auth0Resource(IAuth0Resource auth0Resource) : IAuthResource
{
    private readonly IAuth0Resource _auth0Resource = auth0Resource;
    public Task<string> GetTokenAsync() => _auth0Resource.GetTokenAsync();
}