using AH.Integration.Auth0.ServiceAgent.Dtos;
using AH.Integration.Auth0.ServiceAgent.SDK.Resources;
using Microsoft.Extensions.Logging;

namespace AH.Integration.Auth0.ServiceAgent.SDK;

public class ServiceAgentFactory(ILoggerFactory loggerFactory, Auth0Config auth0Config) : IServiceAgentFactory
{
    public IAuth0Resource GetAuth0Resource() => new Auth0Resource(loggerFactory.CreateLogger<Auth0Resource>(), auth0Config);
}