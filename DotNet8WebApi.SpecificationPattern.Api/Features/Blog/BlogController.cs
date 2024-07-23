using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotNet8WebApi.SpecificationPattern.Api.Features.Blog
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : BaseController
    {
        private readonly BL_Blog _bL_Blog;

        public BlogController(BL_Blog bL_Blog)
        {
            _bL_Blog = bL_Blog;
        }

        [HttpGet]
        public async Task<IActionResult> GetBlogs()
        {
            var result = await _bL_Blog.GetBlogs();
            return Content(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBlogById(int id)
        {
            var result = await _bL_Blog.GetBlogById(id);
            return Content(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBlog([FromBody] BlogRequestModel requestModel)
        {
            var result = requestModel.IsValid();
            if (result.IsError)
            {
                return BadRequest(result);
            }

            result = await _bL_Blog.CreateBlog(requestModel);
            return Content(result);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> PatchBlog([FromBody] BlogRequestModel requestModel, int id)
        {
            var result = await _bL_Blog.PatchBlog(requestModel, id);
            return Content(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBlog(int id)
        {
            var result = await _bL_Blog.DeleteBlog(id);
            return Content(result);
        }
    }
}
