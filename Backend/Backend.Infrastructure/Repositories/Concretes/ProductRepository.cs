using Backend.Domain.Entities.Concretes;
using Backend.Infrastructure.Context;
using Backend.Infrastructure.Repositories.Abstract;
using Backend.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Backend.Infrastructure.Repositories.Concretes;

public class ProductRepository(PostgresContext context) : BaseRepository<Product>(context), IProductRepository
{
    public override async Task<Product> AddAsync(Product entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException(nameof(entity));
        }

        await Context.Set<Product>().AddAsync(entity).ConfigureAwait(false);
        await Context.SaveChangesAsync();

        return entity;
    }


    public override async Task<IEnumerable<Product>> GetAllAsync(int page, int limit)
    {
        List<Product> products = await Context.Set<Product>()
            .Include(p => p.Store)
            .Include(p => p.Images)
            .Include(p => p.ProductVariants)
                .ThenInclude(pa => pa.Attributes)
                    .ThenInclude(a => a.Variant)
            .Include(p => p.Categories)
            .Skip((page - 1) * limit)
                .Take(limit)
                .ToListAsync()
            .ConfigureAwait(false);

        return products;
    }
    public override async Task<Product?> GetByIdAsync(Guid id)
    {
        return await Context.Set<Product>()
            .Include(p => p.Store)
            .Include(p => p.Images)
            .Include(p => p.ProductVariants)
                .ThenInclude(pa => pa.Attributes)
                .ThenInclude(pa => pa.Variant)
            .Include(p => p.Categories)
            .FirstOrDefaultAsync(p => p.Id == id)
            .ConfigureAwait(false);
    }

    public override async Task<Product> UpdateAsync(Product entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException(nameof(entity));
        }

        var existingProduct = await Context.Set<Product>().FindAsync(entity.Id);

        if (existingProduct == null)
        {
            throw new KeyNotFoundException($"Product with ID {entity.Id} not found.");
        }

        Context.Entry(existingProduct).CurrentValues.SetValues(entity);

        await Context.SaveChangesAsync();

        return existingProduct;
    }

}
