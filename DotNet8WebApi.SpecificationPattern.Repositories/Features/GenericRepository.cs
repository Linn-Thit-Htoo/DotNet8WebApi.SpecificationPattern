using DotNet8WebApi.SpecificationPattern.DbService.AppDbContexts;
using DotNet8WebApi.SpecificationPattern.Models;
using DotNet8WebApi.SpecificationPattern.Models.Features;
using DotNet8WebApi.SpecificationPattern.Repositories.Features.Specifications;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet8WebApi.SpecificationPattern.Repositories.Features
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly AppDbContext _context;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(AppDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task<Result<List<T>>> GetAllAsync(ISpecification<T> specification)
        {
            var lst = await _dbSet.AsQueryable().ApplySpecification(specification).ToListAsync();
            return Result<List<T>>.SuccessResult(lst);
        }

        public async Task<Result<T>> GetByIdAsync(ISpecification<T> specification)
        {
            var item = await _dbSet.AsQueryable().ApplySpecification(specification).FirstOrDefaultAsync();
            return Result<T>.SuccessResult(item!);
        }
    }
}
