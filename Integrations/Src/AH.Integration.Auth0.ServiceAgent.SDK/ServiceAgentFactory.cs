using AH.Integration.Auth0.ServiceAgent.Dtos;
using AH.Integration.Auth0.ServiceAgent.SDK.Resources;
using Microsoft.Extensions.Logging;

namespace AH.Integration.Auth0.ServiceAgent.SDK;

public class ServiceAgentFactory(ILogger logger, Auth0Config auth0Config, string bearerToken) : IServiceAgentFactory
{
    public IAuth0Resource GetAuth0Resource() => new Auth0Resource(logger, auth0Config, bearerToken);
}