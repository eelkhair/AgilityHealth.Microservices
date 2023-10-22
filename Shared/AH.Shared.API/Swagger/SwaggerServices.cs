using System.Reflection;
using AH.Shared.Api.Dtos;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;

namespace AH.Shared.Api.Swagger;

public static class SwaggerServices
{
    public static void RegisterSwagger(this IServiceCollection services, SwaggerDocSetup doc, Auth0Configuration auth0Configuration)
    {
        services.AddEndpointsApiExplorer();
        var domain = auth0Configuration.Domain;
        var audience = auth0Configuration.Audience;
        services.AddSwaggerGen(setup =>
        {
            setup.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = doc.AppName,
                Version = "v1"
            });

            setup.DocumentFilter<LowercaseDocumentFilter>();
            setup.DocumentFilter<JsonPatchDocumentFilter>();
            setup.EnableAnnotations();
            var scopes = new Dictionary<string, string>
            {
                { "openid", "Open Id" },
                { "profile", "Profile" }
            };
            foreach (var item in doc.Permissions )
            {
                scopes.Add(item.Key, item.Value);
            }
            setup.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
            {
                //Name = "Authorization",
                //In = ParameterLocation.Header,
                Type = SecuritySchemeType.OAuth2,
                Flows = new OpenApiOAuthFlows
                {
                    Implicit = new OpenApiOAuthFlow
                    {
                        Scopes = scopes,
                        AuthorizationUrl = new Uri($"{domain}authorize?audience={audience}"),
                        TokenUrl = new Uri($"https://{domain}oauth/token")
                    }
                }
            });
            setup.OperationFilter<SecurityRequirementsOperationFilter>();
           
            setup.IncludeXmlComments(doc.XmlCommentsPath);
            setup.ExampleFilters();
        });
        
        services.AddSwaggerExamplesFromAssemblies(Assembly.GetExecutingAssembly());
    } 
}