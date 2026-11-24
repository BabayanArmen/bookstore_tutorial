using Microsoft.AspNetCore.Diagnostics;

namespace BookStore.MIddlewares;

public class GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger) : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(
        HttpContext httpContext,
        Exception exception,
        CancellationToken cancellationToken)
    {
        logger.LogError(exception.Message, "An unhandled exception occurred.");
        logger.LogError(exception?.InnerException?.Message, "An unhandled exception occurred.");

        httpContext.Response.StatusCode = 500;

        await httpContext.Response.WriteAsJsonAsync(
            new { message = "Oops, somthing went wrong" },
            cancellationToken);

        return true;
    }
}