using System.Reflection;
using FluentValidation;
using MassTransit;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SchoolJournal.BusinessLogic.Handlers;
using SchoolJournal.DataAccess;
using SchoolJournal.Mapping;
using SchoolJournal.Middleware;
using SchoolJournal.Validation;

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
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"), o => o.UseNodaTime()));

        return services;
    }

    /// <summary>
    /// Adds AutoMapper mapping profiles to the services collection.
    /// </summary>
    /// <param name="services">The collection of services.</param>
    /// <returns><see cref="IServiceCollection"/></returns>
    public static IServiceCollection AddMappingProfiles(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(StudentProfile));
        return services;
    }

    /// <summary>
    /// Adds MediatR to the services collection.
    /// </summary>
    /// <param name="services">The collection of services.</param>
    /// <returns><see cref="IServiceCollection"/></returns>
    public static IServiceCollection AddMediator(this IServiceCollection services)
    {
        services.AddMediatR(typeof(GetAllClassesHandler));
        return services;
    }

    /// <summary>
    /// Adds custom middleware to the services collection.
    /// </summary>
    /// <param name="services">The collection of services.</param>
    /// <returns><see cref="IServiceCollection"/></returns>
    public static IServiceCollection AddCustomMiddleware(this IServiceCollection services)
    {
        services.AddScoped<ExceptionHandlingMiddleware>();
        return services;
    }

    /// <summary>
    /// Adds MassTransit consumers to the services collection.
    /// </summary>
    /// <param name="services">The collection of services.</param>
    /// <returns><see cref="IServiceCollection"/></returns>
    public static IServiceCollection AddMassTransitConsumers(this IServiceCollection services)
    {
        var assembly = Assembly.GetCallingAssembly();
        services.AddMassTransit(x =>
        {
            x.AddConsumers(assembly);

            x.UsingRabbitMq((context, cfg) =>
            {
                cfg.Host("localhost", "/", h =>
                {
                    h.Username("guest");
                    h.Password("guest");
                });

                cfg.ConfigureEndpoints(context);
            });
        });
        return services;
    }

    /// <summary>
    /// Adds FluentValidation validators to the collection of services.
    /// </summary>
    /// <param name="services">The collection of services.</param>
    /// <returns><see cref="IServiceCollection"/></returns>
    public static IServiceCollection AddValidators(this IServiceCollection services)
    {
        services.AddValidatorsFromAssemblyContaining(typeof(ClassCreateModelValidator));
        return services;
    }
}