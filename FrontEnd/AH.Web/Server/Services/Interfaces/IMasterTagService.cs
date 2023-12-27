using AH.Metadata.Shared.V1.Models.Requests.Tags;
using AH.Metadata.Shared.V1.Models.Responses.MasterTags;

namespace AH.Web.Server.Services.Interfaces;

public interface IMasterTagService
{
    Task<List<MasterTagResponse>?> GetMasterTags(Guid masterTagCategoryUId);
    Task<MasterTagWithCategoryAndParentTagResponse> CreateMasterTag(MasterTagWithCategoryAndParentTagResponse tag);
    Task<MasterTagWithCategoryAndParentTagResponse> UpdateMasterTag(Guid masterTagUId,MasterTagRequest tag);
    Task DeleteMasterTag(Guid uid);
}