using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

namespace TextAnalyzer
{
    public static class TextAnalyzerFunction
    {
        [FunctionName("TextAnalyzerFunction")]
        public static void Run([ServiceBusTrigger("myqueue", Connection = "ServiceBusConnectionString")]string myQueueItem, ILogger log)
        {
            log.LogInformation($"C# ServiceBus queue trigger function processed message: {myQueueItem}");
        }
    }
}
