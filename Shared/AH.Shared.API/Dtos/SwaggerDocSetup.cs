namespace AH.Shared.Api.Dtos;

public class SwaggerDocSetup
{
    public SwaggerDocSetup(string appName, IDictionary<string, string> permissions, string xmlCommentsPath)
    {
        AppName = appName;
        Permissions = permissions;
        XmlCommentsPath = xmlCommentsPath;
    }
    public string AppName { get; }

    public string XmlCommentsPath { get; set; } 
    public IDictionary<string, string> Permissions { get; }
   
}