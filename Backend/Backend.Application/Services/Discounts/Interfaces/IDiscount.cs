using Backend.Domain.Entities.Concretes;

namespace Backend.Application.Services.Discounts.Interfaces;
public interface IDiscount
{
    double GetDiscount(Product product);
}
