namespace AH.Shared.Api.Dtos;

public class SwaggerDocSetup
{
    public SwaggerDocSetup(string appName, string appTag, IDictionary<string, string> permissions, string xmlCommentsPath)
    {
        AppName = appName;
        Permissions = permissions;
        XmlCommentsPath = xmlCommentsPath;
        AppTag = appTag;
    }
    public string AppName { get; }
    public string AppTag { get; set; }
    public string XmlCommentsPath { get; set; } 
    public IDictionary<string, string> Permissions { get; }
   
}