using FluentValidation;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace HsBank.Api.Middlewares;

// This class intercepts ANY exception thrown by our application before it reaches the user
public class GlobalExceptionHandler : IExceptionHandler
{
    private readonly ILogger<GlobalExceptionHandler> _logger;

    public GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger)
    {
        _logger = logger;
    }

    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        _logger.LogError(exception, "An exception occurred: {Message}", exception.Message);

        if (exception is ValidationException validationException)
        {
            httpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
            
            var validationErrors = validationException.Errors.Select(e => new 
            { 
                Field = e.PropertyName, 
                Error = e.ErrorMessage 
            });

            await httpContext.Response.WriteAsJsonAsync(new
            {
                Title = "Validation Failed",
                Status = StatusCodes.Status400BadRequest,
                Errors = validationErrors
            }, cancellationToken);

            return true; 
        }

        httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
        
        await httpContext.Response.WriteAsJsonAsync(new ProblemDetails
        {
            Title = "Internal Server Error",
            Status = StatusCodes.Status500InternalServerError,
            Detail = "An unexpected error occurred in our system. Please try again later."
        }, cancellationToken);

        return true;
    }
}