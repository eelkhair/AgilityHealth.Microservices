using AH.Integration.Auth0.ServiceAgent;
using AH.Integration.Auth0.ServiceAgent.Dtos;
using AH.Integration.Auth0.ServiceAgent.SDK;
using AH.User.Application.Dtos;
using AH.User.Application.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace AH.User.Infrastructure;

public static class DependencyInjection
{

    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDaprUtility();
        services.AddAuth0ServiceAgent(configuration);
    }

    private static void AddDaprUtility(this IServiceCollection services)
    {
        services.AddSingleton<IDaprUtility, DaprUtility>();

        var logger = LoggerFactory.Create(config =>
        {
            config.AddConsole();
            config.AddDebug();
        }).CreateLogger<IDaprUtility>();

        services.AddSingleton(typeof(ILogger), logger);
    }
    
    private static void AddAuth0ServiceAgent(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddTransient<IServiceAgentFactory, ServiceAgentFactory>(p =>
        {
            var logger = p.GetService<ILoggerFactory>()?.CreateLogger<ServiceAgentFactory>()!;
            
            var daprUtility = p.GetService<IDaprUtility>();
            
            var token = daprUtility!.GetStateAsync<TokenDto>("statestore.redis", "auth0token", CancellationToken.None).Result;
            
            var auth0Config = new Auth0Config(configuration["Auth0:Domain"] ?? string.Empty,
                configuration["Auth0:ApiClientId"] ?? string.Empty,
                configuration["Auth0:ApiClientSecret"] ?? string.Empty, 
                configuration["Auth0:ApiAudience"] ?? string.Empty);
            return new ServiceAgentFactory(logger, auth0Config, token.Token);

        });
        services.AddSingleton<IAuthFactory, Auth0Factory>();
    }


}