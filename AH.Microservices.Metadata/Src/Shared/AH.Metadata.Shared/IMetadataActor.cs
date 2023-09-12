using System.Security.Claims;
using AH.Metadata.Shared.Models;
using Dapr.Actors;

namespace AH.Metadata.Shared;

public interface IMetadataActor : IActor
{
    Task<DomainDto> GetDomain(Guid domainUId, string user);
    Task<string> SendMessage(string message, string userId);
}

