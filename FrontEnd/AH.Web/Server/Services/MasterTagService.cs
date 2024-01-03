using AH.Metadata.Shared.V1.Models.Responses.MasterTags;
using AH.Web.Server.Services.Interfaces;

namespace AH.Web.Server.Services;

public class MasterTagService : IMasterTagService
{
    private readonly HttpClient _httpClient;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public MasterTagService(HttpClient httpClient, IHttpContextAccessor httpContextAccessor)
    {
        _httpClient = httpClient;
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<List<MasterTagWithCategoryAndParentTagResponse>?> GetMasterTags(Guid masterTagCategoryUId)
        => await _httpClient.Get<MasterTagWithCategoryAndParentTagResponse>(
            $"v1/mastertags/category/{masterTagCategoryUId}", _httpContextAccessor);
    
    public async Task<MasterTagWithCategoryAndParentTagResponse> CreateMasterTag(
        MasterTagWithCategoryAndParentTagResponse tag)
        =>
            await _httpClient.Upsert<MasterTagWithCategoryAndParentTagResponse>
            ($"v1/mastertags"
                , tag, false, _httpContextAccessor);
    
    public async Task<MasterTagWithCategoryAndParentTagResponse> UpdateMasterTag(
        MasterTagWithCategoryAndParentTagResponse tag)
        => await _httpClient.Upsert<MasterTagWithCategoryAndParentTagResponse>(
            $"v1/mastertags/{tag.UId}",
            tag, true, _httpContextAccessor);

    public async Task DeleteMasterTag(Guid uid)
    => await _httpClient.Delete($"v1/mastertags/{uid}", _httpContextAccessor);
}