namespace AH.Shared.Api.Dtos;

public class Auth0Configuration
{
    public Auth0Configuration(string? domain, string? audience, string? clientId, string? clientSecret)
    {
        Domain = domain;
        Audience = audience;
        ClientId = clientId;
        ClientSecret = clientSecret;
    }

    public string? Domain { get; }
    public string? Audience { get; }
    public string? ClientId { get;}
    public string? ClientSecret { get;}
}