using System;
using System.Threading.Tasks;
using MDS_BE.Managers;
using MDS_BE.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MDS_BE.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrganizationsController : ControllerBase
    {
        public readonly IOrganizationManager manager;

        public OrganizationsController(IOrganizationManager manager)
        {
            this.manager = manager;
        }

        [HttpGet]
        [Authorize(Policy = "ALL")]
        public async Task<IActionResult> Get()
        {
            var organizations = manager.GetOrganisations();

            return Ok(organizations);
        }

        [HttpGet("{FacultyName}")]
        [Authorize(Policy = "ALL")]
        public async Task<IActionResult> GetOrganizationByName([FromRoute] string FacultyName)
        {
            var organization = manager.GetOrganizationByName(FacultyName);

            return Ok(organization);
        }

        [HttpPost]
        [Authorize(Policy = "ALL")]
        public async Task<IActionResult> Create([FromBody] OrganizationModel model)
        {
            manager.Create(model);

            return Ok();
        }

        [HttpPut]
        [Authorize(Policy = "ALL")]
        public async Task<IActionResult> Update([FromBody] OrganizationModel model)
        {
            try
            {
                manager.Update(model);

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(403);
            }
        }

        [HttpDelete("{FacultyName}")]
        [Authorize(Policy = "ALL")]
        public async Task<IActionResult> Delete([FromRoute] string FacultyName)
        {
            manager.Delete(FacultyName);

            return Ok();
        }

        [HttpPost("{organizationId}/Users")]
        [Authorize(Policy = "ALL")]
        public async Task<IActionResult> AssignUser([FromBody] OrganizationUserModel model, [FromRoute] int organizationId)
        {
            try
            {
                manager.AssignUser(model.UserId, organizationId);
            }
            catch (Exception ex)
            {
                return StatusCode(403);
            }

            return Ok();
        }

    }
}