using Azure.Data.Tables;
using ProcessMonitor.Application.Contracts;

namespace ProcessMonitor.Application.Features.ConfigurationStore.Queries.GetConfiguration;

public class GetConfigurationQueryHandler : IGetConfigurationQueryHandler
{
    private readonly IStorageConnectionString _connectionString;

    public GetConfigurationQueryHandler(IStorageConnectionString connectionString)
    {
        _connectionString = connectionString;
    }

    public Domain.Entities.ConfigurationStore[] Handle(GetConfigurationDto request)
    {
        var tableClient = new TableClient(_connectionString.ConnectionString,
            MonitorConstants.MonitorConfigurationTableName);
        var filter =
            $"PartitionKey eq '{MonitorConstants.MonitorConfigurationPartitionKey}' and Name eq '{request.MonitorTaskName}'";
        var queryResultsFilter =
            tableClient.Query<Domain.Entities.ConfigurationStore>(filter);
        return queryResultsFilter.ToArray();
    }
}