using Backend.Application.Services.Discounts.Interfaces;
using Backend.Domain.Entities.Concretes;

namespace Backend.Application.Services.Discounts.Abstracts;

public class StockAgeDiscount : IDiscount
{
    private readonly Dictionary<int, double> _discountsByAge;
    private const int MonthsInYear = 12;

    public StockAgeDiscount(Dictionary<int, double> discountsByAge)
    {
        _discountsByAge = discountsByAge ?? throw new ArgumentNullException(nameof(discountsByAge));
    }

    public double GetDiscount(Product product)
    {
        if (!product.UpdatedAt.HasValue)
        {
            return 0.0;
        }

        var monthsSinceUpdate = (DateTime.Now.Year - product.UpdatedAt.Value.Year) * MonthsInYear + DateTime.Now.Month - product.UpdatedAt.Value.Month;

        foreach (var discountAge in _discountsByAge.OrderByDescending(d => d.Key))
        {
            if (monthsSinceUpdate >= discountAge.Key)
            {
                return discountAge.Value;
            }
        }

        return 0.0;
    }
}
