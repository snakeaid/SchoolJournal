using MassTransit;
using MicroElements.Swashbuckle.NodaTime;
using NodaTime;
using NodaTime.Serialization.SystemTextJson;
using SchoolJournal.BusinessLogic.Extensions;
using Swashbuckle.AspNetCore.SwaggerUI;

var builder = WebApplication.CreateBuilder(args);

// builder.WebHost.UseKestrel(options =>
//     options.ListenAnyIP(Int32.Parse(Environment.GetEnvironmentVariable("PORT")!)));

var configuration = builder.Configuration;

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
    app.UseHttpsRedirection();
}

app.UseSwagger();
app.UseSwaggerUI(c => c.DocExpansion(DocExpansion.None));

app.UseCustomMiddlewares();

app.UseAuthorization();

app.MapControllers();

app.Run();