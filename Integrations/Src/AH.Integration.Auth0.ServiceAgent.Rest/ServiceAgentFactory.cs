using AH.Integration.Auth0.ServiceAgent.Rest.Resources;
using Microsoft.Extensions.Logging;

namespace AH.Integration.Auth0.ServiceAgent.Rest;

public class ServiceAgentFactory : IServiceAgentFactory
{
    private readonly IWebApiClient _webApiClient;
    private readonly ILoggerFactory _loggerFactory;
    private string ClientId { get; set; }
        
    public ServiceAgentFactory(ILoggerFactory loggerFactory, string baseUrl, string clientId)
    {
        _loggerFactory = loggerFactory;
        _webApiClient = WebApiClientSingleton.GetInstance(baseUrl);
        ClientId = clientId;
    }
        
    public IAuth0Resource GetAuth0Resource() => new Auth0Resource(_loggerFactory.CreateLogger<Auth0Resource>(), _webApiClient);
    public string GetClientId() => ClientId;
}