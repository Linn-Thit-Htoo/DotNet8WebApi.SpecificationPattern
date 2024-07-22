using DotNet8WebApi.SpecificationPattern.DbService.AppDbContexts;
using DotNet8WebApi.SpecificationPattern.Repositories.Features.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet8WebApi.SpecificationPattern.Repositories.Features.Specifications.Blog
{
    public class GetAllBlogsSpecification : BaseSpecification<Tbl_Blog>
    {
        public GetAllBlogsSpecification()
        {
            AddOrderByDescending(x => x.BlogId);
        }
    }
}
