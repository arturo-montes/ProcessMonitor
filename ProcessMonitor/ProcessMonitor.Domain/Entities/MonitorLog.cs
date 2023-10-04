using Azure;
using Azure.Data.Tables;

namespace ProcessMonitor.Domain.Entities;

public class MonitorLog : ITableEntity
{
    public MonitorLog(string partitionKey, string rowKey)
    {
        PartitionKey = partitionKey;
        RowKey = rowKey;
    }

    public MonitorLog()
    {
    }

    public string Details { get; set; } = string.Empty;

    public DateTime Created { get; set; }

    public string PartitionKey { get; set; }

    public string RowKey { get; set; }

    public DateTimeOffset? Timestamp { get; set; }

    public ETag ETag { get; set; }
}