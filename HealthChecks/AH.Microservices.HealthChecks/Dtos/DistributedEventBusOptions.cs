namespace AH.Microservices.HealthChecks.Dtos;

public class DistributedEventBusOptions
{
    public string PubSubName { get; set; } = default!;
    public string Prefix { get; set; } = default!;
    
    public string Postfix { get; set; } = default!;
}