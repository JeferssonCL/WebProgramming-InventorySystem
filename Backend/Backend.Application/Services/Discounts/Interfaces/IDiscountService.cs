using Backend.Domain.Entities.Concretes;

namespace Backend.Application.Services.Discounts.Interfaces;
public interface IDiscountService
{
    IEnumerable<Product> ApplyDiscount(IEnumerable<Product> product);
    Product ApplyDiscount(Product products);
}
