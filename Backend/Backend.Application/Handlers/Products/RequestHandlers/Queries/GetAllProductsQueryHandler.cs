using Backend.Application.Handlers.Products.Requests.Queries;
using Backend.Application.Services.Discounts.Interfaces;
using Backend.Domain.Entities.Concretes;
using Backend.Infrastructure.Repositories.Interfaces;
using MediatR;

namespace Backend.Application.Handlers.Products.RequestHandlers.Queries
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, (List<Product>, int)>
    {
        private readonly IProductRepository _productRepository;
        private readonly IDiscountService _discountService;

        public GetAllProductsQueryHandler(IProductRepository productRepository, IDiscountService discountService)
        {
            _productRepository = productRepository;
            _discountService = discountService;
        }

        public async Task<(List<Product>, int)> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var totalProducts = await _productRepository.GetAllAsync(request.Page, request.PageSize);
            var count = await _productRepository.GetCountAsync();

            var products =_discountService.ApplyDiscount(totalProducts);

            return (products.ToList(), count);
        }
    }
}
