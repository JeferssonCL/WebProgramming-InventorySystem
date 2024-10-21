using Backend.Domain.Entities.Concretes;
using Backend.Infrastructure.Context;
using Backend.Infrastructure.Repositories.Abstract;
using Backend.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Backend.Infrastructure.Repositories.Concretes;

public class OrderItemRepository(PostgresContext context) : BaseRepository<OrderItem>(context), IOrderItemRepository
{
    public override async Task<OrderItem> AddAsync(OrderItem entity)
    {
        if (entity == null) throw new ArgumentNullException(nameof(entity));

        await Context.Set<OrderItem>().AddAsync(entity).ConfigureAwait(false);
        await Context.SaveChangesAsync();

        return entity;
    }

    public override async Task<IEnumerable<OrderItem>> GetAllAsync(int page, int limit)
    {
        return await Context.Set<OrderItem>()
            .Include(oi => oi.Order)
            .Include(oi => oi.Product)
            .Skip((page - 1) * limit)
            .Take(limit)
            .ToListAsync()
            .ConfigureAwait(false);
    }

    public override async Task<OrderItem?> GetByIdAsync(Guid id)
    {
        return await Context.Set<OrderItem>()
            .Include(oi => oi.Order)
            .Include(oi => oi.Product)
            .FirstOrDefaultAsync(oi => oi.Id == id)
            .ConfigureAwait(false);
    }

    public override async Task<OrderItem> UpdateAsync(OrderItem entity)
    {
        if (entity == null) throw new ArgumentNullException(nameof(entity));
        var existingOrderItem = await Context.Set<OrderItem>().FindAsync(entity.Id);

        if (existingOrderItem == null) throw new KeyNotFoundException($"OrderItem with ID {entity.Id} not found.");

        Context.Entry(existingOrderItem).CurrentValues.SetValues(entity);
        await Context.SaveChangesAsync();

        return existingOrderItem;
    }
}
