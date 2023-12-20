using Newtonsoft.Json;

namespace AH.Integration.Auth0.ServiceAgent.Dtos;
public class OptionDto
{
}

public class ConnectionDto(
    string name,
    string displayName,
    string id,
    string strategy,
    List<string> realms,
    List<string> enabledClients)
{
    [JsonProperty("name")]
    public string Name { get; set; } = name;

    [JsonProperty("display_name")]
    public string DisplayName { get; set; } = displayName;

    [JsonProperty("options")]
    public OptionDto Options { get; set; } = new();

    [JsonProperty("id")]
    public string Id { get; set; } = id;

    [JsonProperty("strategy")]
    public string Strategy { get; set; } = strategy;

    [JsonProperty("realms")]
    public List<string> Realms { get; set; } = realms;

    [JsonProperty("enabled_clients")]
    public List<string> EnabledClients { get; set; } = enabledClients;

    [JsonProperty("is_domain_connection")]
    public bool IsDomainConnection { get; set; }

    [JsonProperty("metadata")]
    public MetadataDto Metadata { get; set; } = new();
}

public class MetadataDto
{
}