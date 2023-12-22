using Serilog.Events;

namespace AH.Metadata.Api.ProgramExtensions.LoggingAndTracing;

internal static class LogFilter
{
    
    public static bool Exclude(LogEvent logEvent)
    {
        try
        {
            if (!logEvent.Properties.ContainsKey("EventId") 
                || !logEvent.Properties.ContainsKey("SourceContext")) return false;
            
            var eventData = logEvent.Properties["EventId"];
            var source = logEvent.Properties["SourceContext"].ToString().Replace("\"", string.Empty);
            var eventName = ((StructureValue) eventData).Properties.Where(x=> x.Name == "Name").Select(x=> x.Value.ToString().Replace("\"", string.Empty)).FirstOrDefault() ?? string.Empty;

            if (eventName == "RegisteredModelBinderProviders" &&
                source == "Microsoft.AspNetCore.Mvc.ModelBinding.ModelBinderFactory") return true;
            if (source.StartsWith("Microsoft.AspNetCore.Server.Kestrel")) return true;
            if (source.StartsWith("Microsoft.AspNetCore.DataProtection")) return true;
            if (source.StartsWith("Microsoft.AspNetCore.Hosting.Diagnostics")) return true;
            if (source.StartsWith("System.Net.Http.HttpClient.ZipkinExporter")) return true;
            if (source.StartsWith("Microsoft.Extensions.Http.DefaultHttpClientFactory") &&
                eventName.StartsWith("CleanupCycle")) 
                return true;
            if (source.StartsWith("Microsoft.AspNetCore.Mvc.Infrastructure.DefaultOutputFormatterSelector"))
                return true;
            if (source.StartsWith("Microsoft.EntityFrameworkCore") && !source.StartsWith("Microsoft.EntityFrameworkCore.Database.Connection"))
            {
                if (!new List<string>
                    {
                        "Microsoft.EntityFrameworkCore.Database.Command.CommandExecuted",
                    }.Contains(eventName)) return true;
            }
            if (logEvent.Properties.ContainsKey("RequestPath"))
            {
                var requestPath =  logEvent.Properties["RequestPath"].ToString().Replace("\"", string.Empty);
                if(requestPath.StartsWith("/healthz")) return true;
            }
           
        }
        catch
        {
            return false;
        }
        
        return false;
    }
}
