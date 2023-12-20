using System.Net;
using System.Text;
using AH.Integration.Auth0.ServiceAgent.Dtos;
using IdentityModel.Client;
using Newtonsoft.Json;

namespace AH.Integration.Auth0.ServiceAgent.Rest;

public sealed class WebApiClientSingleton : IWebApiClient
{
    private static readonly WebApiClientSingleton Instance = new WebApiClientSingleton();
    private static HttpClient _httpClient;

    public static WebApiClientSingleton GetInstance(string baseUrl)
    {
        if (_httpClient != null)
        {
            return Instance;
        }

        _httpClient = new HttpClient()
        {
            BaseAddress = new Uri(baseUrl)
        };
            
        return Instance;
    }
        
    public async Task<ApiResponse<TDto>> GetAsync<TDto>(string requestUri, string bearerToken, CancellationToken cancellationToken)
    {
        _httpClient.SetBearerToken(bearerToken);
        var response = await _httpClient.GetAsync( requestUri, cancellationToken);

        if (response.StatusCode != HttpStatusCode.TooManyRequests) return await MapResponse<TDto>(response);
            
        var headers = response.Headers;
        headers.TryGetValues("x-ratelimit-reset", out var reset);
            
        while (true)
        {
            
            if (reset != null && DateTimeOffset.UtcNow.ToUnixTimeSeconds() > Convert.ToDouble(reset.First()) + 1)
            {
                return await GetAsync<TDto>(requestUri,  bearerToken, cancellationToken);
            }
        }
    }
    public async Task<ApiResponse<TDto>> PostAsync<TDto>(string requestUri, TDto requestDto, List<string>? propertiesToIgnore,  string bearerToken, CancellationToken cancellationToken)
    {
        _httpClient.SetBearerToken(bearerToken);

         
        var content = GetJsonStringContent(requestDto, propertiesToIgnore);
        var response = await _httpClient.PostAsync(requestUri, content, cancellationToken);

        if (response.StatusCode != HttpStatusCode.TooManyRequests) return await MapResponse(response, requestDto);
            
        var headers = response.Headers;
        headers.TryGetValues("x-ratelimit-reset", out var reset);
            
        while (true)
        {
            if (DateTimeOffset.UtcNow.ToUnixTimeSeconds() > Convert.ToDouble(reset.First())+ 1)
            {
                return await PostAsync(requestUri, requestDto, propertiesToIgnore, bearerToken,
                    cancellationToken);
            }
        }

    }
        
    public async Task<ApiResponse<TDto>> PatchAsync<TDto>(string requestUri, TDto requestDto,  List<string>? propertiesToIgnore,  string bearerToken, CancellationToken cancellationToken)
    {
        _httpClient.SetBearerToken(bearerToken);
            
        var content = GetJsonStringContent(requestDto, propertiesToIgnore);
        var response = await _httpClient.PatchAsync(requestUri, content, cancellationToken);

        if (response.StatusCode != HttpStatusCode.TooManyRequests) return await MapResponse(response, requestDto);
            
        var headers = response.Headers;
        headers.TryGetValues("x-ratelimit-reset", out var reset);
            
        while (true)
        {
            if (DateTimeOffset.UtcNow.ToUnixTimeSeconds() > Convert.ToDouble(reset.First()) + 1)
            {
                return await PatchAsync(requestUri, requestDto,  propertiesToIgnore, bearerToken,
                    cancellationToken);
            }
        }
    }

    public async Task<bool> DeleteAsync<TDto>(string requestUri, TDto body, List<string>? propertiesToIgnore, string bearerToken, CancellationToken cancellationToken)
    {
        _httpClient.SetBearerToken(bearerToken);
        StringContent content = null;
            
        if (body != null)
        {
            content = GetJsonStringContent(body, propertiesToIgnore);
        }

        var message = new HttpRequestMessage(HttpMethod.Delete, requestUri)
        {
            Content = content
        };
        var response = await _httpClient.SendAsync(message, cancellationToken);
            
        if (response.StatusCode != HttpStatusCode.TooManyRequests)
            return response.StatusCode == HttpStatusCode.NoContent;
            
        var headers = response.Headers;
        headers.TryGetValues("x-ratelimit-reset", out var reset);
            
        while (true)
        {
            if (DateTimeOffset.UtcNow.ToUnixTimeSeconds() > Convert.ToDouble(reset.First()) + 1)
            {
                return await DeleteAsync(requestUri, body, propertiesToIgnore, bearerToken,
                    cancellationToken);
            }
        }
    }

    private static async Task <ApiResponse<TDto>> MapResponse<TDto>(HttpResponseMessage response)
    {
        switch (response.StatusCode)
        {
            case HttpStatusCode.Created:
            case HttpStatusCode.Accepted:
            case HttpStatusCode.OK:
                var created = JsonConvert.DeserializeObject<TDto>(await response.Content.ReadAsStringAsync());
                return new ApiResponse<TDto> {Dto = created};
            case HttpStatusCode.Unauthorized:
            {
                throw new UnauthorizedAccessException("Unauthorized");
            }
            default:
                var error = JsonConvert.DeserializeObject<ErrorDto>(await response.Content.ReadAsStringAsync());
                    
                if (error == null) return new ApiResponse<TDto>();
                    
                var brokenRules = new Dictionary<string, string[]> {{error.Error, new[] {error.Message}}};
                return new ApiResponse<TDto>
                    {StatusCode = error.StatusCode, BrokenRules = brokenRules};

        }
    }
    private static async Task <ApiResponse<TDto>> MapResponse<TDto>(HttpResponseMessage response, TDto requestDto)
    {
        switch (response.StatusCode)
        {
            case HttpStatusCode.Created:
            case HttpStatusCode.Accepted:
            case HttpStatusCode.NoContent:
            case HttpStatusCode.OK:
                var created = JsonConvert.DeserializeObject<TDto>(await response.Content.ReadAsStringAsync());
                return new ApiResponse<TDto> {Dto = created, StatusCode = response.StatusCode.ToString()};
            case HttpStatusCode.Unauthorized:
            {
                throw new UnauthorizedAccessException("Unauthorized");
            }
            default:
                var error = JsonConvert.DeserializeObject<ErrorDto>(await response.Content.ReadAsStringAsync());
                    
                if (error == null) return new ApiResponse<TDto>();
                    
                var brokenRules = new Dictionary<string, string[]> {{error.Error, new[] {error.Message}}};
                return new ApiResponse<TDto>
                    {StatusCode = error.StatusCode, BrokenRules = brokenRules, Dto = requestDto};

        }
    }

    private static StringContent GetJsonStringContent<TDto>(TDto dto, IEnumerable<string>? propertiesToIgnore)
    {
        var serializerSettings = Extensions.SerializationExtensions.GetIgnoreSerializerSettings<TDto>(propertiesToIgnore);

        var json = JsonConvert.SerializeObject(dto, serializerSettings);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        return content;
    }

        
}