using System.Linq;
using System.Threading.Tasks;
using Microsoft.Graph;
using Microsoft.Graph.Models;

namespace CDAXIGAIntegration.DataAccess
{
    public class AADUserOperations
    {
        private readonly GraphServiceClient _graphClient;

        public AADUserOperations(GraphServiceClient graphClient)
        {
            _graphClient = graphClient;
        }

        public async Task<User?> GetUserByEmailAsync(string email)
        {
            var users = await _graphClient.Users
                .GetAsync(requestConfiguration =>
                {
                    requestConfiguration.QueryParameters.Filter = $"mail eq '{email}' or userPrincipalName eq '{email}'";
                });

            return users?.Value?.FirstOrDefault();
        }

        public async Task AddUserToGroupAsync(string userId, string groupId)
        {
            await _graphClient.Groups[groupId].Members.Ref.PostAsync(new ReferenceCreate
            {
                OdataId = $"https://graph.microsoft.com/v1.0/directoryObjects/{userId}"
            });
        }

        public async Task RemoveUserFromGroupAsync(string userId, string groupId)
        {
            await _graphClient.Groups[groupId].Members[userId].Ref.DeleteAsync();
        }
    }
}
