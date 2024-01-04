using AH.User.Application.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace AH.User.Infrastructure;

public static class DependencyInjection
{
    public static void AddDaprUtility(this IServiceCollection services)
    {
        services.AddSingleton<IDaprUtility, DaprUtility>();
        
        var logger = LoggerFactory.Create(config =>
        {
            config.AddConsole();
            config.AddDebug();
        }).CreateLogger<IDaprUtility>();

        services.AddSingleton(typeof(ILogger), logger);
    }
}