using Microsoft.AspNetCore.Authorization;

namespace AH.Metadata.Api.ProgramExtensions.Authorization;

internal abstract class HasPermissionRequirement(string permission, string issuer) : IAuthorizationRequirement
{
    public string Issuer { get; } = issuer ?? throw new ArgumentNullException(nameof(issuer));
    public string Permission { get; } = permission ?? throw new ArgumentNullException(nameof(permission));
}