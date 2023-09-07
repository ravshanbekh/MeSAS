namespace Service.Exceptions;

public class AllReadyExistException:Exception
{
    public int StatusCode { get; set; } = 403;
    public AllReadyExistException(string message) : base(message)
    {
    }
    public AllReadyExistException(string message, Exception innerException) : base(message, innerException)
    {
    }
}
