using System.Net.Http.Headers;
using AH.Metadata.Shared.V1.Models.Responses.MasterTagCategories;
using AH.Web.Server.Services.Interfaces;

namespace AH.Web.Server.Services;

public class MasterTagCategoryService : IMasterTagCategoryService
{
    private readonly HttpClient _httpClient;

    public MasterTagCategoryService(HttpClient httpClient, IHttpContextAccessor httpContextAccessor)
    {
        _httpClient = httpClient;
        var token = httpContextAccessor.HttpContext?.Request.Headers["Authorization"].ToString() ?? string.Empty;
        _httpClient.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Bearer", token.Replace("Bearer ", string.Empty));
    }

    public async Task<List<MasterTagCategoryResponse>> GetMasterTagCategories() =>
        await _httpClient.Get<MasterTagCategoryResponse>("v1/mastertagcategories");

    public async Task<MasterTagCategoryResponse> CreateMasterTagCategory(MasterTagCategoryResponse category)
    {
        var response =  await _httpClient.Upsert<MasterTagCategoryResponse>
                ($"v1/mastertagcategories?Name={category.Name}&ClassName={category.ClassName}&Type={category.Type}",
                    category, false);
        return response;
    }
        

    public async Task<MasterTagCategoryResponse> UpdateMasterTagCategory(MasterTagCategoryResponse category) =>
        await _httpClient.Upsert<MasterTagCategoryResponse>
        ($"v1/mastertagcategories/{category.UId}?Name={category.Name}&ClassName={category.ClassName}&Type={category.Type}",
            category, true);

    public async Task DeleteMasterTagCategory(Guid uid) =>
        await _httpClient.Delete($"v1/mastertagcategories/{uid}");
}