using AH.Metadata.Shared.V1.Models.Responses.MasterTagCategories;
using AH.Web.Server.Services.Interfaces.CategoriesAndTags;

namespace AH.Web.Server.Services.Implementations.CategoriesAndTags;

public class MasterTagCategoryService : IMasterTagCategoryService
{
    private readonly HttpClient _httpClient;

    public MasterTagCategoryService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<MasterTagCategoryResponse>> GetMasterTagCategories() =>
        await _httpClient.GetList<MasterTagCategoryResponse>("v1/mastertagcategories");

    public async Task<MasterTagCategoryResponse> CreateMasterTagCategory(MasterTagCategoryResponse category)
    {
        var response = await _httpClient.Upsert<MasterTagCategoryResponse>
        ($"v1/mastertagcategories",
            category, false);
        return response;
    }


    public async Task<MasterTagCategoryResponse> UpdateMasterTagCategory(MasterTagCategoryResponse category) =>
        await _httpClient.Upsert<MasterTagCategoryResponse>
        ($"v1/mastertagcategories/{category.UId}",
            category, true);

    public async Task DeleteMasterTagCategory(Guid uid) =>
        await _httpClient.Delete($"v1/mastertagcategories/{uid}");
}