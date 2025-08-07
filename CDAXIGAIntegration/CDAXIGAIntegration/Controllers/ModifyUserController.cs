using CDAXIGAIntegration.Models;
using CDAXIGAIntegration.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CDAXIGAIntegration.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ModifyUserController : ControllerBase
    {
        private readonly ProcessModifyUser _processModifyUser;

        public ModifyUserController(ProcessModifyUser processModifyUser)
        {
            _processModifyUser = processModifyUser;
        }

        [HttpPost]
        public async Task<IActionResult> ModifyUser([FromBody] ModifyUserRequest request)
        {
            if (request?.value == null || request.value.Length == 0)
                return BadRequest(new ModifyUserResponse { Message = "No user data provided." });

            var response = await _processModifyUser.HandleModifyUserAsync(request);

            if (response.ProcessedUsers == null || response.ProcessedUsers.Count == 0)
                return StatusCode(500, response); // Or another appropriate status

            return Ok(response);
        }
    }
}