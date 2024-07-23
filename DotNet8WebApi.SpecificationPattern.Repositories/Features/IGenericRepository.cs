namespace DotNet8WebApi.SpecificationPattern.Repositories.Features;

public interface IGenericRepository<T>
    where T : class
{
    Task<Result<List<T>>> GetAllAsync(ISpecification<T> specification);
    Task<Result<T>> GetByIdAsync(ISpecification<T> specification);
    Task AddAsync(T model);
    void Update(T model);
    Task<Result<T>> DeleteAsync(ISpecification<T> specification);
    Task SaveChangesAsync();
}
