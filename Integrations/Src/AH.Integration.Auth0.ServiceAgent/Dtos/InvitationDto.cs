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

public class InvitationDto(
    string id,
    Invitee invitee,
    string clientId,
    string connectionId,
    List<string> roles,
    string role)
{
    [JsonProperty("id")]
    public string Id { get; set; } = id;

    [JsonProperty("inviter")]
    public Inviter Inviter { get; set; } = new() {Name = "Fusion Marketplace"};

    [JsonProperty("invitee")]
    public Invitee Invitee { get; set; } = invitee;

    [JsonProperty("client_id")]
    public string ClientId { get; set; } = clientId;

    [JsonProperty("connection_id")]
    public string ConnectionId { get; set; } = connectionId;

    [JsonProperty("app_metadata")]
    public AppMetadata AppMetadata { get; set; } = new();

    [JsonProperty("user_metadata")]
    public Dictionary<string, object> UserMetadata { get; set; } = new();

    [JsonProperty("ttl_sec")]
    public int TtlSec { get; set; } = 2592000;

    [JsonProperty("roles")]
    public List<string> Roles { get; set; } = roles;

    [JsonProperty("send_invitation_email")]
    public bool SendInvitationEmail { get; set; } = true;

    [JsonIgnore]
    public string Role { get; set; } = role;
}