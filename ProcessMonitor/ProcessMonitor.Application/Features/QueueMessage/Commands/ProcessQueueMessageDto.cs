namespace ProcessMonitor.Application.Features.QueueMessage.Commands;

public class ProcessQueueMessageDto
{
    public ProcessQueueMessageDto(string id, string messageText)
    {
        Id = id;
        MessageText = messageText;
    }

    public string Id { get; set; }

    public string MessageText { get; set; }
}