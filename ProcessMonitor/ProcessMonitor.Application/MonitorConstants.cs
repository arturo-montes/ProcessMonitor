namespace ProcessMonitor.Application;

internal static class MonitorConstants
{
    internal const string MonitorStorageEnvironmentName = "ProcessMonitor_StorateConnectionString";

    internal const string MonitorLogTableName = "logs";

    internal const string MonitorLogTablePartitionKey = "MonitorLog";

    internal const string MonitorConfigurationTableName = "configurations";

    internal const string MonitorConfigurationPartitionKey = "TaskToMonitor";

}