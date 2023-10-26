using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace AH.Shared.Api.Middleware;

public class LogHeaderMiddleware
{

        private readonly RequestDelegate _next;  
  
        public LogHeaderMiddleware(RequestDelegate next)  
        {  
            this._next = next;  
        }  
  
        public async Task InvokeAsync(HttpContext context)  
        {  
            var header = context.Request.Headers["X-Correlation-Id"];  
            if (header.Count > 0)  
            {  
                var logger = context.RequestServices.GetRequiredService<ILogger<LogHeaderMiddleware>>();  
                using (logger.BeginScope("{@CorrelationId}", header[0]))  
                {  
                    await this._next(context);  
                }  
            }  
            else  
            {  
                await this._next(context);  
            }  
        }  
  
}