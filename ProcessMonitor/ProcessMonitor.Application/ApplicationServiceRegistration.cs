using Microsoft.Extensions.DependencyInjection;
using ProcessMonitor.Application.Contracts;
using ProcessMonitor.Application.Features.ConfigurationStore.Queries.GetConfiguration;
using ProcessMonitor.Application.Features.ConnectionString;
using ProcessMonitor.Application.Features.QueueMessage.Commands;
using ProcessMonitor.Application.Features.StorageTable.Commands.CreateTables;

namespace ProcessMonitor.Application;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddSingleton<IStorageConnectionString, StorageConnectionString>();
        services.AddSingleton<ICreateStorageTablesCommandHandler, CreateStorageTablesCommandHandler>();
        services.AddScoped<IGetConfigurationQueryHandler, GetConfigurationQueryHandler>();
        services.AddScoped<IProcessQueueMessageHandler, ProcessQueueMessageHandler>();

        return services;
    }
}