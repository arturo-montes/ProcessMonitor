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


    //https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/tables/Azure.Data.Tables/samples/Sample1CreateDeleteTables.md
    public ConfigurationQueryDto[] Handle(GetConfigurationQueryDto request)
    {
        var tableClient = new TableClient(_connectionString.ConnectionString,
            MonitorConstants.MonitorConfigurationTableName);
        var filter =
            $"PartitionKey eq '{MonitorConstants.MonitorConfigurationPartitionKey}' and MonitorTaskName eq '{request.MonitorTaskName}'";
        var queryResultsFilter = tableClient.Query<TableEntity>(filter);
        var result = new List<ConfigurationQueryDto>();
        foreach (TableEntity qEntity in queryResultsFilter)
        {
            result.Add(new ConfigurationQueryDto(qEntity));
        }
        return result.ToArray();
    }
}