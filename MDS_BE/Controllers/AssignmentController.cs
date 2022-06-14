using MDS_BE.Managers;
using MDS_BE.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MDS_BE.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AssignmentController : Controller
    {
        public readonly IAssignmentManager manager;

        public AssignmentController(IAssignmentManager manager)
        {
            this.manager = manager;
        }

        [HttpGet]
        [Authorize(Policy = "ALL")]
        public async Task<IActionResult> Get()
        {
            var assignments = manager.GetAssignments();

            return Ok(assignments);
        }        
        
        [HttpGet("Course-Assignment")]
        [Authorize(Policy = "ALL")]
        public async Task<IActionResult> GetCourseAssignments(int courseId)
        {
            var assignments = manager.GetCourseAssignments(courseId);

            return Ok(assignments);
        }


        [HttpPost]
        [Authorize(Policy = "ALL")]
        public async Task<IActionResult> Create([FromBody] AssignmentModel model)
        {
            manager.Create(model);

            return Ok();
        }

        [HttpPut]
        [Authorize(Policy = "ALL")]
        public async Task<IActionResult> Update([FromBody] AssignmentModel model)
        {
            try
            {
                manager.Update(model);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest("This assignment does not exist!");
            }
        }

        [HttpDelete("{AssignmentId}")]
        [Authorize(Policy = "ALL")]
        public async Task<IActionResult> Delete([FromRoute] int AssignmentId)
        {
            manager.Delete(AssignmentId);

            return Ok();
        }


    }
}
