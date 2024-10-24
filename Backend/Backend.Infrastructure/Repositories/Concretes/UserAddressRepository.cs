using Backend.Domain.Entities.Concretes;
using Backend.Infrastructure.Context;
using Backend.Infrastructure.Repositories.Abstract;
using Backend.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Backend.Infrastructure.Repositories.Concretes;

public class UserAddressRepository(PostgresContext context)
    : BaseRepository<UserAddress>(context), IUserAddressRepository
{
    public override async Task<UserAddress> AddAsync(UserAddress entity)
    {
        if (entity == null) throw new ArgumentNullException(nameof(entity));

        await Context.Set<UserAddress>().AddAsync(entity).ConfigureAwait(false);
        await Context.SaveChangesAsync();

        return entity;
    }

    public override async Task<IEnumerable<UserAddress>> GetAllAsync(int page, int limit)
    {
        return await Context.Set<UserAddress>()
            .Include(ua => ua.User)
            .Skip((page - 1) * limit)
            .Take(limit)
            .ToListAsync()
            .ConfigureAwait(false);
    }

    public override async Task<UserAddress?> GetByIdAsync(Guid id)
    {
        return await Context.Set<UserAddress>()
            .Include(ua => ua.User)
            .FirstOrDefaultAsync(ua => ua.Id == id)
            .ConfigureAwait(false);
    }

    public override async Task<UserAddress> UpdateAsync(UserAddress entity)
    {
        if (entity == null) throw new ArgumentNullException(nameof(entity));

        var existingUserAddress = await Context.Set<UserAddress>().FindAsync(entity.Id);
        if (existingUserAddress == null) throw new KeyNotFoundException($"UserAddress with ID {entity.Id} not found.");

        Context.Entry(existingUserAddress).CurrentValues.SetValues(entity);
        await Context.SaveChangesAsync();

        return existingUserAddress;
    }
}
