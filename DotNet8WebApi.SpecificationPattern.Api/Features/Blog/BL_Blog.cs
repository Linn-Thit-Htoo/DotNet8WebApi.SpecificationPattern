namespace DotNet8WebApi.SpecificationPattern.Api.Features.Blog;

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

    public async Task<Result<BlogResponseModel>> CreateBlog(BlogRequestModel requestModel)
    {
        Result<BlogResponseModel> responseModel;
        try
        {
            await _genericRepository.AddAsync(requestModel.Map());
            await _genericRepository.SaveChangesAsync();

            responseModel = Result<BlogResponseModel>.SaveSuccessResult();
        }
        catch (Exception ex)
        {
            responseModel = Result<BlogResponseModel>.FailureResult(ex);
        }

        return responseModel;
    }

    public async Task<Result<Tbl_Blog>> PatchBlog(BlogRequestModel requestModel, int id)
    {
        Result<Tbl_Blog> responseModel;
        try
        {
            var spec = new GetBlogByIdSpecification(x => x.BlogId == id);
            var result = await _genericRepository.GetByIdAsync(spec);
            if (result.IsError)
            {
                responseModel = result;
                goto result;
            }

            var item = result.Data;

            if (!requestModel.BlogTitle!.IsNullOrEmpty())
            {
                item.BlogTitle = requestModel.BlogTitle!;
            }

            if (!requestModel.BlogAuthor!.IsNullOrEmpty())
            {
                item.BlogAuthor = requestModel.BlogAuthor!;
            }

            if (!requestModel.BlogContent!.IsNullOrEmpty())
            {
                item.BlogContent = requestModel.BlogContent!;
            }

            _genericRepository.Update(item);
            await _genericRepository.SaveChangesAsync();

            responseModel = Result<Tbl_Blog>.UpdateSuccessResult();
        }
        catch (Exception ex)
        {
            responseModel = Result<Tbl_Blog>.FailureResult(ex);
        }

    result:
        return responseModel;
    }

    public async Task<Result<Tbl_Blog>> DeleteBlog(int id)
    {
        Result<Tbl_Blog> responseModel;
        try
        {
            var spec = new DeleteBlogSpecification(x => x.BlogId == id);
            responseModel = await _genericRepository.DeleteAsync(spec);
        }
        catch (Exception ex)
        {
            responseModel = Result<Tbl_Blog>.FailureResult(ex);
        }

        return responseModel;
    }
}
