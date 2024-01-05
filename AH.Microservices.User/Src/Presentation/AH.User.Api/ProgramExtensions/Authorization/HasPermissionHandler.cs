using Microsoft.AspNetCore.Authorization;

namespace AH.User.Api.ProgramExtensions.Authorization;

internal class HasPermissionHandler : AuthorizationHandler<HasPermissionRequirement>
{
    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, HasPermissionRequirement requirement)
    {
        // If user does not have the permission claim, get out of here
        if (!context.User.HasClaim(c => c.Type == "permission" && c.Issuer == requirement.Issuer))
            return Task.CompletedTask;

        // Get the permissions list
        var permissions = context.User.FindAll(c => c.Type == "permissions" && c.Issuer == requirement.Issuer);

        // Succeed if the permissions array contains the required permission
        if (permissions.Any(s => s.Value == requirement.Permission))
            context.Succeed(requirement);

        return Task.CompletedTask;
    }
}