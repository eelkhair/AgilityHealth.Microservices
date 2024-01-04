namespace AH.Metadata.Api.ProgramExtensions.Dtos;

internal class Auth0Configuration(string? domain, string? audience)
{
    public string? Domain { get; } = domain;
    public string? Audience { get; } = audience;
}