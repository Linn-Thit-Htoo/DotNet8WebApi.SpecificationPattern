namespace DotNet8WebApi.SpecificationPattern.Models.Features.Blog;

public class BlogRequestModel
{
    public string? BlogTitle { get; set; }
    public string? BlogAuthor { get; set; }
    public string? BlogContent { get; set; }

    public Result<BlogResponseModel> IsValid()
    {
        Result<BlogResponseModel> result;

        if (BlogTitle!.IsNullOrEmpty())
        {
            result = Result<BlogResponseModel>.FailureResult("Blog Title cannot be empty.");
            goto result;
        }

        if (BlogAuthor!.IsNullOrEmpty())
        {
            result = Result<BlogResponseModel>.FailureResult("Blog Author cannot be empty.");
            goto result;
        }

        if (BlogContent!.IsNullOrEmpty())
        {
            result = Result<BlogResponseModel>.FailureResult("Blog Content cannot be empty.");
            goto result;
        }

        result = Result<BlogResponseModel>.SuccessResult();

    result:
        return result;
    }
}
