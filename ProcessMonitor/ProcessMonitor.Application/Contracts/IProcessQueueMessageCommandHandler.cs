using ProcessMonitor.Application.Features.QueueMessage.Commands.Process;

namespace ProcessMonitor.Application.Contracts;

public interface IProcessQueueMessageCommandHandler
{
    void Handle(ProcessQueueMessageCommandDto request);
}