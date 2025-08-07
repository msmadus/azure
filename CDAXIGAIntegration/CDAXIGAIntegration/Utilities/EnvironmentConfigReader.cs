using System;
using Microsoft.Extensions.Configuration;

namespace CDAXIGAIntegration.Utilities
{
    public static class EnvironmentConfigReader
    {
        private static IConfiguration _configuration;

        /// <summary>
        /// Initializes the configuration by loading appsettings.{ENVIRONMENT}.json and environment variables.
        /// Should be called once at application startup (e.g., in Function constructor).
        /// </summary>
        /// <param name="environmentName">Environment name like Development, Staging, Production</param>
        public static void Initialize(string environmentName)
        {
            _configuration = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile($"Configurations/Environment/appsettings.{environmentName}.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables()
                .Build();
        }

        /// <summary>
        /// Returns a strongly typed value from configuration using the key.
        /// </summary>
        public static string GetValue(string key)
        {
            if (_configuration == null)
            {
                throw new InvalidOperationException("EnvironmentConfigReader is not initialized. Call Initialize() first.");
            }

            return _configuration[key];
        }

        /// <summary>
        /// Returns a configuration section that can be deserialized.
        /// </summary>
        public static IConfigurationSection GetSection(string sectionName)
        {
            if (_configuration == null)
            {
                throw new InvalidOperationException("EnvironmentConfigReader is not initialized. Call Initialize() first.");
            }

            return _configuration.GetSection(sectionName);
        }
    }
}
