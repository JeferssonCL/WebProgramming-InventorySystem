using Backend.Application.Dtos.User;

namespace Backend.Application.Dtos
{
    public class ProcessOrderDto
    {
        public List<OrderItemDto>? OrderItems { get; set; }
        public UserDto? User { get; set; }
        public CreditCardPaymentDto? PaymentMethod { get; set; }
        public UserAddressDto? UserAddress { get; set; }
        public double TotalPrice { get; set; }
    }
}