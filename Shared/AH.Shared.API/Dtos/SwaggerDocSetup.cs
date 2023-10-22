namespace AH.Shared.Api.Dtos;

public class SwaggerDocSetup
{
    public SwaggerDocSetup(string appName, IDictionary<string, string> permissions)
    {
        AppName = appName;
        Permissions = permissions;
    }

    public string AppName { get; }

    public IDictionary<string, string> Permissions { get; }
   
}