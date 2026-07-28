using System.Net;

namespace AtlasLMS.API.Middlewares;

/// <summary>
/// Modelo de respuesta al capturar una excepcion
/// </summary>
internal record MiddlewareExceptionResponse(bool Success, HttpStatusCode StatusCode, string Message);