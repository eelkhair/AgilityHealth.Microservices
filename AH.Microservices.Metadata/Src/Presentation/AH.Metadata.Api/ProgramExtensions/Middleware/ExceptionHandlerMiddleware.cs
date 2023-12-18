using System.Net;
using System.Text.Json;
using AH.Metadata.Application.Exceptions;
namespace AH.Metadata.Api.ProgramExtensions.Middleware;

internal class ExceptionHandlerMiddleware(
    RequestDelegate next,
    ILogger<ExceptionHandlerMiddleware> logger,
    IWebHostEnvironment environment)
{
    private readonly ILogger _logger = logger;

    public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
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
                    if (!environment.IsProduction() && !environment.IsStaging())
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
