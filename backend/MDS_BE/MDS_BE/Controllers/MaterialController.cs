using MDS_BE.Managers;
using MDS_BE.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MDS_BE.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MaterialController : Controller
    {
        public readonly IMaterialManager manager;

        public MaterialController(IMaterialManager manager)
        {
            this.manager = manager;
        }

        [HttpGet]
        [Authorize(Policy = "ALL")]
        public async Task<IActionResult> Get()
        {
            var posts = manager.GetMaterials();

            return Ok(posts);
        }

        [HttpPost]
        [Authorize(Policy = "ALL")]
        public async Task<IActionResult> Create([FromBody] MaterialModel model)
        {
            manager.Create(model);

            return Ok();
        }

        [HttpPut]
        [Authorize(Policy = "ALL")]
        public async Task<IActionResult> Update([FromBody] MaterialModel model)
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

        [HttpDelete("{MaterialId}")]
        [Authorize(Policy = "ALL")]
        public async Task<IActionResult> Delete([FromRoute] int MaterialId)
        {
            manager.Delete(MaterialId);

            return Ok();
        }

    }
}