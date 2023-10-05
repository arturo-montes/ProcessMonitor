using Azure.Data.Tables;

namespace ProcessMonitor.Application.Features.ConfigurationStore.Queries.GetConfiguration;

public class ConfigurationQueryDto
{
    public ConfigurationQueryDto(TableEntity sourceEntity)
    {
        OData = sourceEntity.GetString("OData");
        Recipients = sourceEntity.GetString("Recipients");
        MinimumCount = sourceEntity.GetInt32("MinimumCount");
        MonitorTaskName = sourceEntity.GetString("MonitorTaskName");
    }

    public string OData { get; set; }

    public string Recipients { get; set; }

    public int? MinimumCount { get; set; }

    public string MonitorTaskName { get; set; }
}