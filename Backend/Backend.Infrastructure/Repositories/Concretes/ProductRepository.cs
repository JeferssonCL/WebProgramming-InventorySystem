using Backend.Domain.Entities.Concretes;
using Backend.Infrastructure.Context;
using Backend.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Backend.Infrastructure.Repositories.Concretes;

public class ProductRepository : BaseRepository<Product>, IProductRepository
{
    public ProductRepository(PostgresContext context) : base(context) { }

    public override async Task<Product> AddAsync(Product entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException(nameof(entity));
        }

        await _context.Set<Product>().AddAsync(entity).ConfigureAwait(false);
        await _context.SaveChangesAsync();

        return entity;
    }


    public override async Task<IEnumerable<Product>> GetAllAsync(int page, int limit)
    {
        List<Product> products = await _context.Set<Product>()
            .Include(p => p.Store)
            .Include(p => p.Images)
            .Include(p => p.ProductAttributes)
                .ThenInclude(pa => pa.Variant)
            .Include(p => p.Categories)
            .Skip((page - 1) * limit)
                .Take(limit)
                .ToListAsync()
            .ConfigureAwait(false);

        return products;
    }
    public override async Task<Product?> GetByIdAsync(Guid id)
    {
        return await _context.Set<Product>()
            .Include(p => p.Store)
            .Include(p => p.Images)
            .Include(p => p.ProductAttributes)
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

        var existingProduct = await _context.Set<Product>().FindAsync(entity.Id);

        if (existingProduct == null)
        {
            throw new KeyNotFoundException($"Product with ID {entity.Id} not found.");
        }

        _context.Entry(existingProduct).CurrentValues.SetValues(entity);

        await _context.SaveChangesAsync();

        return existingProduct;
    }

}
