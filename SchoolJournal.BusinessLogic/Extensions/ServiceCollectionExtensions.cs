using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SchoolJournal.DataAccess;

namespace SchoolJournal.BusinessLogic.Extensions;

/// <summary>
/// Provides extension methods for the services collection.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Adds database contexts to the services collection.
    /// </summary>
    /// <param name="services">The collection of services.</param>
    /// <param name="configuration">The application configuration.</param>
    /// <returns><see cref="IServiceCollection"/></returns>
    public static IServiceCollection AddDbContexts(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

        return services;
    }
}