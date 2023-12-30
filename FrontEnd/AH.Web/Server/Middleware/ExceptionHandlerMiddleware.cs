using System.Net;
using System.Text.Json;
using AH.Web.Server.Exceptions;


namespace AH.Web.Server.Middleware;

internal class ExceptionHandlerMiddleware
{
    private readonly ILogger _logger;
    private readonly RequestDelegate _next;
    private readonly IWebHostEnvironment _environment;

    public ExceptionHandlerMiddleware(RequestDelegate next,
        ILogger<ExceptionHandlerMiddleware> logger,
        IWebHostEnvironment environment)
    {
        _next = next;
        _environment = environment;
        _logger = logger;
    }

    public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var code = HttpStatusCode.InternalServerError;

            var result = string.Empty;

            switch (exception)
            {
                case ValidationException validationException:       // 400
                    code = HttpStatusCode.BadRequest;
                    result = JsonSerializer.Serialize(validationException.Failures);
                    break;
                case UnauthorizedException:                       // 401
                    _logger.LogError(exception, "An UNAUTHORIZED EXCEPTION has occurred while executing the request");
                    code = HttpStatusCode.Unauthorized;
                    break;
                default:
                    _logger.LogError(exception, "An UNHANDLED EXCEPTION has occurred while executing the request");
                    if (!_environment.IsProduction() && !_environment.IsStaging())
                        result = JsonSerializer.Serialize(exception.InnerException?.Message ?? exception.Message);

                    break;
            }

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;

            return context.Response.WriteAsync(result);
        }
    }

// ReSharper disable once UnusedType.Global
internal static class ExceptionHandlerMiddlewareExtensions
    {
        public static IApplicationBuilder UseCustomExceptionHandler(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionHandlerMiddleware>();
        }
    }
