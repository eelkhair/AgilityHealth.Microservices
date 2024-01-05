namespace AH.Integration.Auth0.ServiceAgent;

public class ApiResponse<TDto>(TDto dto, string statusCode)
{
    public int Total { get; set; }
    public int Start { get; set; }
    public int Count { get; set; }
    public TDto Dto { get; set; } = dto;
    public IDictionary<string, string[]> BrokenRules { get; set; } = new Dictionary<string, string[]>();
    public string StatusCode { get; set; } = statusCode;
}