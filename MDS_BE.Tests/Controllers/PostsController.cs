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
    public class PostsController : ControllerBase
    {
        public readonly IPostManager manager;
        public readonly ICommentManager commentManager;

        public PostsController(IPostManager manager, ICommentManager commentManager)
        {
            this.manager = manager;
            this.commentManager = commentManager;
        }

        [HttpGet]
        [Authorize(Policy = "ALL")]
        public async Task<IActionResult> Get()
        {
            var posts = manager.GetPosts();

            return Ok(posts);
        }

        [HttpPost]
        [Authorize(Policy = "ALL")]
        public async Task<IActionResult> Create([FromBody] PostModel model)
        {
            var identity = (ClaimsIdentity)User.Identity;
            model.UserId = identity.FindFirst("Id").Value;

            manager.Create(model);

            return Ok();
        }

        [HttpPut]
        [Authorize(Policy = "ALL")]
        public async Task<IActionResult> Update([FromBody] PostModel model)
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
                return BadRequest("This post does not exist!");
            }
        }

        [HttpDelete("{postId}")]
        [Authorize(Policy = "ALL")]
        public async Task<IActionResult> Delete([FromRoute] int postId)
        {
            var identity = (ClaimsIdentity)User.Identity;
            var userId = identity.FindFirst("Id").Value;

            manager.Delete(postId, userId);

            return Ok();
        }

        [HttpGet("{postId}/Comments")]
        [Authorize(Policy = "ALL")]
        public async Task<IActionResult> GetPostComments([FromRoute] int postId)
        {

            var comments = commentManager.GetPostComments(postId);

            return Ok(comments);
        }

        [HttpDelete("{postId}/Comments/{commentId}")]
        [Authorize(Policy = "ALL")]
        public async Task<IActionResult> DeleteComment([FromRoute] int postId, int commentId)
        {
            var identity = (ClaimsIdentity)User.Identity;
            var userId = identity.FindFirst("Id").Value;

            commentManager.DeleteComment(userId, postId, commentId);

            return Ok();
        }

        [HttpPatch("{postId}/Comments/{commentId}")]
        [Authorize(Policy = "ALL")]
        public async Task<IActionResult> EditComment([FromBody] CommentModel model, [FromRoute] int postId, int commentId)
        {
            var identity = (ClaimsIdentity)User.Identity;
            model.UserId = identity.FindFirst("Id").Value;
            model.PostId = postId;
            model.Id = commentId;

            try
            {
                commentManager.Update(model);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest("This comment does not exist!");
            }
        }

        [HttpPost("{postId}/Comments")]
        [Authorize(Policy = "ALL")]
        public async Task<IActionResult> Create([FromBody] CommentModel model, [FromRoute] int postId)
        {
            var identity = (ClaimsIdentity)User.Identity;
            model.UserId = identity.FindFirst("Id").Value;
            model.PostId = postId;

            commentManager.Create(model);

            return Ok();
        }

        [HttpGet("{postId}")]
        [Authorize(Policy = "ALL")]
        public async Task<IActionResult> GetAnyPostById([FromRoute] int postId)
        {
            var post = manager.GetAnyPostById(postId);

            return Ok(post);
        }
    }
}
