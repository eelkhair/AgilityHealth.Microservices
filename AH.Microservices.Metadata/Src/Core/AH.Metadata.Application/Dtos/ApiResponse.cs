namespace AH.Metadata.Application.Dtos;

public class ApiResponse<TDto>
{
    public ApiResponse()
    {
        BrokenRules = new Dictionary<string, string[]>();
    }
    
    public int Total { get; set; }
    public TDto Dto { get; set; }
    public IDictionary<string, string[]> BrokenRules { get; set; }
    public string StatusCode { get; set; }
}