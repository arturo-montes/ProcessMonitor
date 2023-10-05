using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using ProcessMonitor.Application;

var host = new HostBuilder()
    .ConfigureFunctionsWorkerDefaults()
    .ConfigureHostConfiguration(hostConfig =>
    {
        hostConfig.AddEnvironmentVariables(prefix: "ProcessMonitor_");
    })
    .ConfigureServices(s =>
    {
        s.AddApplicationServices();
    })
    .Build();


host.Run();
