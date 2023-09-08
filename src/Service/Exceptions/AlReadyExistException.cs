using System;

namespace Service.Exceptions;

public class AlreadyExistException:Exception
{
    public int StatusCode { get; set; } = 403;
    public AlreadyExistException(string message) : base(message)
    {
    }
    public AlreadyExistException(string message, Exception innerException) : base(message, innerException)
    {
    }
}
