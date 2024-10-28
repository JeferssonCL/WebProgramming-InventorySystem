using Backend.Domain.Entities.Bases;

namespace Backend.Domain.Entities.Concretes;

public class Combo : BaseEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public double Price { get; set; }
    public int DiscountPercent { get; set; }
    public ICollection<Product> Products { get; set; }
}
