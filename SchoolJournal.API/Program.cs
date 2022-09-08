using Microsoft.AspNetCore.Mvc;
using SchoolJournal.BusinessLogic.Extensions;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;

// Add services to the container.
builder.Logging.AddCustomLogging();
builder.Services.AddDbContexts(configuration);
builder.Services.AddMappingProfiles();
builder.Services.AddMediator();
builder.Services.AddCustomMiddleware();
builder.Services.Configure<JsonOptions>(options => options.UseDateOnlyTimeOnlyStringConverters())
    .AddControllers(options => options.UseDateOnlyTimeOnlyStringConverters());

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => c.UseDateOnlyTimeOnlyStringConverters());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCustomMiddlewares();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();