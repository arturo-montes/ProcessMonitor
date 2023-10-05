using Azure.Storage.Queues.Models;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using ProcessMonitor.Application.Contracts;
using ProcessMonitor.Application.Features.QueueMessage.Commands;

namespace ProcessMonitor.ApiMonitorFunctions.Functions.QueueProcessing;

public class ProcessApiQueueItem
{
    private readonly ILogger<ProcessApiQueueItem> _logger;
    private readonly IProcessQueueMessageHandler _processQueueMessageHandler;

    public ProcessApiQueueItem(ILogger<ProcessApiQueueItem> logger,
        IProcessQueueMessageHandler processQueueMessageHandler,
        ICreateStorageTablesCommandHandler createStorageTablesCommand)
    {
        _logger = logger;
        _processQueueMessageHandler = processQueueMessageHandler;
        createStorageTablesCommand.Handle();
    }

    //https://learn.microsoft.com/en-us/dotnet/api/overview/azure/storage.queues-readme?view=azure-dotnet
    [Function(nameof(ProcessApiQueueItem))]
    public void Run([QueueTrigger("api-queue-items", Connection = "StorageConnectionString")] QueueMessage message)
    {
        _processQueueMessageHandler.Handle(new ProcessQueueMessageDto(message.MessageId, message.MessageText));
        _logger.LogInformation($"C# Queue trigger function processed: {message.MessageText}");
    }
}