using Azure;
using Azure.Data.Tables;

namespace ProcessMonitor.Domain.Entities;

public class ConfigurationStore : ITableEntity
{
    public ConfigurationStore(string partitionKey, string rowKey)
    {
        PartitionKey = partitionKey;
        RowKey = rowKey;
    }

    public string OData { get; set; } = string.Empty;

    public string Recipients { get; set; }

    public int MinimumCount { get; set; }

    public string MonitorTaskName { get; set; }

    public string PartitionKey { get; set; }

    public string RowKey { get; set; }

    public DateTimeOffset? Timestamp { get; set; }

    public ETag ETag { get; set; }
}