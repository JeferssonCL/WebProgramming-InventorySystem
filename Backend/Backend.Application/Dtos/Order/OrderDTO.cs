using Backend.Application.Dtos.checkoutSession;

namespace Backend.Application.Dtos.Order;

public class OrderDTO {
    public CustomerDTO Customer { get; set; }
    public string StripeSessionId { get; set; }
}
