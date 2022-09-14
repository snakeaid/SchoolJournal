using System.Reflection;
using SchoolJournal.BusinessLogic.Extensions;

var configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddUserSecrets(Assembly.GetExecutingAssembly())
    .Build();

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddDbContexts(configuration);
        services.AddMappingProfiles();
        services.AddValidators();
        services.AddMassTransitConsumers();
    })
    .ConfigureLogging(logging => logging.AddCustomLogging())
    .Build();

await host.RunAsync();