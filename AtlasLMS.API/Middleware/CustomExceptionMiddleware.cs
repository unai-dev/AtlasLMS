using AtlasLMS.API.Utils.Exceptions;
using System.Net;
using System.Text.Json;

namespace AtlasLMS.API.Middleware;

public class CustomExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<CustomExceptionMiddleware> _logger;

    public CustomExceptionMiddleware(RequestDelegate next, ILogger<CustomExceptionMiddleware> logger)
    {
        _logger = logger;
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Excepcion capturada en el middleware global");
            await HandleExceptionAsync(context, ex);
        }
    }

    private static Task HandleExceptionAsync(HttpContext context, Exception ex)
    {
        var statusCode = ex switch
        {
            NotFoundException => HttpStatusCode.NotFound,
            BadRequestException => HttpStatusCode.BadRequest,
            _ => HttpStatusCode.InternalServerError,
        };

        var response = new
        {
            success = false,
            message = ex.Message,
            statusCode = statusCode,
            detail = ex.InnerException?.Message
        };

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)statusCode;

        return context.Response.WriteAsync(JsonSerializer.Serialize(response));


    }
}