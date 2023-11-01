using Newtonsoft.Json;

namespace AH.Integration.Auth0.ServiceAgent.Dtos;

public class OrganizationDto
{
    public OrganizationDto()
    {
        EnabledConnections = new List<object>();
        Metadata = new Dictionary<string, object>();
    }
    [JsonProperty("id")]
    public string Id { get; set; }
    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("display_name")]
    public string DisplayName { get; set; }

    [JsonProperty("branding")]
    public BrandingDto Branding { get; set; }

    [JsonProperty("metadata")]
    public Dictionary<string, object> Metadata { get; set; }

    [JsonProperty("enabled_connections")]
    public List<object> EnabledConnections { get; set; }
}
public class BrandingDto
{
    [JsonProperty("logo_url")]
    public string LogoUrl { get; set; }

    [JsonProperty("colors")]
    public ColorsDto Colors { get; set; }
}

public class ColorsDto
{
    [JsonProperty("primary")]
    public string Primary { get; set; }

    [JsonProperty("page_background")]
    public string PageBackground { get; set; }
}