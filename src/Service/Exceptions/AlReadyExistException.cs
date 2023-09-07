namespace Service.Exceptions;

public class AlReadyExistException:Exception
{
    public int StatusCode { get; set; } = 403;
    public AlReadyExistException(string message) : base(message)
    {
    }
    public AlReadyExistException(string message, Exception innerException) : base(message, innerException)
    {
    }
}
