using MDS_BE.Managers;
using MDS_BE.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using System;

namespace MDS_BE.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        public readonly IUserManager manager;

        public UsersController(IUserManager usersManager)
        {
            this.manager = usersManager;
        }

        [HttpGet]
        [Authorize(Policy = "ALL")]
        public async Task<IActionResult> Get()
        {
            var users = manager.GetUsers();

            return Ok(users);
        }

        [HttpPatch]
        [Authorize(Policy = "Prof")]
        public async Task<IActionResult> Update([FromBody] UserModel model)
        {
            var identity = (ClaimsIdentity)User.Identity;
            string userId = identity.FindFirst("Id").Value;

            model.Id = userId;

            manager.Update(model);

            return Ok();
        }

        [HttpDelete("{id}")]
        [Authorize(Policy = "Prof")]
        public async Task<IActionResult> Delete([FromRoute] string id)
        {
            manager.Delete(id);

            return Ok();
        }


        [HttpPost("{userId}/Organizations")]
        [Authorize(Policy = "ALL")]
        public async Task<IActionResult> AssignOrganization([FromBody] UserOrganizationModel model, [FromRoute] string userId)
        {
            manager.AssignOrganization(userId, model.OrganizationId);

            return Ok();
        }
    }

}