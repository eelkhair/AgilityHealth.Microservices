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
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.Replace("Bearer ", string.Empty));
    }
    public async Task<List<MasterTagCategoryResponse>> GetMasterTagCategories()
    {
        var response = await _httpClient.GetAsync("v1/mastertagcategories");
        
        return await response.Content.ReadFromJsonAsync<List<MasterTagCategoryResponse>>() ?? new List<MasterTagCategoryResponse>();
    }
    

    public async Task<MasterTagCategoryResponse> CreateMasterTagCategory(MasterTagCategoryResponse category)
    {
        var request = new HttpRequestMessage(HttpMethod.Post, $"v1/mastertagcategories?Name={category.Name}&ClassName={category.ClassName}&Type={category.Type}");
        request.Headers.Add("Accept", "text/plain");
        var response = await _httpClient.SendAsync(request);
       
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<MasterTagCategoryResponse>() ?? new MasterTagCategoryResponse();
    }
    
    public async Task<MasterTagCategoryResponse> UpdateMasterTagCategory(MasterTagCategoryResponse category)
    {
        var request = new HttpRequestMessage(HttpMethod.Put, $"v1/mastertagcategories/{category.UId}?Name={category.Name}&ClassName={category.ClassName}&Type={category.Type}");
        var response = await _httpClient.SendAsync(request);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<MasterTagCategoryResponse>() ?? new MasterTagCategoryResponse();
    }
    
    public async Task DeleteMasterTagCategory(Guid uid)
    {
        var request = new HttpRequestMessage(HttpMethod.Delete, $"v1/mastertagcategories/{uid}");
        var response = await _httpClient.SendAsync(request);
        response.EnsureSuccessStatusCode();
    }


}