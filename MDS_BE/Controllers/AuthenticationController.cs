using MDS_BE.Managers;
using MDS_BE.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace MDS_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private IAuthenticationManager authenticationManager;

        public AuthenticationController(IAuthenticationManager authenticationManager)
        {
            this.authenticationManager = authenticationManager;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserModel model)
        {
            try
            {
                await authenticationManager.Register(model);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest("Something failed");
            }
        }


        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginUserModel model)
        {
            try
            {
                var tokens = await authenticationManager.Login(model);
                if (tokens != null)
                {
                    return Ok(tokens);
                }

                return BadRequest("Something failed");
            }
            catch (Exception ex)
            {
                return BadRequest("Exception caught");
            }
        }

    }
}
