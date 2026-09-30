using System.Net;
using System.Text.Json;

using AtlasLMS.Domain.Exceptions;
using AtlasLMS.Shared.Responses;

namespace AtlasLMS.API.Middlewares;

public class AtlasCatchMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<AtlasCatchMiddleware> _logger;

    public AtlasCatchMiddleware(RequestDelegate next, ILogger<AtlasCatchMiddleware> logger)
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

        var response = new MiddlewareExceptionResponse(statusCode, ex.Message);

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)statusCode;

        return context.Response.WriteAsync(JsonSerializer.Serialize(response));


    }
}