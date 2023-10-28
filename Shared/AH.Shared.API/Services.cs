using AH.Shared.Api.Authorization;
using AH.Shared.Api.Dapr;
using AH.Shared.Api.Dtos;
using AH.Shared.Api.Swagger;
using AH.Shared.Application.Logging;
using Microsoft.Extensions.DependencyInjection;

namespace AH.Shared.Api; 
public static class Services
{
    public static void Build(this IServiceCollection services, SwaggerDocSetup swagger, Auth0Configuration auth0Config)
    {
        // var path = Directory.GetParent(Directory.GetCurrentDirectory()) + "\\Shared\\appsettings.shared.json";
        // configuration.AddJsonFile(path, true, true);
        services.RegisterSwagger(swagger, auth0Config);
        services.RegisterAuth0(auth0Config, swagger);
        services.RegisterDapr();
        services.AddCorrelationIdService();
        services.AddApplicationInsightsTelemetry().AddCorrelationIdService();
    }
}