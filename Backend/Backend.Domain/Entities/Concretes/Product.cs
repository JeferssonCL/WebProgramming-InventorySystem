using Backend.Domain.Entities.Bases;

namespace Backend.Domain.Entities.Concretes;

public class Product : BaseEntity
{
    public Guid StoreId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public double Price { get; set; }
    public string Brand { get; set; }
    public int StockQuantity { get; set; }
    public Store Store { get; set; }
    public OrderItem OrderItem { get; set; }
    public ICollection<Image> Images { get; set; }
    public ICollection<ProductAttribute> ProductAttributes { get; set; }
    public ICollection<Category> Categories { get; set; }
}