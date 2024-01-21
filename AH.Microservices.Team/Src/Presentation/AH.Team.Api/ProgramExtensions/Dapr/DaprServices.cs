using System.Text.Json.Serialization;
using AH.Team.Infrastructure;

namespace AH.Team.Api.ProgramExtensions.Dapr;

internal static class DaprServices
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