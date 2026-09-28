
namespace AtlasLMS.Domain.Exceptions;

public class BadRequestException : Exception
{
    public BadRequestException() { }
    public BadRequestException(string msg) : base(msg) { }
    public BadRequestException(string msg, Exception ex) : base(msg, ex) { }
}

