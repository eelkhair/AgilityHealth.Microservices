using Newtonsoft.Json;

namespace AH.Integration.Auth0.ServiceAgent.Dtos;
public class OptionDto
{
}

public class ConnectionDto
{
    public ConnectionDto()
    {
        Options = new OptionDto();
        Metadata = new MetadataDto();
    }
    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("display_name")]
    public string DisplayName { get; set; }

    [JsonProperty("options")]
    public OptionDto Options { get; set; }

    [JsonProperty("id")]
    public string Id { get; set; }

    [JsonProperty("strategy")]
    public string Strategy { get; set; }

    [JsonProperty("realms")]
    public List<string> Realms { get; set; }

    [JsonProperty("enabled_clients")]
    public List<string> EnabledClients { get; set; }

    [JsonProperty("is_domain_connection")]
    public bool IsDomainConnection { get; set; }

    [JsonProperty("metadata")]
    public MetadataDto Metadata { get; set; }
}

public class MetadataDto
{
}