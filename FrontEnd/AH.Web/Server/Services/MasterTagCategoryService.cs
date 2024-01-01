using AH.Metadata.Shared.V1.Models.Responses.MasterTagCategories;
using AH.Web.Server.Services.Interfaces;

namespace AH.Web.Server.Services;

public class MasterTagCategoryService : IMasterTagCategoryService
{
    private readonly HttpClient _httpClient;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public MasterTagCategoryService(HttpClient httpClient, IHttpContextAccessor httpContextAccessor)
    {
        _httpClient = httpClient;
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<List<MasterTagCategoryResponse>> GetMasterTagCategories() =>
        await _httpClient.Get<MasterTagCategoryResponse>("v1/mastertagcategories", _httpContextAccessor);

    public async Task<MasterTagCategoryResponse> CreateMasterTagCategory(MasterTagCategoryResponse category)
    {
        var response = await _httpClient.Upsert<MasterTagCategoryResponse>
        ($"v1/mastertagcategories?Name={category.Name}&ClassName={category.ClassName}&Type={category.Type}",
            category, false, _httpContextAccessor);
        return response;
    }


    public async Task<MasterTagCategoryResponse> UpdateMasterTagCategory(MasterTagCategoryResponse category) =>
        await _httpClient.Upsert<MasterTagCategoryResponse>
        ($"v1/mastertagcategories/{category.UId}?Name={category.Name}&ClassName={category.ClassName}&Type={category.Type}",
            category, true, _httpContextAccessor);

    public async Task DeleteMasterTagCategory(Guid uid) =>
        await _httpClient.Delete($"v1/mastertagcategories/{uid}", _httpContextAccessor);
}