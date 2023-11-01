using Newtonsoft.Json;

namespace AH.Integration.Auth0.ServiceAgent.Dtos;

public class UserLogDto
{
    [JsonProperty("user_id")]
    public string UserId { get; set; }
    [JsonProperty("user_agent")]
    public string UserAgent { get; set; }
    [JsonProperty("isMobile")]
    public bool IsMobile { get; set; }
    [JsonProperty("date")]
    public DateTime LoginDate { get; set; }
}