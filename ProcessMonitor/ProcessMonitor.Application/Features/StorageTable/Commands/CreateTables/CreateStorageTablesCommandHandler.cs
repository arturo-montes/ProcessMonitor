using Azure.Data.Tables;
using ProcessMonitor.Application.Contracts;

namespace ProcessMonitor.Application.Features.StorageTable.Commands.CreateTables;

public class CreateStorageTablesCommandHandler : ICreateStorageTablesCommandHandler
{
    private readonly IStorageConnectionString _connectionString;

    public CreateStorageTablesCommandHandler(IStorageConnectionString connectionString)
    {
        _connectionString = connectionString;
    }

    public void Handle()
    {
        var serviceClient = new TableServiceClient(_connectionString.ConnectionString);
        serviceClient.CreateTableIfNotExists(MonitorConstants.MonitorLogTableName);
        serviceClient.CreateTableIfNotExists(MonitorConstants.MonitorConfigurationTableName);
    }
}