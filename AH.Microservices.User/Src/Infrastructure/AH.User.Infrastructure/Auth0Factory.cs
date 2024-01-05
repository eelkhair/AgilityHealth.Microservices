using AH.Integration.Auth0.ServiceAgent;
using AH.User.Application.Interfaces;

namespace AH.User.Infrastructure;

public class Auth0Factory(IServiceAgentFactory serviceAgentFactory) : IAuthFactory
{
    public IAuthResource CreateAuthResource() => new Auth0Resource(serviceAgentFactory.GetAuth0Resource());
}
