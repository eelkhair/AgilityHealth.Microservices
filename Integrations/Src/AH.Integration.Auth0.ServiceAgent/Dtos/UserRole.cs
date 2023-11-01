namespace AH.Integration.Auth0.ServiceAgent.Dtos;

public class UserRole
{
    public UserDto User { get; set; }
    public List<GetRoleDto> Roles { get; set; }
}