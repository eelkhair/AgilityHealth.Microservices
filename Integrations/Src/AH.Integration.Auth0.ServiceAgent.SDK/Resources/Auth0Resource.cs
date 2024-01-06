using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using AH.Integration.Auth0.ServiceAgent.Dtos;
using Auth0.Core.Exceptions;
using Auth0.ManagementApi;
using Auth0.ManagementApi.Models;
using Microsoft.Extensions.Logging;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace AH.Integration.Auth0.ServiceAgent.SDK.Resources;

public class Auth0Resource(ILogger logger, Auth0Config config, string bearerToken = "") : ManagementApiClient(bearerToken, "eelkhair.us.auth0.com"), IAuth0Resource
{
    
    private Auth0Config Config { get; } = config;
    private ApiResponse<TDto> OkResult<TDto>(TDto dto) => new ApiResponse<TDto> { Dto = dto, StatusCode = "200" };
    private ApiResponse<TDto> CreatedResult<TDto>(TDto dto) => new ApiResponse<TDto> { Dto = dto, StatusCode = "201" };
    private ApiResponse<TDto> FailedResult<TDto>(Dictionary<string, string[]> brokenRules, string statusCode) => new ApiResponse<TDto> { BrokenRules = brokenRules, StatusCode = statusCode };

    public Task<ApiResponse<Job>> GetJobAsync(string jobId)
    {
        throw new NotImplementedException();
    }

    public Task<ApiResponse<Job>> ImportUsersAsync(string connectionId, string filename, Stream file, bool upsert, string externalId, bool data)
    {
        throw new NotImplementedException();
    }

    public Task<ApiResponse<Job>> ExportAllUsersAsync(List<string> fields)
    {
        throw new NotImplementedException();
    }

    public Task<ApiResponse<Organization>> GetOrganizationByNameAsync(Role role)
    {
        throw new NotImplementedException();
    }

    public async Task<ApiResponse<Organization>> CreateOrganizationAsync(string name, Guid uid, CancellationToken cancellationToken)
    {
        try
        {
            var organization = await Organizations.CreateAsync(new OrganizationCreateRequest
            {
                DisplayName = name,
                Name = uid.ToString(),
                Branding = new OrganizationBranding
                {
                    Colors = new BrandingColors { Primary = "#ffffff", PageBackground = "#222E62" }
                }
            }, cancellationToken);
            await Organizations.CreateConnectionAsync(organization.Id, new OrganizationConnectionCreateRequest()
            {
                AssignMembershipOnLogin = false,
                ConnectionId = "con_CHoqt1BtWlTCWa49"
            }, cancellationToken);	
			
            return CreatedResult(organization);
        }
        catch(Exception e)
        {
            return await HandleException<Organization>(e, new object[] { name, uid });
        }	
    }
    public async Task<ApiResponse<Organization>> UpdateOrganizationAsync(string name, Guid uid, CancellationToken cancellationToken)
    {
        try
        {
            var organization = await Organizations.GetByNameAsync(uid.ToString(), cancellationToken);
            var dto = new OrganizationUpdateRequest
            {
                DisplayName = name
            };
            organization = await Organizations.UpdateAsync(organization.Id, dto, cancellationToken);
            
            return OkResult(organization);
        }
        catch(Exception e)
        {
            return await HandleException<Organization>(e, new object[] { name, uid });
        }	
    }
    public async Task DeleteOrganizationAsync(string organizationId, CancellationToken cancellationToken)
    {
        try
        {
            var organization = await Organizations.GetByNameAsync(organizationId, cancellationToken);
            
            await Organizations.DeleteAsync(organization.Id, cancellationToken);
            
        }
        catch(Exception e)
        {
            await HandleException<List<Organization>>(e);
        }	
    }
    public Task<ApiResponse<List<Organization>>> GetAllOrganizationsAsync()
    {
        throw new NotImplementedException();
    }

    public Task<ApiResponse<User>> GetUserByEmailAsync(string email)
    {
        throw new NotImplementedException();
    }

    public Task<ApiResponse<User>> UpdateUserAsync(string userId, UserUpdateRequest dto)
    {
        throw new NotImplementedException();
    }

    public Task<ApiResponse<bool>> DeleteUserAsync(string userId)
    {
        throw new NotImplementedException();
    }

    public Task<ApiResponse<bool>> AddOrganizationMemberAsync(string organizationId, string userId)
    {
        throw new NotImplementedException();
    }

    public Task<ApiResponse<bool>> AddOrganizationMemberRoleAsync(string organizationId, string userId, string role)
    {
        throw new NotImplementedException();
    }

    public Task<ApiResponse<bool>> DeleteOrganizationAsync(string organizationId)
    {
        throw new NotImplementedException();
    }

    public Task<ApiResponse<bool>> AddRoleToUserAsync(string userId, string role)
    {
        throw new NotImplementedException();
    }

    public Task<ApiResponse<List<User>>> GetAllAdministratorsAsync()
    {
        throw new NotImplementedException();
    }

    public Task<ApiResponse<List<User>>> GetAllAgencyAdminsAsync()
    {
        throw new NotImplementedException();
    }

    public Task<ApiResponse<List<User>>> GetAllGuestsAsync()
    {
        throw new NotImplementedException();
    }

    public Task<ApiResponse<List<User>>> GetAllRecruitersAsync()
    {
        throw new NotImplementedException();
    }

    public Task<ApiResponse<List<User>>> GetAllTravelersAsync()
    {
        throw new NotImplementedException();
    }

    public Task<ApiResponse<List<User>>> GetAllUsersForRoleAsync(string role)
    {
        throw new NotImplementedException();
    }
    
    public async Task<string> GetTokenAsync()
    {
        logger.LogInformation("Getting token from Auth0");
        var client = new HttpClient();
        var domain = Config.Domain;

        var body = new {
            client_id = Config.ClientId,
            client_secret = Config.ClientSecret,
            audience = Config.Audience,
            grant_type = "client_credentials"
        };
    
        var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
        var content = new StringContent(JsonSerializer.Serialize(body, options), Encoding.UTF8, "application/json");

        var result = await client.PostAsync($"{domain}oauth/token", content);
        var json = await result.Content.ReadAsStringAsync();

        dynamic obj = JsonSerializer.Deserialize<Dictionary<string, object>>(json)!;
        return obj["access_token"].ToString();
    }
    
    private async Task<ApiResponse<TDto>> HandleException<TDto>(Exception e,  object[]  args = null!, 
        [CallerMemberName] string? caller = null)
    {		
        var brokenRules = new Dictionary<string, string[]>();
		
        if (e.GetType() == typeof(ErrorApiException)){	
			
            var error = (ErrorApiException) e;			
            brokenRules.Add(error.StatusCode.ToString(), new[] { e.Message });
			
            return FailedResult<TDto>(brokenRules, Convert.ToInt32(error.StatusCode).ToString());
        }
		
        if (e.GetType() == typeof(RateLimitApiException)){		
            var error = ((RateLimitApiException) e);
            while (true)
            {
                if (DateTimeOffset.UtcNow > (DateTimeOffset) error.RateLimit.Reset! )
                {
                    return await (Task<ApiResponse<TDto>>) this.GetType().GetMethod(caller!)!.Invoke(this, args)!;
                }
            }
        }	
		
        brokenRules.Add("500", new[] { e.Message });
		
        return FailedResult<TDto>(brokenRules,"500");
    }

}