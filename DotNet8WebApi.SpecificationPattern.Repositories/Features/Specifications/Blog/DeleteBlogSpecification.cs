using DotNet8WebApi.SpecificationPattern.DbService.AppDbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DotNet8WebApi.SpecificationPattern.Repositories.Features.Specifications.Blog
{
    public class DeleteBlogSpecification : BaseSpecification<Tbl_Blog>
    {
        public DeleteBlogSpecification(Expression<Func<Tbl_Blog, bool>> criteria) : base(criteria)
        {
        }
    }
}
