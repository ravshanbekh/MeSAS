namespace MedicalHealthAssistantApi.Middlewares;

public class ExceptionHandlerMiddleware
{
    private readonly RequestDelegate request;
    private readonly ILogger<ExceptionHandlerMiddleware> logger;
    public ExceptionHandlerMiddleware()
    {
        
    }
}
