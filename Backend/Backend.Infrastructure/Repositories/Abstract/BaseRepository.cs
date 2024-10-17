using Backend.Domain.Entities.Bases;
using Backend.Infrastructure.Context;
using Backend.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Backend.Infrastructure.Repositories.Concretes;

public abstract class BaseRepository<T> : ICrudRepository<T>
where T : BaseEntity
{

    protected readonly PostgresContext _context;

    public BaseRepository(PostgresContext context)
    {
        _context = context;
    }

    public virtual Task<T> AddAsync(T entity)
    {
        _context.Set<T>().Add(entity);
        return Task.FromResult(entity);
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var entity = await GetByIdAsync(id);
        if (entity != null)
        {
            entity.IsActive = false;
            await UpdateAsync(entity);
        }
        return true;
    }
    public virtual async Task<IEnumerable<T>> GetAllAsync(int page, int limit)
    {
        return await _context.Set<T>()
            .Skip((page - 1) * limit)
            .Take(limit)
            .ToListAsync();
    }


    public virtual async Task<T?> GetByIdAsync(Guid id)
    {
        var entity = await _context.Set<T>().FindAsync(id);
        return entity;
    }

    public virtual Task<T> UpdateAsync(T entity)
    {
        entity.UpdatedAt = DateTime.Now;
        _context.Set<T>().Update(entity);
        return Task.FromResult(entity);
    }


    public async Task<int> GetCountAsync()
    {
        return await _context.Set<T>().CountAsync();
    }

}
