using Backend.Domain.Entities.Interfaces;
using Backend.Infrastructure.Context;
using Backend.Infrastructure.DAO.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Backend.Infrastructure.DAO.Bases;

public class GenericDAO<T>(PostgresContext context) : IGenericDAO<T>
    where T : class, IEntity
{
    public async Task CreateAsync(T entity)
    {
        context.Set<T>().Add(entity);
        await context.SaveChangesAsync();
    }

    public virtual async Task<T?> GetByIdAsync(Guid id)
    {
        return await context.Set<T>().FindAsync(id);
    }

    public virtual async Task<IEnumerable<T>> GetAllAsync()
    {
        return await context.Set<T>().ToListAsync();
    }

    public async Task UpdateAsync(T entity)
    {
        context.Set<T>().Update(entity);
        await context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var entity = await GetByIdAsync(id);
        if (entity != null)
        {
            entity.IsActive = false;
            await UpdateAsync(entity);
        }
    }
}