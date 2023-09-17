using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace AH.Company.Api.Configuration.Filters;

public  class LowercaseDocumentFilter : IDocumentFilter
{
    private static string LowercaseEverythingButParams(string key)
    {
        return string.Join("/", key.Split('/').Select(x => x.Contains('{') ? x : x.ToLower()));
    }

    public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
    {
        var paths = swaggerDoc.Paths;

        //	generate the new keys
        var newPaths = new Dictionary<string, OpenApiPathItem>();
        var removeKeys = new List<string>();

        foreach (var path in paths)
        {
            var newKey = LowercaseEverythingButParams(path.Key);
            if (newKey == path.Key) continue;
            removeKeys.Add(path.Key);
            newPaths.Add(newKey, path.Value);
        }

        foreach (var path in newPaths) { swaggerDoc.Paths.Add(path.Key, path.Value); }
        foreach (var key in removeKeys) { swaggerDoc.Paths.Remove(key); }
    }
}