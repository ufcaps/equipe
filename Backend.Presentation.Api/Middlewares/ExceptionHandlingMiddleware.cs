using Backend.Core.Application.Exceptions;

namespace Backend.Presentation.Api.Middlewares;

public class ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
{
    private readonly RequestDelegate _next = next;
    private readonly ILogger<ExceptionHandlingMiddleware> _logger = logger;

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (HttpException ex)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = ex.StatusCode;
            await context.Response.WriteAsJsonAsync(new { success = false, message = ex.Message });
        }
        catch (ValidationFailureException ex)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = StatusCodes.Status400BadRequest;

            var message = ex.Failures
                .Select(x => x.ErrorMessage)
                .Where(x => x != null)
                .ToList();

            await context.Response.WriteAsJsonAsync(new { success = false, message });
        }
        catch (Exception ex)
        {
            _logger.LogWarning(ex, "An unexpected error occurred");
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = StatusCodes.Status500InternalServerError;
            await context.Response.WriteAsJsonAsync(new { success = false, message = "An unexpected error occurred" });
        }
    }
}
