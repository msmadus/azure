using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CDAXIGAIntegration.Models;
using Microsoft.PowerPlatform.Dataverse.Client;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;

namespace CDAXIGAIntegration.Operations
{
    public class DataverseOperations
    {
        private readonly ServiceClient _serviceClient;

        public DataverseOperations(ServiceClient serviceClient)
        {
            _serviceClient = serviceClient ?? throw new ArgumentNullException(nameof(serviceClient));
        }

        /// <summary>
        /// Updates the user and all related associations in Dataverse
        /// </summary>
        public async Task UpdateUserAndAssociationsAsync(Value user)
        {
            if (string.IsNullOrEmpty(user.systemuserid))
            {
                Console.WriteLine($"Skipping user {user.fullname} - No systemuserid found.");
                return;
            }

            var userId = Guid.Parse(user.systemuserid);

            // Prepare fields to update
            var updateEntity = new Entity("systemuser", userId);
            AddIfNotNull(updateEntity, "firstname", user.fullname?.Split(' ').FirstOrDefault());
            AddIfNotNull(updateEntity, "lastname", user.fullname?.Split(' ').Skip(1).FirstOrDefault());
            AddIfNotNull(updateEntity, "internalemailaddress", user.internalemailaddress);

            // Example: timezone, discountlevel if needed
            if (user.hpi_usertimezone > 0)
                updateEntity["hpi_usertimezone"] = user.hpi_usertimezone;
            if (user.hpi_discountlevel > 0)
                updateEntity["hpi_discountlevel"] = user.hpi_discountlevel;

            // Update the user in Dataverse
            _serviceClient.Update(updateEntity);
            Console.WriteLine($"User {user.fullname} updated in Dataverse.");

            // Update associations
            await UpdateAssociationsAsync(userId, user);
        }

        private async Task UpdateAssociationsAsync(Guid userId, Value user)
        {
            // 1️⃣ Teams
            if (user.teammembership_association != null)
            {
                foreach (var team in user.teammembership_association)
                {
                    if (!string.IsNullOrEmpty(team.teamid))
                    {
                        var teamId = Guid.Parse(team.teamid);
                        await AssociateAsync("systemuser", userId, "teammembership_association", "team", teamId);
                    }
                }
            }

            // 2️⃣ Security Roles
            if (user.systemuserroles_association != null)
            {
                foreach (var role in user.systemuserroles_association)
                {
                    if (!string.IsNullOrEmpty(role.roleid))
                    {
                        var roleId = Guid.Parse(role.roleid);
                        await AssociateAsync("systemuser", userId, "systemuserroles_association", "role", roleId);
                    }
                }
            }

            // 3️⃣ Field Security Profiles
            if (user.systemuserprofiles_association != null)
            {
                foreach (var profile in user.systemuserprofiles_association)
                {
                    if (!string.IsNullOrEmpty(profile.fieldsecurityprofileid))
                    {
                        var profileId = Guid.Parse(profile.fieldsecurityprofileid);
                        await AssociateAsync("systemuser", userId, "systemuserprofiles_association", "fieldsecurityprofile", profileId);
                    }
                }
            }
        }

        private async Task AssociateAsync(string entity1Name, Guid entity1Id, string relationshipName, string entity2Name, Guid entity2Id)
        {
            var relationship = new Relationship(relationshipName);
            var relatedEntities = new EntityReferenceCollection
            {
                new EntityReference(entity2Name, entity2Id)
            };

            _serviceClient.Associate(entity1Name, entity1Id, relationship, relatedEntities);
            Console.WriteLine($"Associated {entity2Name} {entity2Id} with user {entity1Id}");
            await Task.CompletedTask;
        }

        private void AddIfNotNull(Entity entity, string attributeName, object value)
        {
            if (value != null && !(value is string str && string.IsNullOrWhiteSpace(str)))
            {
                entity[attributeName] = value;
            }
        }
    }
}
