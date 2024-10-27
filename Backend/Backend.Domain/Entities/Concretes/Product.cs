using Backend.Domain.Entities.Bases;

namespace Backend.Domain.Entities.Concretes;

public class Product : BaseEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public double Price { get; set; }
    public string Brand { get; set; }
    public double AlcoholPercentage { get; set; }
    public double Volume { get; set; }
    public int Stock { get; set; }
    public double DiscountPercentage { get; set; }
    public double PriceWithDiscount { get; set; }
    public OrderItem OrderItem { get; set; }
    public ICollection<Image> Images { get; set; }
    public ICollection<Category> Categories { get; set; }
}
