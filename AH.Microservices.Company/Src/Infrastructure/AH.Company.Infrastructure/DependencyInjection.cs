using AH.Company.Application.Interfaces;
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
        services.AddSingleton<IMessageSender, MessageSender>();
        
        var logger = LoggerFactory.Create(config =>
        {
            config.AddConsole();
            config.AddDebug();
        }).CreateLogger<IMessageSender>();

        services.AddSingleton(typeof(ILogger), logger);
    }
}