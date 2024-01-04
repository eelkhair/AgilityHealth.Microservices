using System.Security.Claims;
using AH.Company.Application.Exceptions;
using AH.Company.Domain.Constants;
using AH.Metadata.Api.ProgramExtensions.Dtos;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;

namespace AH.Company.Api.ProgramExtensions.Authorization;

internal static class AuthorizationServices
{

    public static void RegisterAuth0(this WebApplicationBuilder builder)
    {
        var auth0Config = new Auth0Configuration(
            builder.Configuration["Auth0:Domain"],
            builder.Configuration["Auth0:Audience"]
        );
        var domain = auth0Config.Domain;
        var audience = auth0Config.Audience;
        
        builder.Services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = "Auth0";
            options.DefaultChallengeScheme = "Auth0";
        })
        .AddJwtBearer("Auth0", options =>
        {
            var keyResolver = new OpenIdConnectSigningKeyResolver(domain);
            options.Audience = audience;
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidAudience = audience,
                ValidIssuer = domain,
                ValidateIssuer = true,
                ValidateAudience = true,
                IssuerSigningKeyResolver = (_, _, kid, _) =>
                    keyResolver.GetSigningKey(kid)
            };
            options.Events = new JwtBearerEvents()
            {
                OnAuthenticationFailed = context =>
                {
                    Console.WriteLine(context);
                    return Task.CompletedTask;
                },
                OnTokenValidated = context =>
                {
                    var accessToken = (JsonWebToken) context.SecurityToken;
                    var client = context.HttpContext.RequestServices.GetService<IHttpClientFactory>()!.CreateClient();
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessToken.EncodedToken);
                    foreach (var item in accessToken.Claims.Where(y =>
                                 y.Type == ClaimTypes.Role && y.Issuer == domain))
                    {
                        ((ClaimsIdentity) context.Principal?.Identity!).AddClaim(new Claim(ClaimTypes.Role,
                            item.Value));
                    }
                    return Task.CompletedTask;
                }
            };
        });
        IdentityModelEventSource.ShowPII = true;
        builder.Services.AddHttpClient();

        var permissions = PermissionDefinitions.GetPermissions();
        builder.Services.AddAuthorization(options => permissions.ToList().ForEach(permission =>
        {
            if (!permissions.ContainsKey(permission.Key))
                throw new UnauthorizedException("The permission " + permission + " doesn't have any scopes");
            options.AddPolicy(permission.Key.ToString(), p =>
            {
                p.RequireAuthenticatedUser();
                var permission1 = permissions[permission.Key];
                p.RequireClaim("permissions", permission1);
            });
        }));
    }
    
}

