using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using RingCentral;

namespace com.ringcentral.demos
{
    public static class CallRingCentral
    {
        [FunctionName("CallRingCentral")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            var clientId = req.Query["clientId"];
            var clientSecret = req.Query["clientSecret"];
            var username = req.Query["username"];
            var extension = req.Query["extension"];
            var password = req.Query["password"];
            
            var rc = new RestClient(clientId, clientSecret, true);
            await rc.Authorize(username, extension, password);
            var r = await rc.Restapi().Account().Extension().CallLog().List();

            return new OkObjectResult(JsonConvert.SerializeObject(r, Formatting.Indented));
        }
    }
}
