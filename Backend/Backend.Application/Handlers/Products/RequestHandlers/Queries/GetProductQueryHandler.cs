using Backend.Application.Handlers.Products.Requests.Queries;
using Backend.Domain.Entities.Concretes;
using Backend.Infrastructure.DAO.Interfaces;
using MediatR;

namespace Backend.Application.Handlers.Products.RequestHandlers.Queries
{
    public class GetProductQueryHandler : IRequestHandler<GetProductQuery, Product?>
    {
        private readonly IGenericDAO<Product> _productDao;

        public GetProductQueryHandler(IGenericDAO<Product> productDao)
        {
            _productDao = productDao;
        }
        public async Task<Product?> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            var product = await _productDao.GetByIdAsync(request.Id);
            return product;
        }
    }
}