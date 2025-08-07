using CDAXIGAIntegration.DataAccess;
using CDAXIGAIntegration.Models;
using CDAXIGAIntegration.Operations;
using CDAXIGAIntegration.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using Microsoft.PowerPlatform.Dataverse.Client;
using Newtonsoft.Json;
using System.IO;
using System.Threading.Tasks;

namespace CDAXIGAIntegration.Functions
{
    public class ModifyUser
    {
        private readonly ServiceClient _serviceClient;

        public ModifyUser(ServiceClient serviceClient)
        {
            _serviceClient = serviceClient;
        }

        [FunctionName("ModifyUser")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("ModifyUser function triggered.");

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            var data = JsonConvert.DeserializeObject<ModifyUserRequest>(requestBody);

            if (data?.value == null || data.value.Length == 0)
                return new BadRequestObjectResult("Invalid request payload.");

            var dataverseOps = new DataverseOperations(_serviceClient);

            foreach (var user in data.value)
            {
                await dataverseOps.UpdateUserAndAssociationsAsync(user);
            }

            return new OkObjectResult("Users updated successfully in Dataverse.");
        }
    }
}
