using Stripe;

namespace Backend.Application.Dtos.checkoutSession;

public class CustomerDTO
{
    public Guid Id { get; set; }
    public string Email { get; set; }
    public string Address { get; set; }
    public string City { get; set; }
    public string Country { get; set; }
}
