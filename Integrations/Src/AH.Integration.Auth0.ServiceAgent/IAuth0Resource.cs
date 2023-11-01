using AH.Integration.Auth0.ServiceAgent.Dtos;

namespace AH.Integration.Auth0.ServiceAgent;

public interface IAuth0Resource
{
    Task<ApiResponse<UserDto>> CreateUserAsync(UserDto user, string bearerToken,
        CancellationToken cancellationToken);

    Task<ApiResponse<UserDto>> UpdateUserAsync(UserDto user, string bearerToken,
        CancellationToken cancellationToken);

    Task<ApiResponse<UserDto>> GetUserByEmailAsync(string email, string bearerToken,
        CancellationToken cancellationToken);

    Task<bool> DeleteUserAsync(string userId, string bearerToken, CancellationToken cancellationToken);

    Task<ApiResponse<UserLogDto>> GetUserLogAsync(string userId, string bearerToken,
        CancellationToken cancellationToken);

    Task<bool> AddRoleToUserAsync(string userId, string role, string bearerToken,
        CancellationToken cancellationToken);

    Task<bool> RemoveRoleFromUserAsync(string userId, string role, string bearerToken,
        CancellationToken cancellationToken);

    Task<ApiResponse<OrganizationDto>> CreateOrganizationAsync(OrganizationDto organization, string bearerToken,
        CancellationToken cancellationToken);

    Task<bool> AddMembersToOrganizationAsync(string id, OrganizationMemberDto members, string bearerToken,
        CancellationToken cancellationToken);

    Task<bool> RemoveMembersFromOrganizationAsync(string id, OrganizationMemberDto members, string bearerToken,
        CancellationToken cancellationToken);

    Task<ApiResponse<OrganizationDto>> GetOrganizationByNameAsync(string name, string bearerToken,
        CancellationToken cancellationToken);

    Task<ApiResponse<IEnumerable<UserDto>>> GetOrganizationMembersAsync(string id, string bearerToken,
        CancellationToken cancellationToken);

    Task<bool> DeleteOrganizationAsync(string id, string bearerToken, CancellationToken cancellationToken);

    Task<bool> AddRoleToOrganizationMemberAsync(string organizationId, string userId, string role,
        string bearerToken, CancellationToken cancellationToken);

    Task<ApiResponse<GetRoleDto>> GetRoleForOrganizationMemberAsync(string organizationId, string userId,
        string bearerToken, CancellationToken cancellationToken);

    Task<ApiResponse<GetRoleDto>> GetRoleForUserAsync(string userId, string bearerToken,
        CancellationToken cancellationToken);

    Task<bool> RemoveRoleFromOrganizationMemberAsync(string organizationId, string userId, string role,
        string bearerToken, CancellationToken cancellationToken);

    Task<ApiResponse<InvitationDto>> AddMemberToOrganizationViaInviteAsync(string organizationId,
        InvitationDto invitation, string bearerToken, CancellationToken cancellationToken);

    Task<ApiResponse<JobResultDto>> SendUserVerificationEmailAsync(string userId, string bearerToken, string app_client_id,
        CancellationToken cancellationToken);

    Task<bool> DeleteOrganizationMemberInvitationAsync(string organizationId, string invitationId,
        string bearerToken, CancellationToken cancellationToken);

    Task<ApiResponse<List<InvitationDto>>> GetOrganizationMemberInvitationsAsync(string organizationId,
        string bearerToken, CancellationToken cancellationToken);

    Task<ApiResponse<IEnumerable<UserDto>>> GetUsersByQueryAsync(string attribute, string key, object value,
        string bearerToken, CancellationToken cancellationToken);

    Task<ApiResponse<List<ConnectionDto>>> GetAllConnectionsAsync(string bearerToken,
        CancellationToken cancellationToken);
}