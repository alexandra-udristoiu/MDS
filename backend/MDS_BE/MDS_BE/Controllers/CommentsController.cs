using MDS_BE.Managers;
using MDS_BE.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MDS_BE.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CommentsController : ControllerBase
    {
        public readonly ICommentManager manager;

        public CommentsController(ICommentManager manager)
        {
            this.manager = manager;
        }

        [HttpGet]
        [Authorize(Policy = "ALL")]
        public async Task<IActionResult> Get()
        {
            var comments = manager.GetComments();

            return Ok(comments);
        }

        [HttpPost]
        [Authorize(Policy = "ALL")]
        public async Task<IActionResult> Create([FromBody] CommentModel model)
        {
            var identity = (ClaimsIdentity)User.Identity;
            model.UserId = identity.FindFirst("Id").Value;

            manager.Create(model);

            return Ok();
        }

        [HttpPut]
        [Authorize(Policy = "ALL")]
        public async Task<IActionResult> Update([FromBody] CommentModel model)
        {
            var identity = (ClaimsIdentity)User.Identity;
            model.UserId = identity.FindFirst("Id").Value;

            try
            {
                manager.Update(model);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest("This comment does not exist!");
            }
        }

        [HttpDelete("{id}")]
        [Authorize(Policy = "ALL")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var identity = (ClaimsIdentity)User.Identity;
            var userId = identity.FindFirst("Id").Value;

            manager.Delete(id, userId);

            return Ok();
        }
    }
}
