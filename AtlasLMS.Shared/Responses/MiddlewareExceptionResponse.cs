using System.Net;

namespace AtlasLMS.Shared.Responses;

/// <summary>
/// Modelo de respuesta al capturar una excepcion
/// </summary>
public record MiddlewareExceptionResponse(bool Success, HttpStatusCode StatusCode, string Message);