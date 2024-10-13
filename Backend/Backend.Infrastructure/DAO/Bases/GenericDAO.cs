using Backend.Domain.Entities.Interfaces;
using Backend.Infrastructure.Context;
using Backend.Infrastructure.DAO.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Backend.Infrastructure.DAO.Bases;

public class GenericDAO<T>(PostgresContext context) : IGenericDAO<T>
    where T : class, IEntity
{
    private readonly PostgresContext _context = context;

    public async Task CreateAsync(T entity)
    {
        _context.Set<T>().Add(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<T?> GetByIdAsync(int id)
    {
        return await _context.Set<T>().FindAsync(id);
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _context.Set<T>().ToListAsync();
    }

    public async Task UpdateAsync(T entity)
    {
        _context.Set<T>().Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await GetByIdAsync(id);
        if (entity != null)
        {
            entity.IsActive = false; 
            await UpdateAsync(entity);
        }
    }
}