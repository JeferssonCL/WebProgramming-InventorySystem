using System.Drawing;
using Backend.Application.Handlers.Products.Requests.Queries;
using Backend.Domain.Entities.Concretes;
using Backend.Infrastructure.DAO.Interfaces;
using Backend.Infrastructure.Repositories.Interfaces;
using MediatR;

namespace Backend.Application.Handlers.Products.RequestHandlers.Queries
{
    public class GetProductQueryHandler(IProductRepository productRepository)
        : IRequestHandler<GetProductQuery, Product?>
    {
        public async Task<Product?> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            var product = await productRepository.GetByIdAsync(request.Id);
            return product;
        }
    }
}
