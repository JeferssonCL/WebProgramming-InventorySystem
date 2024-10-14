using Backend.Domain.Entities.Bases;

namespace Backend.Domain.Entities.Concretes;

public class OrderItem : BaseEntity
{
    public Guid OrderId { get; set; }
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public int DiscountPercent { get; set; }
    public double TotalPrice { get; set; }
    public Order Order { get; set; }
    public Product Product { get; set; }
}