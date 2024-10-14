using Backend.Domain.Entities.Concretes;
using Backend.Infrastructure.Context;
using Backend.Infrastructure.DAO.Bases;
using Microsoft.EntityFrameworkCore;

namespace Backend.Infrastructure.DAO.Concretes;

public class ProductDAO(PostgresContext context) : GenericDAO<Product>(context)
{
    public override async Task<IEnumerable<Product>> GetAllAsync()
    {
        return await context.Set<Product>()
             .Include(p => p.Store)
             .Include(p => p.Images) 
             .ToListAsync();
    }

}