namespace AH.Integration.Auth0.ServiceAgent.Rest;

public interface IWebApiClient{
    Task<ApiResponse<TDto>> GetAsync<TDto>(string uri, string bearerToken, CancellationToken cancellationToken);
    Task<ApiResponse<TDto>> PostAsync<TDto>(string requestUri, TDto requestDto, List<string>? propertiesToIgnore,  string bearerToken, CancellationToken cancellationToken);
    Task<ApiResponse<TDto>> PatchAsync<TDto>(string requestUri, TDto data, List<string>? propertiesToIgnore, string bearerToken, CancellationToken cancellationToken);

    Task<bool> DeleteAsync<TDto>(string requestUri, TDto body, List<string>? propertiesToIgnore, string bearerToken,
        CancellationToken cancellationToken);
}