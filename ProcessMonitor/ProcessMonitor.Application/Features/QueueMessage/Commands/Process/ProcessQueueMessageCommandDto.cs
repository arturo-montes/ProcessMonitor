namespace ProcessMonitor.Application.Features.QueueMessage.Commands.Process;

public class ProcessQueueMessageCommandDto
{
    public ProcessQueueMessageCommandDto(string id, string messageText)
    {
        Id = id;
        MessageText = messageText;
    }

    public string Id { get; set; }

    public string MessageText { get; set; }
}