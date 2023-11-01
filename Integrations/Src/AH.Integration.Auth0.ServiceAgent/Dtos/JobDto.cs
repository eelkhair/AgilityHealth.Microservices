using Newtonsoft.Json;

namespace AH.Integration.Auth0.ServiceAgent.Dtos;

public class JobDto
{
    [JsonProperty("user_id")] public string UserId { get; set; }
    [JsonProperty("client_id")] public string ClientId { get; set; }
    [JsonProperty("identity")] public IdentityDto Identity { get; set; }
    [JsonProperty("organization_id")] public string OrganizationId { get; set; }

    [JsonProperty("status")]public string Status { get; set; }
    [JsonProperty("type")]public string Type { get; set; }
    [JsonProperty("created_at")] public string CreatedAt { get; set; }
    [JsonProperty("id")]public string Id { get; set; }
}

public class JobResultDto
{
    [JsonProperty("status")]public string Status { get; set; }
    [JsonProperty("type")]public string Type { get; set; }
    [JsonProperty("created_at")] public string CreatedAt { get; set; }
    [JsonProperty("id")]public string Id { get; set; }
    [JsonProperty("connection_id")] public string ConnectionId { get; set; }
    public string Location { get; set; }
    [JsonProperty("percentage_done")] public int PercentageDone { get; set; }
    [JsonProperty("time_left_seconds")] public int TimeLeftSeconds { get; set; }
    [JsonProperty("format")] public string Format { get; set; }
}