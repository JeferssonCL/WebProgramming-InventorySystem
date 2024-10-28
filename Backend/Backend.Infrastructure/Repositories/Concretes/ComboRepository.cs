using Backend.Domain.Entities.Concretes;
using Backend.Infrastructure.Repositories.Abstract;
using Backend.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Backend.Infrastructure.Repositories.Concretes;

public class ComboRepository(DbContext context) : BaseRepository<Combo>(context), IComboRepository
{
    public override async Task<Combo> AddAsync(Combo entity)
    {
        if (entity == null) throw new ArgumentNullException(nameof(entity));

        await Context.Set<Combo>().AddAsync(entity).ConfigureAwait(false);
        await Context.SaveChangesAsync();

        return entity;
    }

    public override async Task<IEnumerable<Combo>> GetAllAsync(int page, int limit)
    {
        return await Context.Set<Combo>()
            .Include(c => c.Products)
            .Skip((page - 1) * limit)
            .Take(limit)
            .ToListAsync()
            .ConfigureAwait(false);
    }

    public override async Task<Combo?> GetByIdAsync(Guid id)
    {
        return await Context.Set<Combo>()
            .Include(c => c.Products)
            .FirstOrDefaultAsync(c => c.Id == id)
            .ConfigureAwait(false);
    }

    public override async Task<Combo> UpdateAsync(Combo entity)
    {
        if (entity == null) throw new ArgumentNullException(nameof(entity));

        var existingCombo = await Context.Set<Combo>().FindAsync(entity.Id);
        if (existingCombo == null) throw new KeyNotFoundException($"Combo with ID {entity.Id} not found.");

        Context.Entry(existingCombo).CurrentValues.SetValues(entity);
        await Context.SaveChangesAsync();

        return existingCombo;
    }
}
