using ProcessMonitor.Application.Contracts;
using ProcessMonitor.Application.Features.ConfigurationStore.Queries.GetConfiguration;

namespace ProcessMonitor.Application.Features.QueueMessage.Commands.Process;

public class ProcessQueueMessageCommandHandler : IProcessQueueMessageCommandHandler
{
    private readonly IGetConfigurationQueryHandler _getConfigurationQuery;

    public ProcessQueueMessageCommandHandler(IGetConfigurationQueryHandler getConfigurationQuery)
    {
        _getConfigurationQuery = getConfigurationQuery;
    }

    public void Handle(ProcessQueueMessageCommandDto request)
    {
        _getConfigurationQuery.Handle(new GetConfigurationQueryDto(request.MessageText));
    }
}