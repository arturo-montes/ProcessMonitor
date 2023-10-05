using ProcessMonitor.Application.Features.QueueMessage.Commands;

namespace ProcessMonitor.Application.Contracts;

public interface IProcessQueueMessageHandler
{
    void Handle(ProcessQueueMessageDto request);
}