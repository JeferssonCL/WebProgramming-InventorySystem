using Backend.Domain.Entities.Concretes;
using Backend.Infrastructure.Context;
using Backend.Infrastructure.Repositories.Abstract;
using Backend.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Backend.Infrastructure.Repositories.Concretes;

public class UserRepository(PostgresContext context) : BaseRepository<User>(context), IUserRepository
{
    public override async Task<User> AddAsync(User entity)
    {
        if (entity == null) throw new ArgumentNullException(nameof(entity));

        await Context.Set<User>().AddAsync(entity).ConfigureAwait(false);
        await Context.SaveChangesAsync();

        return entity;
    }

    public override async Task<IEnumerable<User>> GetAllAsync(int page, int limit)
    {
        return await Context.Set<User>()
            .Include(u => u.Orders)
            .Include(u => u.Stores)
            .Include(u => u.Addresses)
            .Skip((page - 1) * limit)
            .Take(limit)
            .ToListAsync()
            .ConfigureAwait(false);
    }

    public override async Task<User?> GetByIdAsync(Guid id)
    {
        return await Context.Set<User>()
            .Include(u => u.Orders)
            .Include(u => u.Stores)
            .Include(u => u.Addresses)
            .FirstOrDefaultAsync(u => u.Id == id)
            .ConfigureAwait(false);
    }

    public Task<User?> GetUserByIdentityId(string identityId)
    {
        return Context.Set<User>().FirstOrDefaultAsync(u => u.IdentityId == identityId);
    }

    public override async Task<User> UpdateAsync(User entity)
    {
        if (entity == null) throw new ArgumentNullException(nameof(entity));

        var existingUser = await Context.Set<User>().FindAsync(entity.Id);
        if (existingUser == null) throw new KeyNotFoundException($"User with ID {entity.Id} not found.");

        Context.Entry(existingUser).CurrentValues.SetValues(entity);
        await Context.SaveChangesAsync();

        return existingUser;
    }
}
