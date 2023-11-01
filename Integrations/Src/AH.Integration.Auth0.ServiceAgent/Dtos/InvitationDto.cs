using Newtonsoft.Json;

namespace AH.Integration.Auth0.ServiceAgent.Dtos;

public class Invitee
{
    [JsonProperty("email")]
    public string Email { get; set; }
}

public class Inviter
{
    [JsonProperty("name")]
    public string Name { get; set; }
        
}

public class InvitationDto
{
    public InvitationDto()
    {
        SendInvitationEmail = true;
        Inviter = new Inviter {Name = "Fusion Marketplace"};
        TtlSec = 2592000;
        UserMetadata = new Dictionary<string, object>();
        AppMetadata = new AppMetadata();
    }
    [JsonProperty("id")]
    public string Id { get; set; }
    [JsonProperty("inviter")]
    public Inviter Inviter { get; set; }

    [JsonProperty("invitee")]
    public Invitee Invitee { get; set; }

    [JsonProperty("client_id")]
    public string ClientId { get; set; }

    [JsonProperty("connection_id")]
    public string ConnectionId { get; set; }

    [JsonProperty("app_metadata")]
    public AppMetadata AppMetadata { get; set; }

    [JsonProperty("user_metadata")]
    public Dictionary<string, object> UserMetadata { get; set; }

    [JsonProperty("ttl_sec")]
    public int TtlSec { get; set; }

    [JsonProperty("roles")]
    public List<string> Roles { get; set; }

    [JsonProperty("send_invitation_email")]
    public bool SendInvitationEmail { get; set; }
    [JsonIgnore]
    public string Role { get; set; }
}