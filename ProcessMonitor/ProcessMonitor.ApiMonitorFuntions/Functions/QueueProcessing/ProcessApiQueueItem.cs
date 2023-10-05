using Azure.Storage.Queues.Models;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using ProcessMonitor.Application.Contracts;
using ProcessMonitor.Application.Features.ConfigurationStore.Queries.GetConfiguration;
using ProcessMonitor.Application.Features.QueueMessage.Commands.Process;

namespace ProcessMonitor.ApiMonitorFunctions.Functions.QueueProcessing;

public class ProcessApiQueueItem
{
    private readonly ILogger<ProcessApiQueueItem> _logger;
    private readonly IProcessQueueMessageCommandHandler _processQueueMessageCommandHandler;
    private readonly IGetConfigurationQueryHandler _getConfigurationQuery;

    public ProcessApiQueueItem(ILogger<ProcessApiQueueItem> logger,
        IProcessQueueMessageCommandHandler processQueueMessageCommandHandler,
        ICreateStorageTablesCommandHandler createStorageTablesCommand,
        IGetConfigurationQueryHandler getConfigurationQuery)
    {
        _logger = logger;
        _processQueueMessageCommandHandler = processQueueMessageCommandHandler;
        _getConfigurationQuery = getConfigurationQuery;
        createStorageTablesCommand.Handle();
    }

    //https://learn.microsoft.com/en-us/dotnet/api/overview/azure/storage.queues-readme?view=azure-dotnet
    [Function(nameof(ProcessApiQueueItem))]
    public void Run([QueueTrigger("api-queue-items", Connection = "StorageConnectionString")] QueueMessage message)
    {
        var data = _getConfigurationQuery.Handle(new GetConfigurationQueryDto("zonePricing"));
        //_processQueueMessageCommandHandler.Handle(new ProcessQueueMessageCommandDto(message.MessageId, message.MessageText));
        _logger.LogInformation($"C# Queue trigger function processed: {message.MessageText}");
    }
}