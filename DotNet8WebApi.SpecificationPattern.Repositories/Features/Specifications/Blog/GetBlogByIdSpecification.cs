namespace DotNet8WebApi.SpecificationPattern.Repositories.Features.Specifications.Blog;

public class GetBlogByIdSpecification : BaseSpecification<Tbl_Blog>
{
    public GetBlogByIdSpecification(Expression<Func<Tbl_Blog, bool>> criteria)
        : base(criteria) { }
}
