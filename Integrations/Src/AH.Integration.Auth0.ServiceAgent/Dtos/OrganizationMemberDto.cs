using Newtonsoft.Json;

namespace AH.Integration.Auth0.ServiceAgent.Dtos;

public class OrganizationMemberDto
{
    [JsonProperty("members")]
    public List<string> Members { get; set; }
}