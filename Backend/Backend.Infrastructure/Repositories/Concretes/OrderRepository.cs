using Backend.Domain.Entities.Concretes;
using Backend.Infrastructure.Context;
using Backend.Infrastructure.Repositories.Interfaces;

namespace Backend.Infrastructure.Repositories.Concretes;

public class OrderRepository : BaseRepository<Order>, IOrderRepository
{
    public OrderRepository(PostgresContext context) : base(context)
    {
    }

    public override Task<Order> AddAsync(Order entity)
    {
        // TODO: Improve this
        if (entity == null)
        {
            throw new ArgumentNullException(nameof(entity));
        }

        return null;
    }

    public override Task<Order> GetByIdAsync(Guid id)
    {
        return null;
    }
}