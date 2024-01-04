using Microsoft.IdentityModel.Protocols;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.IdentityModel.Tokens;

namespace AH.Company.Api.ProgramExtensions.Authorization;

internal class OpenIdConnectSigningKeyResolver
{
    private readonly OpenIdConnectConfiguration _openIdConfig;

    public OpenIdConnectSigningKeyResolver(string? authority)
    {
        if (authority == null)
        {
            throw new ArgumentNullException(nameof(authority));
        }
        var cm = new ConfigurationManager<OpenIdConnectConfiguration>($"{authority.TrimEnd('/')}/.well-known/openid-configuration", new OpenIdConnectConfigurationRetriever());
        _openIdConfig = cm.GetConfigurationAsync().Result;
    }

    public IEnumerable<SecurityKey?> GetSigningKey(string kid)
    {
        return new[] { _openIdConfig.JsonWebKeySet.GetSigningKeys().FirstOrDefault(t => t.KeyId == kid) };
    }
}