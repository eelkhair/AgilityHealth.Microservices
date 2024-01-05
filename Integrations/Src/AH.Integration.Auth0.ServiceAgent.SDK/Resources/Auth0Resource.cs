using System.Text;
using System.Text.Json;
using AH.Integration.Auth0.ServiceAgent.Dtos;
using Microsoft.Extensions.Logging;

namespace AH.Integration.Auth0.ServiceAgent.SDK.Resources;

public class Auth0Resource(ILogger<Auth0Resource> logger, Auth0Config config) : IAuth0Resource
{
    private Auth0Config Config { get; } = config;
    
    public async Task<string> GetTokenAsync()
    {
        logger.LogInformation("Getting token from Auth0");
        var client = new HttpClient();
        var domain = Config.Domain;

        var body = new {
            client_id = Config.ClientId,
            client_secret = Config.ClientSecret,
            audience = Config.Audience,
            grant_type = "client_credentials"
        };
    
        var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
        var content = new StringContent(JsonSerializer.Serialize(body, options), Encoding.UTF8, "application/json");

        var result = await client.PostAsync($"{domain}oauth/token", content);
        var json = await result.Content.ReadAsStringAsync();

        dynamic obj = JsonSerializer.Deserialize<Dictionary<string, object>>(json)!;
        return obj["access_token"].ToString();
    }
}