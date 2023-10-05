namespace ProcessMonitor.Application.Features.ConfigurationStore.Queries.GetConfiguration;

public class GetConfigurationDto
{
    public GetConfigurationDto(string monitorTaskName)
    {
        MonitorTaskName = monitorTaskName;
    }

    public string MonitorTaskName { get; set; }
}