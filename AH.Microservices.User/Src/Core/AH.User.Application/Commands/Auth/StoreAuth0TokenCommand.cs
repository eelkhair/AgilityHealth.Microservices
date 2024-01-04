using System.Security.Claims;
using System.Text;
using System.Text.Json;
using AH.User.Application.Interfaces;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace AH.User.Application.Commands.Auth;

public class StoreAuth0TokenCommand(ClaimsPrincipal user, ILogger logger) : BaseCommand<Unit>(user, logger);

public class StoreAuth0TokenCommandHandler(IUsersDbContext context, IMapper mapper, IConfiguration configuration)
    : BaseCommandHandler(context, mapper), IRequestHandler<StoreAuth0TokenCommand, Unit>
{

    public IConfiguration Configuration { get; } = configuration;
    public async Task<Unit> Handle(StoreAuth0TokenCommand request, CancellationToken cancellationToken)
    {
        
        var token = await GetToken();
        return Unit.Value;
    }
    
    private  async Task<string> GetToken()
    {
        
        var client = new HttpClient();
        var domain = "eelkhair.us.auth0.com";

        var body = new {
            client_id = "0GQzc9pZxfyXQIqF9XQotwHxYNgxCmnL",
            client_secret = "oYZjI7k3YPtF3_uewCazJ2FnLvc4HSQurSpAwmf5iJfSfyTJ3S9A3-zz_XtZnEKP",
            audience = "https://eelkhair.us.auth0.com/api/v2/",
            grant_type = "client_credentials"
        };
    
        var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
        var content = new StringContent(JsonSerializer.Serialize(body, options), Encoding.UTF8, "application/json");

        var result = await client.PostAsync($"https://{domain}/oauth/token", content);
        var json = await result.Content.ReadAsStringAsync();

        dynamic obj = JsonSerializer.Deserialize<Dictionary<string, object>>(json)!;
        return obj["access_token"].ToString();
    }
}