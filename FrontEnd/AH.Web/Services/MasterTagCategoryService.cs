using System.Net;
using System.Net.Http.Headers;
using AH.Metadata.Shared.V1.Models.Responses.MasterTagCategories;
using AH.Web.Dtos;
using AH.Web.Services.Interfaces;


namespace AH.Web.Services;
public class MasterTagCategoryService(HttpClient httpClient, TokenProvider tokenProvider, Serilog.ILogger logger, JsConsole console) : IMasterTagCategoryService
{
    public async Task<List<MasterTagCategoryResponse>> GetMasterTagCategories()
    {
        SetBearerToken();

        logger.Information("Calling {RequestUri} to retrieve master tag categories from ah-metadata", "v1/mastertagcategories");
        var response = await httpClient.GetAsync("v1/mastertagcategories");
        
        logger.Information(@"{Method} {RequestUri} {StatusCode}", response.RequestMessage?.Method, response.RequestMessage?.RequestUri, response.StatusCode);
        
        await console.LogAsync(response.Headers.ToString());
        logger.Information("Response Headers: {Header}", response.Headers.ToString());
        return await response.Content.ReadFromJsonAsync<List<MasterTagCategoryResponse>>() ?? new List<MasterTagCategoryResponse>();
    }
    
    public async Task UpdateMasterTagCategory(MasterTagCategoryResponse category)
    {
        SetBearerToken();
        var request = new HttpRequestMessage(HttpMethod.Put, $"v1/mastertagcategories/{category.UId}?Name={category.Name}&ClassName={category.ClassName}&Type={category.Type}");
        request.Headers.Add("Accept", "text/plain");
        var response = await httpClient.SendAsync(request);
        await console.LogAsync(response.Headers.ToString());
        logger.Information("Response Headers: {Header}", response.Headers.ToString());
        response.EnsureSuccessStatusCode();
        
    }

    public async Task CreateMasterTagCategory(MasterTagCategoryResponse category)
    {
        SetBearerToken();
        var request = new HttpRequestMessage(HttpMethod.Post, $"v1/mastertagcategories?Name={category.Name}&ClassName={category.ClassName}&Type={category.Type}");
        request.Headers.Add("Accept", "text/plain");
        var response = await httpClient.SendAsync(request);
        await console.LogAsync(response.Headers.ToString());
        logger.Information("Response Headers: {Header}", response.Headers.ToString());
        response.EnsureSuccessStatusCode();
        if (response.StatusCode == HttpStatusCode.BadRequest)
        {
            logger.Error("Error creating master tag category: {Error}", await response.Content.ReadAsStringAsync());
        }
    }

    private void SetBearerToken()
    {
        logger.Information("Setting access token for request");
        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokenProvider.AccessToken);
    }
}