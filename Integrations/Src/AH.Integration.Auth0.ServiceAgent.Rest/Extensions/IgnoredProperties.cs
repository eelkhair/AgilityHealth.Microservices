namespace AH.Integration.Auth0.ServiceAgent.Rest.Extensions;

public static class IgnoredProperties
{
    public static List<string>? CreateUser()
    {
        return new List<string>
        {
            "picture", "phone_verified", "email_verified", "user_id", "identities", "logins_count", "last_login",
            "last_ip", "multifactor", "updated_at", "created_at", "username", "phone_number"
        };
    }

    public static List<string>? UpdateUser()
    {
        return new List<string>
        {
            "password", "username", "phone_number", "logins_count", "last_login", "last_ip", "multifactor", "created_at", "updated_at", "user_id", "identities", "phone_verified"
        };
    }

    public static List<string>? CreateOrganization()
    {
        return new List<string>
        {
            "id", "BrandingDto:logo_url"
        };
    }

    public static List<string>? InviteMemberToOrganization()
    {
        return new List<string>
        {
            "id", "connection_id"
        };
    }

    public static List<string>? SendUserVerificationEmail(bool ignoreClientId)
    {
        if (ignoreClientId) return new List<string>
        {
            "status", "type", "created_at", "id", "identity", "organization_id", "client_id"
        };

        return new List<string>
        {
            "status", "type", "created_at", "id", "identity", "organization_id"
        };
    }
}