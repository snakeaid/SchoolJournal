using System.Net;
using System.Text.Json;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace SchoolJournal.Middleware;

/// <summary>
/// Middleware class used to handle exceptions.
/// </summary>
public class ExceptionHandlingMiddleware : IMiddleware
{
    private readonly ILogger _logger;

    public ExceptionHandlingMiddleware(ILogger<ExceptionHandlingMiddleware> logger)
    {
        _logger = logger;
    }

    /// <summary>
    /// Tries to invoke the delegate and catches the exception if there is one.
    /// </summary>
    /// <param name="context">An instance of <see cref="HttpContext"/> class.</param>
    /// <returns><see cref="Task"/></returns>
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        var response = context.Response;
        response.ContentType = "application/json";

        var message = JsonSerializer.Serialize(new { errorMessage = Regex.Unescape(exception.Message) });

        _logger.LogWarning(Regex.Unescape(exception.Message));

        switch (exception)
        {
            case KeyNotFoundException:
                response.StatusCode = (int)HttpStatusCode.NotFound;
                break;
            default:
                response.StatusCode = (int)HttpStatusCode.InternalServerError;
                break;
        }

        await response.WriteAsync(message);
    }
}