using System.Text;
using AH.Integration.Auth0.ServiceAgent.Dtos;
using AH.Integration.Auth0.ServiceAgent.Rest.Extensions;
using Microsoft.Extensions.Logging;

namespace AH.Integration.Auth0.ServiceAgent.Rest.Resources;

public class Auth0Resource : IAuth0Resource
{
    private readonly ILogger<Auth0Resource> _logger;
    private readonly IWebApiClient _webApiClient;

    public Auth0Resource(ILogger<Auth0Resource> logger, IWebApiClient webApiClient)
    {
        _logger = logger;
        _webApiClient = webApiClient;
    }

    public async Task<ApiResponse<UserDto>> CreateUserAsync(UserDto data, string bearerToken,
        CancellationToken cancellationToken)
    {
        _logger.LogInformation(@"Posting UserDto: {}",
            SerializationExtensions.Mask(data, new List<string> {"password"}));

        return await _webApiClient.PostAsync("users", data, IgnoredProperties.CreateUser(), bearerToken,
            cancellationToken);
    }

    public async Task<ApiResponse<UserDto>> UpdateUserAsync(UserDto data, string bearerToken,
        CancellationToken cancellationToken)
    {
        return await _webApiClient.PatchAsync($"users/{data.UserId}", data, IgnoredProperties.UpdateUser(),
            bearerToken, cancellationToken);
    }

    public async Task<ApiResponse<UserDto>> GetUserByEmailAsync(string email, string bearerToken,
        CancellationToken cancellationToken)
    {
        var response = await _webApiClient.GetAsync<List<UserDto>>($@"users-by-email?email={email.ToLower()}",
            bearerToken, cancellationToken);

        return new ApiResponse<UserDto>
        {
            BrokenRules = response.BrokenRules,
            Count = response.Count,
            Dto = response.Dto?.FirstOrDefault(),
            Start = response.Start,
            StatusCode = response.StatusCode,
            Total = response.Total
        };
    }

    public async Task<bool> DeleteUserAsync(string userId, string bearerToken, CancellationToken cancellationToken)
    {
        return await _webApiClient.DeleteAsync<object>($"users/{userId}", null, null, bearerToken,
            cancellationToken);
    }

    public async Task<ApiResponse<UserLogDto>> GetUserLogAsync(string userId, string bearerToken,
        CancellationToken cancellationToken)
    {
        var response =
            await _webApiClient.GetAsync<List<UserLogDto>>($@"users/{userId}/logs", bearerToken, cancellationToken);

        return new ApiResponse<UserLogDto>
        {
            BrokenRules = response.BrokenRules,
            Count = response.Count,
            Dto = response.Dto?.FirstOrDefault(),
            Start = response.Start,
            StatusCode = response.StatusCode,
            Total = response.Total
        };
    }

    public async Task<bool> AddRoleToUserAsync(string userId, string role, string bearerToken,
        CancellationToken cancellationToken)
    {
        var roles = await _webApiClient.GetAsync<List<GetRoleDto>>("roles", bearerToken, cancellationToken);
        var roleId = roles?.Dto.Where(x => string.Equals(x.Name, role, StringComparison.CurrentCultureIgnoreCase))
            .Select(x => x.Id).FirstOrDefault();

        if (roleId == null) return false;

        var result = await _webApiClient.PostAsync($"users/{userId}/roles",
            new PostRoleDto {Roles = new List<string> {roleId}}, null, bearerToken, cancellationToken);
        return result.StatusCode == "NoContent";
    }

    public async Task<bool> RemoveRoleFromUserAsync(string userId, string role, string bearerToken,
        CancellationToken cancellationToken)
    {
        var roles = await _webApiClient.GetAsync<List<GetRoleDto>>("roles", bearerToken, cancellationToken);
        var roleId = roles?.Dto.Where(x => string.Equals(x.Name, role, StringComparison.CurrentCultureIgnoreCase))
            .Select(x => x.Id).FirstOrDefault();

        if (roleId == null) return false;

        return await _webApiClient.DeleteAsync($"users/{userId}/roles",
            new PostRoleDto {Roles = new List<string> {roleId}}, null, bearerToken, cancellationToken);
    }

    public async Task<bool> AddMembersToOrganizationAsync(string id, OrganizationMemberDto members,
        string bearerToken, CancellationToken cancellationToken)
    {
        return (await _webApiClient.PostAsync($"organizations/{id}/members", members, new List<string>(),
            bearerToken, cancellationToken)).BrokenRules.Count == 0;
    }

    public async Task<bool> RemoveMembersFromOrganizationAsync(string id, OrganizationMemberDto members,
        string bearerToken, CancellationToken cancellationToken)
    {
        return await _webApiClient.DeleteAsync($"organizations/{id}/members", members, new List<string>(),
            bearerToken, cancellationToken);
    }

    public async Task<ApiResponse<OrganizationDto>> GetOrganizationByNameAsync(string name, string bearerToken,
        CancellationToken cancellationToken)
    {
        return await _webApiClient.GetAsync<OrganizationDto>($"organizations/name/{name}", bearerToken,
            cancellationToken);
    }

    public async Task<ApiResponse<IEnumerable<UserDto>>> GetOrganizationMembersAsync(string id, string bearerToken,
        CancellationToken cancellationToken)
    {
        return await _webApiClient.GetAsync<IEnumerable<UserDto>>($"organizations/{id}/members", bearerToken,
            cancellationToken);
    }

    public async Task<bool> DeleteOrganizationAsync(string id, string bearerToken,
        CancellationToken cancellationToken)
    {
        return await _webApiClient.DeleteAsync<object>($"organizations/{id}", null, null, bearerToken,
            cancellationToken);
    }

    public async Task<bool> AddRoleToOrganizationMemberAsync(string organizationId, string userId, string role,
        string bearerToken, CancellationToken cancellationToken)
    {
        var roles = await _webApiClient.GetAsync<List<GetRoleDto>>("roles", bearerToken, cancellationToken);
        var roleId = roles?.Dto.Where(x => string.Equals(x.Name, role, StringComparison.CurrentCultureIgnoreCase))
            .Select(x => x.Id).FirstOrDefault();

        if (roleId == null) return false;

        var result = await _webApiClient.PostAsync($"organizations/{organizationId}/members/{userId}/roles",
            new PostRoleDto {Roles = new List<string> {roleId}}, null, bearerToken, cancellationToken);
        return result.StatusCode == "NoContent";
    }

    public async Task<ApiResponse<GetRoleDto>> GetRoleForOrganizationMemberAsync(string organizationId,
        string userId, string bearerToken, CancellationToken cancellationToken)
    {
        var result = await _webApiClient.GetAsync<IEnumerable<GetRoleDto>>(
            $"organizations/{organizationId}/members/{userId}/roles", bearerToken, cancellationToken);

        return new ApiResponse<GetRoleDto>
        {
            Count = result.Count,
            Dto = result.Dto.FirstOrDefault(),
            Start = result.Start,
            Total = result.Total,
            BrokenRules = result.BrokenRules,
            StatusCode = result.StatusCode,
        };
    }

    public async Task<ApiResponse<GetRoleDto>> GetRoleForUserAsync(string userId, string bearerToken,
        CancellationToken cancellationToken)
    {
        var result =
            await _webApiClient.GetAsync<IEnumerable<GetRoleDto>>($"users/{userId}/roles", bearerToken,
                cancellationToken);

        return new ApiResponse<GetRoleDto>
        {
            Count = result.Count,
            Dto = result.Dto.FirstOrDefault(),
            Start = result.Start,
            Total = result.Total,
            BrokenRules = result.BrokenRules,
            StatusCode = result.StatusCode,
        };
    }

    public async Task<bool> RemoveRoleFromOrganizationMemberAsync(string organizationId, string userId, string role,
        string bearerToken, CancellationToken cancellationToken)
    {
        var roles = await _webApiClient.GetAsync<List<GetRoleDto>>("roles", bearerToken, cancellationToken);
        var roleId = roles?.Dto.Where(x => string.Equals(x.Name, role, StringComparison.CurrentCultureIgnoreCase))
            .Select(x => x.Id).FirstOrDefault();

        if (roleId == null) return false;

        return await _webApiClient.DeleteAsync($"organizations/{organizationId}/members/{userId}/roles",
            new PostRoleDto {Roles = new List<string> {roleId}}, null, bearerToken, cancellationToken);
    }

    public async Task<ApiResponse<InvitationDto>> AddMemberToOrganizationViaInviteAsync(string organizationId,
        InvitationDto invitation, string bearerToken, CancellationToken cancellationToken)
    {
        var roles = await _webApiClient.GetAsync<List<GetRoleDto>>("roles", bearerToken, cancellationToken);
        var roleId = roles?.Dto.Where(x =>
                string.Equals(x.Name, invitation.Role, StringComparison.CurrentCultureIgnoreCase))
            .Select(x => x.Id).FirstOrDefault();

        if (roleId == null) return null;

        invitation.Roles = new List<string> {roleId};
        return await _webApiClient.PostAsync($"organizations/{organizationId}/invitations", invitation,
            IgnoredProperties.InviteMemberToOrganization(), bearerToken, cancellationToken);
    }

    public virtual async Task<ApiResponse<JobResultDto>> SendUserVerificationEmailAsync(string userId, string bearerToken, string app_client_id,
        CancellationToken cancellationToken)
    {
        var request = new JobDto() {UserId = userId, ClientId = app_client_id};
        var response = await _webApiClient
            .PostAsync<JobDto>("jobs/verification-email", request, IgnoredProperties.SendUserVerificationEmail(string.IsNullOrWhiteSpace(app_client_id)), bearerToken, cancellationToken);

        var job = await GetJobAsync(response.Dto.Id, bearerToken, cancellationToken);
        return job;
    }

    public async Task<ApiResponse<JobResultDto>> GetJobAsync(string jobId, string bearerToken,
        CancellationToken cancellationToken, int waitTimeInSeconds = 2)
    {
        var retryCount = 0;
        const int retryLimit = 50;
        const string completedStatus = "completed";
        var status = string.Empty;
        var job = new ApiResponse<JobResultDto>();

        while (status != completedStatus & retryCount < retryLimit)
        {
            job = await _webApiClient.GetAsync<JobResultDto>($"jobs/{jobId}", bearerToken, cancellationToken);
            status = job.Dto.Status;
            if (status != completedStatus) Thread.Sleep(TimeSpan.FromSeconds(waitTimeInSeconds));
            retryCount++;
        }

        return job;
    }

    public async Task<bool> DeleteOrganizationMemberInvitationAsync(string organizationId, string invitationId,
        string bearerToken, CancellationToken cancellationToken)
    {
        return await _webApiClient.DeleteAsync<object>($"organizations/{organizationId}/invitations/{invitationId}",
            null, null, bearerToken, cancellationToken);
    }

    public async Task<ApiResponse<List<InvitationDto>>> GetOrganizationMemberInvitationsAsync(string organizationId,
        string bearerToken, CancellationToken cancellationToken)
    {
        var invitations =
            await _webApiClient.GetAsync<List<InvitationDto>>($"organizations/{organizationId}/invitations",
                bearerToken, cancellationToken);

        if (!invitations.Dto.Any()) return invitations;

        var rolesList = await _webApiClient.GetAsync<List<GetRoleDto>>("roles", bearerToken, cancellationToken);

        invitations.Dto.ForEach(x =>
        {
            var roles = new List<string>();
            foreach (var role in x.Roles)
            {
                roles.Add(rolesList.Dto.Where(y => y.Id == role).Select(z => z.Name).First());
                x.Role = string.Join(", ", roles);
            }
        });
        return invitations;
    }

    public async Task<ApiResponse<List<ConnectionDto>>> GetAllConnectionsAsync(string bearerToken,
        CancellationToken cancellationToken)
    {
        return await _webApiClient.GetAsync<List<ConnectionDto>>("connections", bearerToken, cancellationToken);
    }

    public async Task<ApiResponse<UserDto>> CreateTravelerAsync(UserDto user, string bearerToken,
        CancellationToken cancellationToken)
    {
        var response = await CreateUserAsync(user, bearerToken, cancellationToken);
        if (response.BrokenRules.Any(y => y.Value.Any(z => z.Equals("The user already exists."))))
        {
            response = await GetUserByEmailAsync(user.Email, bearerToken, cancellationToken);
        }

        if (response.BrokenRules.Any()) return null;

        var added = await AddRoleToUserAsync(response.Dto.UserId, "Traveler", bearerToken, cancellationToken);

        return added ? response : null;
    }

    public async Task<ApiResponse<OrganizationDto>> CreateOrganizationAsync(OrganizationDto organization,
        string bearerToken, CancellationToken cancellationToken)
    {
        await AddConnectionToOrganization(organization, bearerToken, cancellationToken);

        return await _webApiClient.PostAsync("organizations", organization, IgnoredProperties.CreateOrganization(),
            bearerToken, cancellationToken);
    }

    public async Task<ApiResponse<IEnumerable<UserDto>>> GetUsersByQueryAsync(string attribute, string key,
        object value, string bearerToken, CancellationToken cancellationToken)
    {
        var sb = new StringBuilder("users?q=");
        if (!string.IsNullOrWhiteSpace(attribute)) sb.Append($"{attribute}.");
        sb.Append($"{key}:{SurroundStringInQuotes(value)}&search_engine=v3");

        return await _webApiClient.GetAsync<IEnumerable<UserDto>>(sb.ToString(), bearerToken, cancellationToken);
    }

    private async Task AddConnectionToOrganization(OrganizationDto organization, string bearerToken,
        CancellationToken cancellationToken)
    {
        if (organization.EnabledConnections.Count == 0)
        {
            var connections = await GetAllConnectionsAsync(bearerToken, cancellationToken);

            var userPasswordConnection =
                connections.Dto.FirstOrDefault(x => x.Name == "Username-Password-Authentication");

            if (userPasswordConnection != null)
            {
                organization.EnabledConnections = new List<object>
                {
                    new
                    {
                        connection_id = userPasswordConnection.Id,
                        assign_membership_on_login = true
                    }
                };
            }
        }
    }

    private static string SurroundStringInQuotes(object value)
    {
        return value is string ? $"%22{value}%22" : value.ToString();
    }
}