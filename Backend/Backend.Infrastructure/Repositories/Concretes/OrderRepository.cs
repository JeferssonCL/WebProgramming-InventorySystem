using Backend.Domain.Entities.Concretes;
using Backend.Infrastructure.Context;
using Backend.Infrastructure.Repositories.Abstract;
using Backend.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Backend.Infrastructure.Repositories.Concretes;

public class OrderRepository(DbContext context) : BaseRepository<Order>(context), IOrderRepository
{
    public override async Task<Order> AddAsync(Order entity)
    {
        if (entity == null) throw new ArgumentNullException(nameof(entity));

        await Context.Set<Order>().AddAsync(entity).ConfigureAwait(false);
        await Context.SaveChangesAsync();

        return entity;
    }

    public override async Task<IEnumerable<Order>> GetAllAsync(int page, int limit)
    {
        return await Context.Set<Order>()
            .Include(o => o.User)
            .Include(o => o.PaymentTransaction)
            .Include(o => o.OrderItems)
            .ThenInclude(oi => oi.Product)
            .Skip((page - 1) * limit)
            .Take(limit)
            .ToListAsync()
            .ConfigureAwait(false);
    }

    public override async Task<Order?> GetByIdAsync(Guid id)
    {
        return await Context.Set<Order>()
            .Include(o => o.User)
            .Include(o => o.PaymentTransaction)
            .Include(o => o.OrderItems)
            .ThenInclude(oi => oi.Product)
            .FirstOrDefaultAsync(o => o.Id == id)
            .ConfigureAwait(false);
    }

    public override async Task<Order> UpdateAsync(Order entity)
    {
        if (entity == null) throw new ArgumentNullException(nameof(entity));

        var existingOrder = await Context.Set<Order>().FindAsync(entity.Id);
        if (existingOrder == null) throw new KeyNotFoundException($"Order with ID {entity.Id} not found.");

        Context.Entry(existingOrder).CurrentValues.SetValues(entity);
        await Context.SaveChangesAsync();

        return existingOrder;
    }
}

