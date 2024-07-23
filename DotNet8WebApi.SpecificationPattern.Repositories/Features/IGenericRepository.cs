using DotNet8WebApi.SpecificationPattern.Models;
using DotNet8WebApi.SpecificationPattern.Models.Features;
using DotNet8WebApi.SpecificationPattern.Repositories.Features.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet8WebApi.SpecificationPattern.Repositories.Features
{
    public interface IGenericRepository<T> where T : class
    {
        Task<Result<List<T>>> GetAllAsync(ISpecification<T> specification);
        Task<Result<T>> GetByIdAsync(ISpecification<T> specification);
        Task AddAsync(T model);
        Task<Result<T>> DeleteAsync(ISpecification<T> specification);
        Task SaveChangesAsync();
    }
}
