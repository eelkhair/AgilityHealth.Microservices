using AH.Metadata.Shared.V1.Models.Responses;
using Dapr.Actors;

namespace AH.Metadata.Shared.V1.ActorInterfaces;
public interface ISelectionListsActor : IActor
{
    Task<SelectionListResponse> GetSelectionLists(List<string> types, string userId);
}