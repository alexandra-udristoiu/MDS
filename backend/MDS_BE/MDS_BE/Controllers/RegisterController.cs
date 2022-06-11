using System;
using MDS_BE.Managers;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using MDS_BE.Model;

namespace MDS_BE.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RegisterController : ControllerBase
    {
        private readonly IRegisterManager manager;

        public RegisterController(IRegisterManager registerManager)
        {
            this.manager = registerManager;
        }

        [HttpGet]
        [Authorize(Policy ="ALL")]
        public async Task<IActionResult> Get()
        {
            var registers = manager.GetRegisters();

            return Ok(registers);
        }

        [HttpGet("{CourseName}")]
        [Authorize(Policy ="ALL")]
        public async Task<IActionResult> GetRegistersByCourseName([FromRoute] string CourseName)
        {
            var registers = manager.GetRegistersByCourseName(CourseName);

            return Ok(registers)
;        }

        [HttpGet("UserId/{UserId}")]
        [Authorize(Policy = "ALL")]
        public async Task<IActionResult> GetRegisterByUserId([FromRoute] string UserId)
        {
            var registers = manager.GetRegistersByUserId(UserId);

            return Ok(registers);
        }

        [HttpGet("{UserId}/CourseName/{CourseName}")]
        [Authorize(Policy = "ALL")]
        public async Task<IActionResult> GetRegisterByUserAndCourse([FromRoute]string UserId, string CourseName)
        {
            var registers = manager.GetRegisterByUserAndCourse(UserId, CourseName);

            return Ok(registers);
        }

        [HttpPost]
        [Authorize(Policy ="ALL")]
        public async Task<IActionResult> Create([FromBody] RegisterModel model)
        {
            manager.Create(model);

            return Ok();
        }

        [HttpPut]
        [Authorize(Policy ="ALL")]
        public async Task<IActionResult> Update([FromBody] RegisterModel model)
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

        [HttpDelete("{UserId}/CourseName/{CourseName}")]
        [Authorize(Policy ="ALL")]
        public async Task<IActionResult> Delete([FromRoute] string UserId, string CourseName)
        {
            manager.Delete(UserId, CourseName);

            return Ok();
        }

    }
}
