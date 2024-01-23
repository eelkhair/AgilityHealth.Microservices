using System.Text.Json.Serialization;
using AH.Company.Infrastructure;

namespace AH.Company.Api.ProgramExtensions.Dapr;

internal static class DaprServices
{
    public static void RegisterDapr(this IServiceCollection services)
    {
        services.AddMessageSender();
        services.AddStateManager();
        services.AddControllers().AddDapr().AddJsonOptions(x =>
        {
            x.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
        });
    }
}