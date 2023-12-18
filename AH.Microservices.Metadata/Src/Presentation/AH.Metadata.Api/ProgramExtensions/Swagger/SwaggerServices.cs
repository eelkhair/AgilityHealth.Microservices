using System.Reflection;
using AH.Metadata.Api.ProgramExtensions.Dtos;
using AH.Metadata.Domain.Constants;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;

namespace AH.Metadata.Api.ProgramExtensions.Swagger;

internal static class SwaggerServices
{
    public static void RegisterSwagger(this WebApplicationBuilder builder, string appName, string appTag)
    {
        var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
        var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFilename);
        
        var swaggerConfig = new SwaggerDocSetup(appName, appTag , PermissionDefinitions.GetPermissions(), xmlPath);
        var auth0Config = new Auth0Configuration(
            builder.Configuration["Auth0:Domain"],
            builder.Configuration["Auth0:Audience"]
        );
        builder.Services.AddEndpointsApiExplorer();
        var domain = auth0Config.Domain;
        var audience = auth0Config.Audience;
        
        builder.Services.AddSwaggerGen(setup =>
        {
            setup.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = swaggerConfig.AppName,
                Version = "v1",
            });

            setup.DocumentFilter<LowercaseDocumentFilter>();
            setup.DocumentFilter<JsonPatchDocumentFilter>();
            setup.EnableAnnotations();
            var scopes = new Dictionary<string, string>
            {
                { "openid", "Open Id" },
                { "profile", "Profile" }
            };
            foreach (var item in swaggerConfig.Permissions )
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
           
            setup.IncludeXmlComments(swaggerConfig.XmlCommentsPath);
            setup.ExampleFilters();
        });
        
        builder.Services.AddSwaggerExamplesFromAssemblies(Assembly.GetExecutingAssembly());
    } 
}