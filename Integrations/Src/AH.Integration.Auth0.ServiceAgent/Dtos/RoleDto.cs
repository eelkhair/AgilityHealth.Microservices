using Newtonsoft.Json;

namespace AH.Integration.Auth0.ServiceAgent.Dtos;

public class PostRoleDto
{
    [JsonProperty("roles")]
    public List<string> Roles { get; set; }
}

public class GetRoleDto
{
    [JsonProperty("id")]
    public string Id { get; set; }
    [JsonProperty("name")]
    public string Name { get; set; }
    [JsonProperty("description")]
    public string Description { get; set; }
}