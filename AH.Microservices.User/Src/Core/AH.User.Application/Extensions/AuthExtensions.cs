using System.Security.Claims;

namespace AH.User.Application.Extensions;

public static class AuthExtensions
{
    public static string GetUserId (this ClaimsPrincipal user) 
    {
        return user.Claims.Where(c => c.Type == ClaimTypes.NameIdentifier).Select(x=>x.Value).FirstOrDefault() ?? "N/A";
    }
}