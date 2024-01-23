using AH.Company.Application.Interfaces;
using Dapr.Client;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace AH.Company.Infrastructure;

public static class DependencyInjection
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        // Method intentionally left empty.
    }
     
    public static void AddMessageSender(this IServiceCollection services)
    {
        services.AddLogging();
        services.AddTransient<IMessageSender, MessageSender>( sp =>
        {
            var logger = sp.GetRequiredService<ILogger<MessageSender>>();
            var client = new DaprClientBuilder().Build();
            
            return new MessageSender(logger, client);
        });
    }
    
    public static void AddStateManager(this IServiceCollection services)
    {
        services.AddLogging();
        services.AddTransient<IStateManager, StateManager>( sp =>
        {
            var logger = sp.GetRequiredService<ILogger<StateManager>>();
            var client = new DaprClientBuilder().Build();
            
            return new StateManager(logger, client);
        });
    }
}