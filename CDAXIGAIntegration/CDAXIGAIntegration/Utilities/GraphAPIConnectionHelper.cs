using Azure.Identity;
using Microsoft.Graph;

namespace CDAXIGAIntegration.Utilities
{
    public static class GraphAPIConnectionHelper
    {
        public static GraphServiceClient GetGraphClient(string tenantId, string clientId, string clientSecret)
        {
            var credential = new ClientSecretCredential(
                tenantId,
                clientId,
                clientSecret
            );

            return new GraphServiceClient(credential);
        }
    }
}
