using Backend.Domain.Entities.Bases;

namespace Backend.Domain.Entities.Concretes;

public class Shipment : BaseEntity
{
    public Guid OrderId { get; set; }
    public int TruckingNumber { get; set; }
    public DateTime ShipmentDate { get; set; }
    public DateTime EstimatedDeliveryDate { get; set; }
    public Order Order { get; set; }
    public UserAddress UserAddress { get; set; }
}