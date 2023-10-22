using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using AH.Shared.Api.Dtos;
using AH.Shared.Application.Exceptions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;

namespace AH.Shared.Api.Authorization;

public static class AuthorizationServices
{
    public static void RegisterAuth0(this IServiceCollection services, Auth0Configuration auth0Config, SwaggerDocSetup swagger)
    {
        var domain = auth0Config.Domain;
        var audience = auth0Config.Audience;
        services.AddAuthentication(options =>
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
                    var accessToken = (JwtSecurityToken) context.SecurityToken;
                    var client = context.HttpContext.RequestServices.GetService<IHttpClientFactory>()!.CreateClient();
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessToken.RawData);
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
        services.AddHttpClient();
        
        services.AddAuthorization(options => swagger.Permissions.ToList().ForEach(permission =>
        {
            if (!swagger.Permissions.ContainsKey(permission.Key))
                throw new UnauthorizedException("The permission " + permission.ToString() + " doesn't have any scopes");
            options.AddPolicy(permission.Key.ToString(), p =>
            {
                p.RequireAuthenticatedUser();
                string permission1 = swagger.Permissions[permission.Key];
                p.RequireClaim("permissions", permission1);
            });
        }));
    }
    
}

