using System.Net.Http.Headers;
using AH.Metadata.Shared.V1.Models.Responses.MasterTagCategories;
using AH.Web.Dtos;
using AH.Web.Services.Interfaces;

namespace AH.Web.Services;
public class MasterTagCategoryService(HttpClient httpClient, TokenProvider tokenProvider) : IMasterTagCategoryService
{
    public async Task<List<MasterTagCategoryResponse>> GetMasterTagCategories()
    {
        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokenProvider.AccessToken);
        var response = await httpClient.GetAsync("v1/mastertagcategories");
        Console.WriteLine(response.Headers);
        return await response.Content.ReadFromJsonAsync<List<MasterTagCategoryResponse>>() ?? new List<MasterTagCategoryResponse>();
    }
}