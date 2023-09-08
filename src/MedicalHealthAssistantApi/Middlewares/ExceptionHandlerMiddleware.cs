using MedicalHealthAssistantApi.Models;
using Service.Exceptions;

namespace MedicalHealthAssistantApi.Middlewares;

public class ExceptionHandlerMiddleware
{
    private readonly RequestDelegate request;
    private readonly ILogger<ExceptionHandlerMiddleware> logger;
    public ExceptionHandlerMiddleware(RequestDelegate request, ILogger<ExceptionHandlerMiddleware> logger)
    {
        this.request = request;
        this.logger = logger;
    }
    public async Task Invoke(HttpContext context)
    {
        try
        {
            await this.request(context);
        }
        catch (NotFoundException ex)
        {
            context.Response.StatusCode = ex.StatusCode;
            await context.Response.WriteAsJsonAsync(new Response
            {
                StatusCode = context.Response.StatusCode,
                Message = ex.Message,
            });
        }
        catch (AlreadyExistException ex)
        {
            context.Response.StatusCode = ex.StatusCode;
            await context.Response.WriteAsJsonAsync(new Response
            {
                StatusCode = context.Response.StatusCode,
                Message = ex.Message,
            });
        }
        catch (Exception ex)
        {
            context.Response.StatusCode = 500;
            this.logger.LogError($"\n\n{ex}\n\n");
            await context.Response.WriteAsJsonAsync(new Response
            {
                StatusCode = context.Response.StatusCode,
                Message = ex.Message,
            });
        }
    }

}
