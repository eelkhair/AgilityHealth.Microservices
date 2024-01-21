namespace AH.Team.Api.ProgramExtensions.Dtos;

internal class SwaggerDocSetup(
    string appName,
    string appTag,
    IDictionary<string, string> permissions,
    string xmlCommentsPath)
{
    public string AppName { get; } = appName;
    public string AppTag { get; set; } = appTag;
    public string XmlCommentsPath { get; set; } = xmlCommentsPath;
    public IDictionary<string, string> Permissions { get; } = permissions;
}