using System.Text.Json.Serialization;
using AH.Shared.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace AH.Shared.Api.Dapr;

public static class DaprServices
{
    public static void RegisterDapr(this IServiceCollection services)
    {
        services.AddMessageSender();
        services.AddControllers().AddDapr().AddJsonOptions(x =>
        {
            x.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
        });
    }
}