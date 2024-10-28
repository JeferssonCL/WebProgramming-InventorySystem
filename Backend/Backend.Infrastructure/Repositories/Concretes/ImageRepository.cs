using Backend.Domain.Entities.Concretes;
using Backend.Infrastructure.Context;
using Backend.Infrastructure.Repositories.Abstract;
using Backend.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Backend.Infrastructure.Repositories.Concretes;

public class ImageRepository(PostgresContext context) : BaseRepository<Image>(context), IImageRepository
{
    public override async Task<Image> AddAsync(Image entity)
    {
        if (entity == null) throw new ArgumentNullException(nameof(entity));

        await Context.Set<Image>().AddAsync(entity).ConfigureAwait(false);
        await Context.SaveChangesAsync();

        return entity;
    }

    public override async Task<IEnumerable<Image>> GetAllAsync(int page, int limit)
    {
        return await Context.Set<Image>()
            .Include(i => i.Product)
            .Include(i => i.Combo)
            .Include(i => i.ProductVariant)
            .Skip((page - 1) * limit)
            .Take(limit)
            .ToListAsync()
            .ConfigureAwait(false);
    }

    public override async Task<Image?> GetByIdAsync(Guid id)
    {
        return await Context.Set<Image>()
            .Include(i => i.Product)
            .Include(i => i.Combo)
            .Include(i => i.ProductVariant)
            .FirstOrDefaultAsync(i => i.Id == id)
            .ConfigureAwait(false);
    }

    public override async Task<Image> UpdateAsync(Image entity)
    {
        if (entity == null) throw new ArgumentNullException(nameof(entity));

        var existingImage = await Context.Set<Image>().FindAsync(entity.Id);
        if (existingImage == null) throw new KeyNotFoundException($"Image with ID {entity.Id} not found.");

        Context.Entry(existingImage).CurrentValues.SetValues(entity);
        await Context.SaveChangesAsync();

        return existingImage;
    }
}
