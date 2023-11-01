using Newtonsoft.Json;

namespace AH.Integration.Auth0.ServiceAgent.Dtos;

public class IdentityDto
{
    public string Connection { get; set; }
    public string Provider { get; set; }
    [JsonProperty("user_id")]
    public string UserId { get; set; }
    public bool IsSocial { get; set; }
}