using Microsoft.Extensions.Configuration;
using ProcessMonitor.Application.Contracts;

namespace ProcessMonitor.Application.Features.ConnectionString;

public class StorageConnectionString : IStorageConnectionString
{
    public StorageConnectionString(IConfiguration configuration)
    {
        var storageConnectionString = configuration[MonitorConstants.MonitorStorageEnvironmentName];
        var connectionString = storageConnectionString ??
                               throw new ArgumentNullException(
                                   $"Variable not Found. {MonitorConstants.MonitorStorageEnvironmentName}");
        ConnectionString = connectionString;
    }

    public string ConnectionString { get; set; }
}