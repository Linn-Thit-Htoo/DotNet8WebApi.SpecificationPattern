using DotNet8WebApi.SpecificationPattern.DbService.AppDbContexts;
using DotNet8WebApi.SpecificationPattern.Models.Features;
using DotNet8WebApi.SpecificationPattern.Repositories.Features;
using DotNet8WebApi.SpecificationPattern.Repositories.Features.Blog;

namespace DotNet8WebApi.SpecificationPattern.Api.Features.Blog
{
    public class BL_Blog
    {
        private readonly IGenericRepository<Tbl_Blog> _genericRepository;

        public BL_Blog(IGenericRepository<Tbl_Blog> genericRepository)
        {
            _genericRepository = genericRepository;
        }

        public async Task<Result<List<Tbl_Blog>>> GetBlogs()
        {
            var spec = new GetAllBlogsSpecification();
            return await _genericRepository.GetAllAsync(spec);
        }

        public async Task<Result<Tbl_Blog>> GetBlogById(int id)
        {
            var spec = new GetBlogByIdSpecification(x => x.BlogId == id);
            return await _genericRepository.GetByIdAsync(spec);
        }
    }
}
