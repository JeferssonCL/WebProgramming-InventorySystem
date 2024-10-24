using Backend.Application.Handlers.Products.Requests.Queries;
using Backend.Domain.Entities.Concretes;
using Backend.Infrastructure.Repositories.Interfaces;
using MediatR;

namespace Backend.Application.Handlers.Products.RequestHandlers.Queries
{
    public class GetAllProductsQueryHandler(IProductRepository productRepository)
        : IRequestHandler<GetAllProductsQuery, (List<Product>, int)>
    {
        public async Task<(List<Product>, int)> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var totalProducts = await productRepository.GetAllAsync(request.Page, request.PageSize);
            var count = await productRepository.GetCountAsync();
            return (totalProducts.ToList(), count);
        }
    }
}
