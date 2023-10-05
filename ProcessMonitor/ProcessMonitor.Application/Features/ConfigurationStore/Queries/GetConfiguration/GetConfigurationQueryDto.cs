namespace ProcessMonitor.Application.Features.ConfigurationStore.Queries.GetConfiguration;

public class GetConfigurationQueryDto
{
    public GetConfigurationQueryDto(string monitorTaskName)
    {
        MonitorTaskName = monitorTaskName;
    }

    public string MonitorTaskName { get; set; }
}