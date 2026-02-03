using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization; // <--- 1. AGREGAMOS ESTA LIBRERÍA

namespace backend
{
    public class GetResumeCounter
    {
        private readonly ILogger<GetResumeCounter> _logger;

        public GetResumeCounter(ILogger<GetResumeCounter> logger)
        {
            _logger = logger;
        }

        [Function("GetResumeCounter")]
        public MultiResponse Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequest req,
            [CosmosDBInput(
                databaseName: "AzureResume",
                containerName: "Counter",
                Connection = "CosmosDbConnectionString",
                Id = "1",
                PartitionKey = "1")] Counter? input)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            // Si no existe, creamos uno nuevo
            if (input == null)
            {
                input = new Counter { Id = "1", Count = 0 };
            }

            // Aumentamos contador
            input.Count += 1;

            return new MultiResponse()
            {
                SavedCounter = input,
                HttpResponse = new OkObjectResult(input)
            };
        }
    }

    public class MultiResponse
    {
        [CosmosDBOutput(
            databaseName: "AzureResume",
            containerName: "Counter",
            Connection = "CosmosDbConnectionString",
            CreateIfNotExists = true)]
        public Counter? SavedCounter { get; set; }

        [HttpResult]
        public IActionResult? HttpResponse { get; set; }
    }

    // 2. AQUÍ ESTÁ EL CAMBIO IMPORTANTE
    public class Counter
    {
        [JsonPropertyName("id")] // Le dice a Cosmos: "Usa minúscula 'id'"
        public string? Id { get; set; }

        [JsonPropertyName("count")] // Le dice a Cosmos: "Usa minúscula 'count'"
        public int Count { get; set; }
    }
}