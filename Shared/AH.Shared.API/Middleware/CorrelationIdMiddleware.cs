using AH.Shared.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;

namespace AH.Shared.Api.Middleware;

public class CorrelationIdMiddleware
{
    private readonly RequestDelegate _next;
    private const string _correlationIdHeader = "X-Correlation-Id";

    public CorrelationIdMiddleware(RequestDelegate next) { 
        _next = next; 
    }

    public async Task Invoke(HttpContext context, ICorrelationId correlationIdGenerator)
    {
        var correlationId = GetCorrelationId(context, correlationIdGenerator);
        AddCorrelationIdHeaderToResponse(context, correlationId);

        await _next(context);
    }

    private static StringValues GetCorrelationId(HttpContext context, ICorrelationId correlationIdGenerator)
    {
        if(context.Request.Headers.TryGetValue(_correlationIdHeader, out var correlationId))
        {
            correlationIdGenerator.Set(correlationId);
            return correlationId;
        }
        else
        {
            return correlationIdGenerator.Get();
        }
    }

    private static void AddCorrelationIdHeaderToResponse(HttpContext context, StringValues correlationId)
    { 
        context.Response.OnStarting(() =>
        {
            context.Response.Headers.Add(_correlationIdHeader, new[] {correlationId.ToString()});
            return Task.CompletedTask;
        });
    }
}