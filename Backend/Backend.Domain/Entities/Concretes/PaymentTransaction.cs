using Backend.Domain.Entities.Bases;
using Backend.Domain.Entities.Enums;

namespace Backend.Domain.Entities.Concretes;

public class PaymentTransaction : BaseEntity
{
    public Guid OrderId { get; set; }
    public PaymentMethod PaymentMethod { get; set; }
    public PaymentStatus TransactionOrderStatus { get; set; }
    public double Amount { get; set; }
    public Order Order { get; set; }
}
