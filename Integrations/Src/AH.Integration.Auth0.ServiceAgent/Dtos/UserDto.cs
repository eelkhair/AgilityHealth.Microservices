using Newtonsoft.Json;

namespace AH.Integration.Auth0.ServiceAgent.Dtos;

public class UserDto
{
    public UserDto()
    {
        Connection = "Username-Password-Authentication";
        UserMetadata = new Dictionary<string, object>();
        AppMetadata = new AppMetadata();
    }
    [JsonProperty("user_id")]
    public string UserId { get; set; }

    [JsonProperty("email")]
    public string Email { get; set; }

    [JsonProperty("email_verified")]
    public bool EmailVerified { get; set; }

    [JsonProperty("username")]
    public string Username { get; set; }

    [JsonProperty("phone_number")]
    public string PhoneNumber { get; set; }

    [JsonProperty("phone_verified")]
    public bool PhoneVerified { get; set; }

    [JsonProperty("created_at")]
    public string CreatedAt { get; set; }

    [JsonProperty("updated_at")]
    public string UpdatedAt { get; set; }

    [JsonProperty("identities")]
    public List<IdentityDto> Identities { get; set; }

    [JsonProperty("app_metadata")]
    public AppMetadata AppMetadata { get; set; }

    [JsonProperty("user_metadata")]
    public Dictionary<string, object> UserMetadata { get; set; }

    [JsonProperty("picture")]
    public string Picture { get; set; }

    [JsonProperty("name")]
    public string Name => GivenName + " " + FamilyName;

    [JsonProperty("nickname")]
    public string Nickname { get; set; }

    [JsonProperty("multifactor")]
    public List<string> Multifactor { get; set; }

    [JsonProperty("last_ip")]
    public string LastIp { get; set; }

    [JsonProperty("last_login")]
    public string LastLogin { get; set; }

    [JsonProperty("logins_count")]
    public int LoginsCount { get; set; }

    [JsonProperty("blocked")]
    public bool Blocked { get; set; }

    [JsonProperty("given_name")]
    public string GivenName { get; set; }

    [JsonProperty("family_name")]
    public string FamilyName { get; set; }

    [JsonProperty("password")]
    public string Password {get; set;}
    [JsonProperty("verify_email")]
    public bool VerifyEmail { get; set; }
    [JsonProperty("connection")]
    public string Connection { get; set; }
}
public class AppMetadata
{
}