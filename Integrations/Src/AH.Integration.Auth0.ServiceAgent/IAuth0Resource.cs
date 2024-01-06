using Auth0.ManagementApi.Models;

namespace AH.Integration.Auth0.ServiceAgent;

public interface IAuth0Resource
{
    Task<string> GetTokenAsync();

    Task<ApiResponse<Job>> GetJobAsync(string jobId);
    Task<ApiResponse<Job>> ImportUsersAsync(string connectionId, string filename, Stream file, bool upsert, string externalId, bool data);
    Task<ApiResponse<Job>> ExportAllUsersAsync (List<string> fields);
    Task<ApiResponse<Organization>> GetOrganizationByNameAsync(Role role);
    Task<ApiResponse<Organization>> CreateOrganizationAsync(string Name, Guid uid, CancellationToken cancellationToken);
    Task<ApiResponse<Organization>> UpdateOrganizationAsync(string companyName, Guid companyUId, CancellationToken cancellationToken);
    Task DeleteOrganizationAsync(string organizationId, CancellationToken cancellationToken);
   
    Task<ApiResponse<List<Organization>>> GetAllOrganizationsAsync();
    Task<ApiResponse<User>> GetUserByEmailAsync(string email);
    Task<ApiResponse<User>> UpdateUserAsync(string userId, UserUpdateRequest dto);		
    Task<ApiResponse<bool>> DeleteUserAsync(string userId);
    Task<ApiResponse<bool>> AddOrganizationMemberAsync(string organizationId, string userId);
    Task<ApiResponse<bool>> AddOrganizationMemberRoleAsync(string organizationId, string userId, string role);
  
    Task<ApiResponse<bool>> AddRoleToUserAsync(string userId, string role);
    Task<ApiResponse<List<User>>> GetAllAdministratorsAsync();
    Task<ApiResponse<List<User>>> GetAllAgencyAdminsAsync();
    Task<ApiResponse<List<User>>> GetAllGuestsAsync();
    Task<ApiResponse<List<User>>> GetAllRecruitersAsync();
    Task<ApiResponse<List<User>>> GetAllTravelersAsync();
    Task<ApiResponse<List<User>>> GetAllUsersForRoleAsync(string role);


   
}