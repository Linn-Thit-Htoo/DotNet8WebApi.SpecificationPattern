namespace DotNet8WebApi.SpecificationPattern.Repositories.Features.Specifications.Blog;

public class GetAllBlogsSpecification : BaseSpecification<Tbl_Blog>
{
    public GetAllBlogsSpecification()
    {
        AddOrderByDescending(x => x.BlogId);
    }
}
