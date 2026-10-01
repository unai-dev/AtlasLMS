using System.Net;

namespace Unova.Shared.Responses;

/// <summary>
/// Modelo de respuesta al capturar una excepcion
/// </summary>
public record MiddlewareExceptionResponse(HttpStatusCode StatusCode, string Message);