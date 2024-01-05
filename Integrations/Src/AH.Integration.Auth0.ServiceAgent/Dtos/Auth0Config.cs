namespace AH.Integration.Auth0.ServiceAgent.Dtos;

public record Auth0Config(string Domain, string ClientId, string ClientSecret, string Audience);