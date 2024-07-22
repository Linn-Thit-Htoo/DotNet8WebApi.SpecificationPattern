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
            var lst = await _bL_Blog.GetBlogs();
            return Content(lst);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBlogById(int id)
        {
            var item = await _bL_Blog.GetBlogById(id);
            return Content(item);
        }
    }
}
