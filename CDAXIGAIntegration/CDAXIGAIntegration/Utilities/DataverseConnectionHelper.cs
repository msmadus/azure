using Microsoft.PowerPlatform.Dataverse.Client;
using System;

namespace CDAXIGAIntegration.Utilities
{
    public static class DataverseConnectionHelper
    {
        public static ServiceClient GetServiceClient(string connectionString)
        {
            if (string.IsNullOrWhiteSpace(connectionString))
                throw new ArgumentException("Dataverse connection string is missing.");

            return new ServiceClient(connectionString);
        }
    }
}
