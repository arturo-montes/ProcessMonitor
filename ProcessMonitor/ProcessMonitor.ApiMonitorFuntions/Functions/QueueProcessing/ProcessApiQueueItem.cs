using Azure.Storage.Queues.Models;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace ProcessMonitor.ApiMonitorFunctions.Functions.QueueProcessing
{
    public class ProcessApiQueueItem
    {
        private readonly ILogger<ProcessApiQueueItem> _logger;

        public ProcessApiQueueItem(ILogger<ProcessApiQueueItem> logger)
        {
            _logger = logger;
        }

        [Function(nameof(ProcessApiQueueItem))]
        public void Run([QueueTrigger("api-queue-items", Connection = "StorageConnectionString")] QueueMessage message)
        {

            _logger.LogInformation($"C# Queue trigger function processed: {message.MessageText}");
        }
    }
}
