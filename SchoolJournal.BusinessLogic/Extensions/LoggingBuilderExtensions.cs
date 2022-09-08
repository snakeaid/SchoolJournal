using Microsoft.Extensions.Logging;
using Serilog;

namespace SchoolJournal.BusinessLogic.Extensions;

/// <summary>
/// Provides extension methods for the logging builder.
/// </summary>
public static class LoggingBuilderExtensions
{
    /// <summary>
    /// Adds custom logging to the logging builder.
    /// </summary>
    /// <param name="logging">The logging builder.</param>
    /// <returns><see cref="ILoggingBuilder"/></returns>
    public static ILoggingBuilder AddCustomLogging(this ILoggingBuilder logging)
    {
        var logger = new LoggerConfiguration()
            .MinimumLevel.Information()
            .WriteTo.Console()
            .WriteTo.File("../Logs/app-.log", rollingInterval: RollingInterval.Day,
                outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj}{NewLine}{Exception}")
            .CreateLogger();
        logging.ClearProviders();
        logging.AddSerilog(logger);
        return logging;
    }
}