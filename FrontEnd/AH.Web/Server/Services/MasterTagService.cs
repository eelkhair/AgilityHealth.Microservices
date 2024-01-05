using AH.Metadata.Shared.V1.Models.Responses.MasterTags;
using AH.Web.Server.Services.Interfaces;

namespace AH.Web.Server.Services;

public class MasterTagService : IMasterTagService
{
    private readonly HttpClient _httpClient;

    public MasterTagService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<MasterTagWithCategoryAndParentTagResponse>?> GetMasterTags(Guid masterTagCategoryUId)
        => await _httpClient.Get<MasterTagWithCategoryAndParentTagResponse>(
            $"v1/mastertags/category/{masterTagCategoryUId}");
    
    public async Task<MasterTagWithCategoryAndParentTagResponse> CreateMasterTag(
        MasterTagWithCategoryAndParentTagResponse tag)
        =>
            await _httpClient.Upsert<MasterTagWithCategoryAndParentTagResponse>
            ($"v1/mastertags"
                , tag, false);
    
    public async Task<MasterTagWithCategoryAndParentTagResponse> UpdateMasterTag(
        MasterTagWithCategoryAndParentTagResponse tag)
        => await _httpClient.Upsert<MasterTagWithCategoryAndParentTagResponse>(
            $"v1/mastertags/{tag.UId}",
            tag, true);

    public async Task DeleteMasterTag(Guid uid)
    => await _httpClient.Delete($"v1/mastertags/{uid}");
}