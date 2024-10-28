using Backend.Application.Services.Discounts.Interfaces;
using Backend.Domain.Entities.Concretes;
namespace Backend.Application.Services.Discounts.Concretes;

public class DiscountService : IDiscountService
{
    private readonly List<IDiscount> _discounts;

    public DiscountService(List<IDiscount> discounts)
    {
        _discounts = discounts ?? throw new ArgumentNullException(nameof(discounts));
    }

    public IEnumerable<Product> ApplyDiscount(IEnumerable<Product> products)
    {
        foreach (var product in products)
        {
            yield return ApplyDiscount(product);
        }
    }

    public Product ApplyDiscount(Product product)
    {
        double bestPercentageDiscount = GetBestDiscountedPrice(product);
        product.PriceWithDiscount = product.Price - (bestPercentageDiscount * product.Price / 100);
        product.DiscountPercentage = bestPercentageDiscount;

        return product;
    }

    private double GetBestDiscountedPrice(Product product)
    {
        double bestDiscountedPrice = product.Price, discountedPrice = 0.0;

        foreach (var discount in _discounts)
        {
            discountedPrice = discount.GetDiscount(product);
            if (discountedPrice > 0.0 && discountedPrice < bestDiscountedPrice)
            {
                bestDiscountedPrice = discountedPrice;
            }
        }
        return discountedPrice == 0 ? 0.0 : bestDiscountedPrice;
    }
}
