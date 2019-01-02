using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;namespace SimpleHTTPFunc
{
    public static class ActivityFunctions
    {
        [FunctionName("DurableFunction")]
        public static async Task<List<string>> RunOrchestrator(
           [OrchestrationTrigger] DurableOrchestrationContext context,
           ILogger log)
        {
            var outputs = new List<string>();

            // Replace "hello" with the name of your Durable Activity Function.
            outputs.Add(await context.CallActivityAsync<string>("DurableFunction_Hello", "Tokyo"));
            outputs.Add(await context.CallActivityAsync<string>("DurableFunction_Hello", "Seattle"));
            outputs.Add(await context.CallActivityAsync<string>("DurableFunction_Hello", "London"));

            // returns ["Hello Tokyo!", "Hello Seattle!", "Hello London!"]

            return outputs;
        }

        [FunctionName("DurableFunction_Hello")]
        public static string SayHello([ActivityTrigger] string name, ILogger log)
        {
            log.LogInformation($"Saying hello to {name}.");
            //System.Debug.WriteLine("hoi");
            return $"Hello {name}!";
        }
    }
}
