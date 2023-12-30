using System.Net;
using System.Net.Http.Headers;
using AH.Metadata.Shared.V1.Models.Requests.Tags;
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
        var token = httpContextAccessor.HttpContext?.Request.Headers["Authorization"].ToString() ?? string.Empty;
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.Replace("Bearer ", string.Empty));
    }
    public async Task<List<MasterTagWithCategoryAndParentTagResponse>?> GetMasterTags(Guid masterTagCategoryUId)
    {
        var response = await _httpClient.GetAsync($"v1/mastertags/category/{masterTagCategoryUId}");
        if (!response.StatusCode.Equals(HttpStatusCode.OK))
        {
            return new List<MasterTagWithCategoryAndParentTagResponse>();
        }
        _httpContextAccessor.HttpContext!.Response.Headers.Add("Trace-Id", response.Headers.Where(x=>x.Key == "Trace-Id")
            .Select(x=>x.Value).First().FirstOrDefault());
        return await response.Content.ReadFromJsonAsync<List<MasterTagWithCategoryAndParentTagResponse>>();
    }
    
    public async Task<MasterTagWithCategoryAndParentTagResponse> CreateMasterTag(MasterTagWithCategoryAndParentTagResponse tag)
    {
        var request = new HttpRequestMessage(HttpMethod.Post, $"v1/mastertags?Name={tag.Name}&ClassName={tag.ClassName}&MasterTagCategoryUId={tag.MasterTagCategoryUId}&ParentMasterTagUId={tag.ParentMasterTagUId}");
        request.Headers.Add("Accept", "text/plain");
        var response = await _httpClient.SendAsync(request);
       
        response.EnsureSuccessStatusCode();
        _httpContextAccessor.HttpContext!.Response.Headers.Add("Trace-Id", response.Headers.Where(x=>x.Key == "Trace-Id")
            .Select(x=>x.Value).First().FirstOrDefault());
        return await response.Content.ReadFromJsonAsync<MasterTagWithCategoryAndParentTagResponse>() ?? new MasterTagWithCategoryAndParentTagResponse();
    }
    
    public async Task<MasterTagWithCategoryAndParentTagResponse> UpdateMasterTag(MasterTagWithCategoryAndParentTagResponse tag)
    {
         var request = new HttpRequestMessage(HttpMethod.Put, $"v1/mastertags/{tag.UId}?Name={tag.Name}&ClassName={tag.ClassName}&MasterTagCategoryUId={tag.MasterTagCategoryUId}&ParentMasterTagUId={tag.ParentMasterTagUId}");
         var response = await _httpClient.SendAsync(request);
         response.EnsureSuccessStatusCode();
         _httpContextAccessor.HttpContext!.Response.Headers.Add("Trace-Id", response.Headers.Where(x=>x.Key == "Trace-Id")
             .Select(x=>x.Value).First().FirstOrDefault());
        return await response.Content.ReadFromJsonAsync<MasterTagWithCategoryAndParentTagResponse>() ?? new MasterTagWithCategoryAndParentTagResponse();
       
    }
    
    public async Task DeleteMasterTag(Guid uid)
    {
        var request = new HttpRequestMessage(HttpMethod.Delete, $"v1/mastertags/{uid}");
        var response = await _httpClient.SendAsync(request);
        response.EnsureSuccessStatusCode();
        _httpContextAccessor.HttpContext!.Response.Headers.Add("Trace-Id", response.Headers.Where(x=>x.Key == "Trace-Id")
            .Select(x=>x.Value).First().FirstOrDefault());
    }


}