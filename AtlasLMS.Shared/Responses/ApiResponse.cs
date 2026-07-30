using System.Net;

namespace AtlasLMS.Shared.Responses;

public class ApiResponse<T>
{
    public T? Data { get; set; }
    public HttpStatusCode StatusCode { get; set; }
}
