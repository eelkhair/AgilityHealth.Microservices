using System.Text.Json.Serialization;
using Dapr.Client;
using Dapr.Extensions.Configuration;

namespace AH.User.Api.ProgramExtensions.Dapr;

internal static class DaprServices
{
    public static void RegisterDapr(this IServiceCollection services, ConfigurationManager configuration)
    {
        configuration.AddDaprSecretStore("local-secret-store", new DaprClientBuilder().Build());
        services.AddControllers().AddDapr().AddJsonOptions(x =>
        {
            x.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
        });
    }
}