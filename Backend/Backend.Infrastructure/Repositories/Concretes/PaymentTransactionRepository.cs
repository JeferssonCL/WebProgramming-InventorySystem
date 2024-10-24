using Backend.Domain.Entities.Concretes;
using Backend.Infrastructure.Context;
using Backend.Infrastructure.Repositories.Abstract;
using Backend.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Backend.Infrastructure.Repositories.Concretes;

public class PaymentTransactionRepository(PostgresContext context)
    : BaseRepository<PaymentTransaction>(context), IPaymentTransactionRepository
{
    public override async Task<PaymentTransaction> AddAsync(PaymentTransaction entity)
    {
        if (entity == null)throw new ArgumentNullException(nameof(entity));

        await Context.Set<PaymentTransaction>().AddAsync(entity).ConfigureAwait(false);
        await Context.SaveChangesAsync();

        return entity;
    }

    public override async Task<IEnumerable<PaymentTransaction>> GetAllAsync(int page, int limit)
    {
        return await Context.Set<PaymentTransaction>()
            .Include(pt => pt.Order)
            .Skip((page - 1) * limit)
            .Take(limit)
            .ToListAsync()
            .ConfigureAwait(false);
    }

    public override async Task<PaymentTransaction?> GetByIdAsync(Guid id)
    {
        return await Context.Set<PaymentTransaction>()
            .Include(pt => pt.Order)
            .FirstOrDefaultAsync(pt => pt.Id == id)
            .ConfigureAwait(false);
    }

    public override async Task<PaymentTransaction> UpdateAsync(PaymentTransaction entity)
    {
        if (entity == null) throw new ArgumentNullException(nameof(entity));

        var existingTransaction = await Context.Set<PaymentTransaction>().FindAsync(entity.Id);
        if (existingTransaction == null) throw new KeyNotFoundException($"PaymentTransaction with ID {entity.Id} not found.");

        Context.Entry(existingTransaction).CurrentValues.SetValues(entity);
        await Context.SaveChangesAsync();

        return existingTransaction;
    }
}
