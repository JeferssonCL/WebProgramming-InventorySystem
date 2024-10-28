using Backend.Application.Handlers.Combos.Requests.Queries;
using Backend.Application.Services.Discounts.Interfaces;
using Backend.Domain.Entities.Concretes;
using Backend.Infrastructure.Repositories.Interfaces;
using MediatR;

namespace Backend.Application.Handlers.Combos.RequestHandlers.Queries;

public class GetAllDiscountProductsQueryHandler(IProductRepository productRepository, IDiscountService discountService)
    : IRequestHandler<GetAllDiscountProductsQuery, (List<Product>, int)>
{
    public async Task<(List<Product>, int)> Handle(GetAllDiscountProductsQuery request, CancellationToken cancellationToken)
    {
        int total = await productRepository.GetCountAsync();
        var products = await productRepository.GetAllAsync(1, total);

        var discountedProducts = products
            .Where(p => discountService.ApplyDiscount(p).DiscountPercentage > 0);

        var pageDiscount = discountedProducts
                            .Skip((request.Page - 1) * request.PageSize)
                            .Take(request.PageSize);

        return (pageDiscount.ToList(), discountedProducts.Count());
    }
}
