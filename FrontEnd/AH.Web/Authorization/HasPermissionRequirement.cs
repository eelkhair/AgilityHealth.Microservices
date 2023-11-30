﻿using Microsoft.AspNetCore.Authorization;

namespace AH.Web.Authorization;

public abstract class HasPermissionRequirement : IAuthorizationRequirement
{
    public string Issuer { get; }
    public string Permission { get; }

    protected HasPermissionRequirement(string permission, string issuer)
    {
        Permission = permission ?? throw new ArgumentNullException(nameof(permission));
        Issuer = issuer ?? throw new ArgumentNullException(nameof(issuer));
    }
}