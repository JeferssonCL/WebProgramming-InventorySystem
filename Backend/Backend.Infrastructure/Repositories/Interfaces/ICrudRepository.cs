using Backend.Domain.Entities.Bases;
namespace Backend.Infrastructure.Repositories.Interfaces;

public interface ICrudRepository<T> where T : BaseEntity
{
    Task<T> AddAsync(T entity);
    Task<T> UpdateAsync(T entity);
    Task<bool> DeleteAsync(Guid id);
    Task<T?> GetByIdAsync(Guid id);
    Task<IEnumerable<T>> GetAllAsync(int pageNumber, int pageSize);
    Task<int> GetCountAsync();
}