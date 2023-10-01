using AH.Metadata.Shared.V1.Models.Responses;
using Dapr.Actors;

namespace AH.Metadata.Shared.V1.ActorInterfaces;

public interface IMetadataActor : IActor
{
    Task<DomainResponse> GetDomain(Guid domainUId, string user);
    Task<string> SendMessage(string message, string userId);
}

