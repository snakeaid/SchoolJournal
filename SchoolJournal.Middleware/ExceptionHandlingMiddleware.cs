using System.Net;
using System.Text.Json;
using MassTransit;
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

        var exceptionType = exception.GetType().ToString().Split('.').LastOrDefault();
        var exceptionMessage = exception.Message;
        if (exception is RequestFaultException faultException)
        {
            exceptionType = faultException.Fault!.Exceptions.FirstOrDefault()!.ExceptionType.Split('.')
                .LastOrDefault();
            exceptionMessage = faultException.Fault.Exceptions.FirstOrDefault()!.Message;
        }

        _logger.LogWarning(exceptionMessage);

        switch (exceptionType)
        {
            case "KeyNotFoundException":
                response.StatusCode = (int)HttpStatusCode.NotFound;
                break;
            case "ValidationException":
                response.StatusCode = (int)HttpStatusCode.BadRequest;
                break;
            default:
                response.StatusCode = (int)HttpStatusCode.InternalServerError;
                break;
        }

        await response.WriteAsync(JsonSerializer.Serialize(new
            { errorMessage = exceptionMessage }, new JsonSerializerOptions { WriteIndented = true }));
    }
}