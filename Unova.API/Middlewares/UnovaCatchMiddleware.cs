using System.Net;
using System.Text.Json;

using Unova.Domain.Exceptions;
using Unova.Shared.Responses;

namespace Unova.API.Middlewares;

public class UnovaCatchMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<UnovaCatchMiddleware> _logger;

    public UnovaCatchMiddleware(RequestDelegate next, ILogger<UnovaCatchMiddleware> logger)
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