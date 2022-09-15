using System.Reflection;
using System.Security.Authentication;
using FluentValidation;
using MassTransit;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NodaTime;
using NodaTime.Serialization.SystemTextJson;
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
        // services.AddDbContext<ApplicationContext>(options =>
        //     options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"), o => o.UseNodaTime()));

        services.AddDbContext<ApplicationContext>(options =>
            options.UseNpgsql("Host=ec2-3-214-2-141.compute-1.amazonaws.com;" +
                              "Port=5432;" +
                              "Database=d9u7u7h7mju6qq;" +
                              "Username=fzculihhhnzenl;" +
                              "Password=85d79066035453ae87689126bbaa5ad67d3a41cfb5d1677191cf0a22ea890c4e",
                o => o.UseNodaTime()));

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
                cfg.ConfigureJsonSerializerOptions(options => options.ConfigureForNodaTime(DateTimeZoneProviders.Tzdb));

                // if (environment.IsProduction())
                // {
                var url = Environment.GetEnvironmentVariable("RABBIT_URL");
                var port = ushort.Parse(Environment.GetEnvironmentVariable("RABBIT_PORT")!);
                var vhost = Environment.GetEnvironmentVariable("RABBIT_VHOST");
                var username = Environment.GetEnvironmentVariable("RABBIT_USERNAME");
                var password = Environment.GetEnvironmentVariable("RABBIT_PASSWORD");

                // cfg.Host(url, port, vhost, h =>
                // {
                //     h.Username(username);
                //     h.Password(password);
                // });
                cfg.Host("shark.rmq.cloudamqp.com", 5671, "yudntuee", h =>
                {
                    h.Username("yudntuee");
                    h.Password("h8_qUy7Uwean7FnlwBrZWah8399WnbO2");

                    h.UseSsl(s => { s.Protocol = SslProtocols.Tls12; });
                });
                // }

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