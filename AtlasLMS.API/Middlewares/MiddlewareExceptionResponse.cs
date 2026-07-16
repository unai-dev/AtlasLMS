using System.Net;

namespace AtlasLMS.API.Middlewares;

internal class MiddlewareExceptionResponse
{
    public bool Success { get; set; } = false;
    public HttpStatusCode StatusCode { get; set; }
    public string? Message { get; set; }
} 