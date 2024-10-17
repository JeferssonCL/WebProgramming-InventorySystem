using Backend.Application.Handlers.Products.Requests.Queries;
using Backend.Domain.Entities.Concretes;
using Backend.Infrastructure.Repositories.Interfaces;
using MediatR;

namespace Backend.Application.Handlers.Products.RequestHandlers.Queries
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, (List<Product>, int)>
    {
        private readonly IProductRepository _productRepository;

        public GetAllProductsQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<(List<Product>, int)> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var totalProducts = await _productRepository.GetAllAsync(request.Page, request.PageSize);
            var count = await _productRepository.GetCountAsync();
            return (totalProducts.ToList(), count);
        }
    }
}