using Backend.Application.Handlers.Products.Requests.Queries;
using Backend.Domain.Entities.Concretes;
using Backend.Infrastructure.DAO.Interfaces;
using MediatR;

namespace Backend.Application.Handlers.Products.RequestHandlers.Queries
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, (List<Product>, int)>
    {
        private readonly IGenericDAO<Product> _productDao;

        public GetAllProductsQueryHandler(IGenericDAO<Product> productDao)
        {
            _productDao = productDao;
        }

        public async Task<(List<Product>, int)> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var totalProducts = await _productDao.GetAllAsync();

            int total = totalProducts.Count();
            totalProducts = totalProducts
                .Skip((request.Page - 1) * request.PageSize)
                .Take(request.PageSize);
                
            return (totalProducts.ToList(), total);
        }
    }
}