using System.Security.Authentication;
using MassTransit;
using MicroElements.Swashbuckle.NodaTime;
using NodaTime;
using NodaTime.Serialization.SystemTextJson;
using SchoolJournal.BusinessLogic.Extensions;
using Swashbuckle.AspNetCore.SwaggerUI;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;
var environment = builder.Environment;

// Add services to the container.
builder.Logging.AddCustomLogging();
builder.Services.AddDbContexts(configuration);
builder.Services.AddMappingProfiles();
builder.Services.AddMediator();
builder.Services.AddCustomMiddleware();
builder.Services.AddControllers()
    .AddJsonOptions(options => options.JsonSerializerOptions.ConfigureForNodaTime(DateTimeZoneProviders.Tzdb));
builder.Services.AddMassTransit(x =>
{
    x.UsingRabbitMq((context, cfg) =>
    {
        // if (environment.IsProduction())
        // {
        var url = Environment.GetEnvironmentVariable("RABBIT_URL");
        var port = ushort.Parse(Environment.GetEnvironmentVariable("RABBIT_PORT")!);
        var vhost = Environment.GetEnvironmentVariable("RABBIT_VHOST");
        var username = Environment.GetEnvironmentVariable("RABBIT_USERNAME");
        var password = Environment.GetEnvironmentVariable("RABBIT_PASSWORD");

        cfg.Host("shark.rmq.cloudamqp.com", 5671, "yudntuee", h =>
        {
            h.Username("yudntuee");
            h.Password("h8_qUy7Uwean7FnlwBrZWah8399WnbO2");

            h.UseSsl(s => { s.Protocol = SslProtocols.Tls12; });
        });
        // }

        cfg.ConfigureJsonSerializerOptions(options => options.ConfigureForNodaTime(DateTimeZoneProviders.Tzdb));
    });
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => c.ConfigureForNodaTimeWithSystemTextJson());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.DocExpansion(DocExpansion.None));
    app.UseHttpsRedirection();
}

app.UseCustomMiddlewares();

app.UseAuthorization();

app.MapControllers();

app.Run();