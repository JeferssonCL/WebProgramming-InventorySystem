using Backend.Domain.Entities.Bases;
using Backend.Domain.Entities.Enums;

namespace Backend.Domain.Entities.Concretes;

public class Order : BaseEntity
{
    public Guid UserId { get; set; }
    public DateTime OrderDate { get; set; }
    public Status OrderStatus { get; set; }
    public double TotalPrice { get; set; }
    public User User { get; set; }
    public Shipment Shipment { get; set; }
    public PaymentTransaction PaymentTransaction { get; set; }
    public ICollection<OrderItem> OrderItems { get; set; }
}