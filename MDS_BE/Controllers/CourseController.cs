using System;
using System.Threading.Tasks;
using MDS_BE.Entities;
using MDS_BE.Managers;
using MDS_BE.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MDS_BE.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CourseController : ControllerBase
    {
        public readonly ICourseManager manager;

        public CourseController(ICourseManager manager)
        {
            this.manager = manager;
        }

        [HttpGet]
        [Authorize(Policy = "ALL")]
        public async Task<IActionResult> Get()
        {
            var posts = manager.GetCourses();

            return Ok(posts);
        }

        [HttpGet("{Name}")]
        [Authorize(Policy = "ALL")]
        public async Task<IActionResult> GetCourseByName([FromRoute] string Name)
        {
            var organization = manager.GetCourseByName(Name);

            return Ok(organization);
        }

        [HttpGet("User/{userId}")]
        [Authorize(Policy = "ALL")]
        public async Task<IActionResult> GetCoursesForUser([FromRoute] string userId)
        {
            var organizations = manager.GetCoursesForUser(userId);
            return Ok(organizations);
        }

        [HttpPost]
        [Authorize(Policy = "Prof")]
        public async Task<IActionResult> Create([FromBody] CourseModel model)
        {
            manager.Create(model);

            return Ok();
        }

        [HttpPut]
        [Authorize(Policy = "Prof")]
        public async Task<IActionResult> Update([FromBody] CourseModel model)
        {
            try
            {
                manager.Update(model);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest("This course does not exist!");
            }
        }

        [HttpDelete("{Name}")]
        [Authorize(Policy = "Prof")]
        public async Task<IActionResult> Delete([FromRoute] string Name)
        {
            manager.Delete(Name);

            return Ok();
        }

        [HttpPost("{courseId}/Users")]
        [Authorize(Policy = "Student")]
        public async Task<IActionResult> AssignUser([FromBody] CourseUserModel model, [FromRoute] int courseId)
        {
            try
            {
                manager.AssignUser(model.UserId, courseId);
            }
            catch (Exception ex)
            {
                return BadRequest("Invalid user ID!");
            }

            return Ok();
        }

        [HttpGet("{courseId}/Users")]
        [Authorize(Policy = "ALL")]
        public async Task<IActionResult> GetCourseUsers([FromRoute] int courseId)
        {
            var users = manager.GetCourseUsers(courseId);

            return Ok(users);
        }
    }
}
