namespace AH.User.Application.Exceptions;
public class UnauthorizedException : ApplicationException
{
    public UnauthorizedException(string user, string resource) : base($"User {user} does not have access to {resource}") { }
    public UnauthorizedException(string message) : base(message) { }
}
