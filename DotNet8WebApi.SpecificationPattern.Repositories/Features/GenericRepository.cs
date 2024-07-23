using DotNet8WebApi.SpecificationPattern.DbService.AppDbContexts;
using DotNet8WebApi.SpecificationPattern.Models;
using DotNet8WebApi.SpecificationPattern.Models.Features;
using DotNet8WebApi.SpecificationPattern.Models.Resources;
using DotNet8WebApi.SpecificationPattern.Repositories.Features.Specifications;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet8WebApi.SpecificationPattern.Repositories.Features;

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
        Result<List<T>> responseModel;
        try
        {
            var lst = await _dbSet.AsQueryable().ApplySpecification(specification).ToListAsync();
            responseModel = Result<List<T>>.SuccessResult(lst);
        }
        catch (Exception ex)
        {
            responseModel = Result<List<T>>.FailureResult(ex);
        }

        return responseModel;
    }

    public async Task<Result<T>> GetByIdAsync(ISpecification<T> specification)
    {
        Result<T> responseModel;
        try
        {
            var item = await _dbSet.AsQueryable().ApplySpecification(specification).FirstOrDefaultAsync();
            if (item is null)
            {
                responseModel = Result<T>.NotFoundResult();
                goto result;
            }

            responseModel = Result<T>.SuccessResult(item!);
        }
        catch (Exception ex)
        {
            responseModel = Result<T>.FailureResult(ex);
        }

    result:
        return responseModel;
    }

    public async Task AddAsync(T model)
    {
        await _dbSet.AddAsync(model);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }

    public async Task<Result<T>> DeleteAsync(ISpecification<T> specification)
    {
        Result<T> responseModel;
        try
        {
            var item = await _dbSet.AsQueryable().ApplySpecification(specification).FirstOrDefaultAsync();
            if (item is null)
            {
                responseModel = Result<T>.NotFoundResult();
                goto result;
            }

            _dbSet.Remove(item);
            await SaveChangesAsync();

            responseModel = Result<T>.DeleteSuccessResult();
        }
        catch (Exception ex)
        {
            responseModel = Result<T>.FailureResult(ex);
        }

    result:
        return responseModel;
    }
}
