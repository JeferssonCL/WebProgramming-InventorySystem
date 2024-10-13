using Backend.Domain.Entities.Interfaces;

namespace Backend.Infrastructure.DAO.Interfaces;

public interface IGenericDAO<T> where T : IEntity
{
    Task CreateAsync(T entity);
    Task<T?> GetByIdAsync(Guid id);
    Task<IEnumerable<T>> GetAllAsync();
    Task UpdateAsync(T entity);
    Task DeleteAsync(Guid id);
}
