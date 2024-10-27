using System.Drawing;
using Backend.Application.Handlers.Products.Requests.Queries;
using Backend.Application.Services.Discounts.Interfaces;
using Backend.Domain.Entities.Concretes;
using Backend.Infrastructure.Repositories.Interfaces;
using MediatR;

namespace Backend.Application.Handlers.Products.RequestHandlers.Queries
{
    public class GetProductQueryHandler(IProductRepository productRepository, IDiscountService discountService)
        : IRequestHandler<GetProductQuery, Product?>
    {
        private readonly IProductRepository _productRepository = productRepository;
        private readonly IDiscountService _discountService = discountService;
        public async Task<Product?> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByIdAsync(request.Id);
            if (product is null) return null;
            return _discountService.ApplyDiscount(product);
        }
    }
}
