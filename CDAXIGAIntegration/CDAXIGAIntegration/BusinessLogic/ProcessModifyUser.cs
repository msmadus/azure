using CDAXIGAIntegration.DataAccess;
using CDAXIGAIntegration.Models;
using CDAXIGAIntegration.Operations;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CDAXIGAIntegration.Services
{
    public class ProcessModifyUser
    {
        private readonly DataverseOperations _dataverseOps;
        private readonly AADUserOperations _aadOps;
        private readonly ILogger<ProcessModifyUser> _logger;

        public ProcessModifyUser(
            DataverseOperations dataverseOps,
            AADUserOperations aadOps,
            ILogger<ProcessModifyUser> logger)
        {
            _dataverseOps = dataverseOps;
            _aadOps = aadOps;
            _logger = logger;
        }

        public async Task<ModifyUserResponse> HandleModifyUserAsync(ModifyUserRequest request)
        {
            var response = new ModifyUserResponse();

            if (request?.value == null || request.value.Length == 0)
            {
                response.Message = "No user data provided.";
                _logger.LogWarning("ModifyUser request received with no users.");
                return response;
            }

            _logger.LogInformation("Processing ModifyUser request with {Count} users", request.value.Length);

            foreach (var user in request.value)
            {
                try
                {
                    _logger.LogInformation("Processing user: {Email}", user.internalemailaddress);

                    // If systemuserid is present, update user in Dataverse
                    if (!string.IsNullOrEmpty(user.systemuserid))
                    {
                        _logger.LogInformation("User found in Dataverse. Updating user {Email}", user.internalemailaddress);

                        // Update user and associations in Dataverse
                        await _dataverseOps.UpdateUserAndAssociationsAsync(user);

                        // Assign license and groups in AAD (if needed)
                        // await _aadOps.AssignLicenseAndGroupsAsync(user); // Uncomment if implemented

                        response.ProcessedUsers.Add(user.internalemailaddress);
                    }
                    else
                    {
                        _logger.LogWarning("User not found in Dataverse: {Email}", user.internalemailaddress);
                        response.Message += $"User not found: {user.internalemailaddress}. Skipped.\n";
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error processing user {Email}", user.internalemailaddress);
                    response.Message += $"Error processing {user.internalemailaddress}: {ex.Message}\n";
                }
            }

            if (!response.ProcessedUsers.Any())
            {
                response.Message = "No users were processed successfully.";
            }
            else
            {
                response.Message += $"Processed {response.ProcessedUsers.Count} users successfully.";
            }

            _logger.LogInformation("ModifyUser processing completed: {Message}", response.Message);

            return response;
        }
    }
}
