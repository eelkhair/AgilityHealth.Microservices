using AH.Shared.Application.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace AH.Shared.Application.Logging;

public static class DependencyInjection
{
    public static IServiceCollection AddCorrelationIdService(this IServiceCollection services)
    {
        services.AddScoped<ICorrelationId, CorrelationId>();

        return services;
    }
}