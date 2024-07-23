using DotNet8WebApi.SpecificationPattern.Repositories.Features.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet8WebApi.SpecificationPattern.Repositories.Features.Specifications.Blog
{
    public class GetBlogByIdSpecification : BaseSpecification<Tbl_Blog>
    {
        public GetBlogByIdSpecification(Expression<Func<Tbl_Blog, bool>> criteria) : base(criteria)
        {
        }
    }
}
