namespace DotNet8WebApi.SpecificationPattern.Repositories.Features.Specifications.Blog;

public class DeleteBlogSpecification : BaseSpecification<Tbl_Blog>
{
    public DeleteBlogSpecification(Expression<Func<Tbl_Blog, bool>> criteria) : base(criteria)
    {
    }
}