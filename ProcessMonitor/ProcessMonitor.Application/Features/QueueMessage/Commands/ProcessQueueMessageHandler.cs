using ProcessMonitor.Application.Contracts;
using ProcessMonitor.Application.Features.ConfigurationStore.Queries.GetConfiguration;

namespace ProcessMonitor.Application.Features.QueueMessage.Commands;

public class ProcessQueueMessageHandler : IProcessQueueMessageHandler
{
    private readonly IGetConfigurationQueryHandler _getConfigurationQuery;

    public ProcessQueueMessageHandler(IGetConfigurationQueryHandler getConfigurationQuery)
    {
        _getConfigurationQuery = getConfigurationQuery;
    }

    public void Handle(ProcessQueueMessageDto request)
    {
        _getConfigurationQuery.Handle(new GetConfigurationDto(request.MessageText));
    }
}