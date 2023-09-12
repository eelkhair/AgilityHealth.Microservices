using AH.Shared.Application.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace AH.Shared.Infrastructure;

public static class DependencyInjection
{
    public static void AddMessageSender(this IServiceCollection services, IConfiguration configuration)
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