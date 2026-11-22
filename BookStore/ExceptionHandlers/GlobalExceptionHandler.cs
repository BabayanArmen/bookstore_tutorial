using Microsoft.AspNetCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace BookStore.ExceptionHandlers
{
    public class GlobalExceptionHandler(ILogger<GlobalExceptionHandler> _logger) : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            _logger.LogError(exception, exception.Message);

            var (statusCode, message) = exception switch
            {
                DbUpdateException
                {
                    InnerException: PostgresException
                    {
                        SqlState: PostgresErrorCodes.UniqueViolation
                    }
                } => (400, "Record already exists"),

                DbUpdateException
                {
                    InnerException: PostgresException
                    {
                        SqlState: PostgresErrorCodes.ForeignKeyViolation
                    }
                } => (409, "Related record does not exist or cannot be deleted."),

                DbUpdateException => (400, "Database update failed."),

                PostgresException => (400, "Database operation failed."),

                NpgsqlException => (503, "Database service is unavailable."),

                _ => (500, "Something went wrong.")
            };

            httpContext.Response.StatusCode = statusCode;

            await httpContext.Response.WriteAsJsonAsync
                (
                    new
                    {
                        message
                    }
                );


            return true;

        }
    }
}
