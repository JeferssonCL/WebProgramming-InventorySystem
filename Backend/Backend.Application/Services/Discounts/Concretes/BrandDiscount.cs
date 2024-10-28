using Backend.Application.Services.Discounts.Interfaces;
using Backend.Domain.Entities.Concretes;

namespace Backend.Application.Services.Discounts.Concretes;

public class BrandDiscount(IDictionary<string, double> brands) : IDiscount
{
    private readonly IDictionary<string, double> _brands = brands;

    public double GetDiscount(Product product)
    {
        if (_brands.TryGetValue(product.Brand, out double value))
        {
            return value;
        }
        return 0.0;
    }
}
