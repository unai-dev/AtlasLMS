namespace AtlasLMS.Domain.Exceptions;

public class InternalServerException : Exception
{
    public InternalServerException(string msg) : base(msg)
    {

    }
}
