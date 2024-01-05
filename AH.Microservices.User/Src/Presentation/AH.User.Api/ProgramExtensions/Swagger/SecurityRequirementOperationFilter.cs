using Microsoft.AspNetCore.Authorization;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace AH.User.Api.ProgramExtensions.Swagger;
// ReSharper disable once ClassNeverInstantiated.Global
internal  class SecurityRequirementsOperationFilter : IOperationFilter
{
    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    {
        if (context.MethodInfo.DeclaringType != null &&
            (context.MethodInfo.GetCustomAttributes(true).Any(x => x is AuthorizeAttribute) 
            || context.MethodInfo.DeclaringType.GetCustomAttributes(true).Any(x => x is AuthorizeAttribute)) &&
            !context.MethodInfo.GetCustomAttributes(true).Any(x => x is AllowAnonymousAttribute) &&
            !context.MethodInfo.DeclaringType.GetCustomAttributes(true).Any(x => x is AllowAnonymousAttribute)) {
            operation.Security = new List < OpenApiSecurityRequirement > {
                new()
                {
                    {
                        new OpenApiSecurityScheme {
                            Reference = new OpenApiReference {
                                Type = ReferenceType.SecurityScheme,
                                Id = "oauth2"
                            }
                        }, new string[] {}
                    }
                }
            };
        }

    }
}