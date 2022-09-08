using Microsoft.AspNetCore.Builder;
using SchoolJournal.Middleware;

namespace SchoolJournal.BusinessLogic.Extensions;

/// <summary>
/// Provides extension methods for the application builder.
/// </summary>
public static class ApplicationBuilderExtensions
{
    /// <summary>
    /// Adds custom middlewares to the application builder.
    /// </summary>
    /// <param name="builder">The application builder.</param>
    /// <returns><see cref="IApplicationBuilder"/></returns>
    public static IApplicationBuilder UseCustomMiddlewares(this IApplicationBuilder builder)
    {
        builder.UseMiddleware<ExceptionHandlingMiddleware>();
        return builder;
    }
}