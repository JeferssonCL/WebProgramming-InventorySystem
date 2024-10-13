using Backend.Application.Dtos.Payment;
using Backend.Application.Dtos.User;

namespace Backend.Application.Dtos.Order
{
    public class ProcessOrderDto
    {
        public List<OrderItemDto>? OrderItems { get; set; }
        public UserDto? User { get; set; }
        public PaymentMethodDto? PaymentMethod { get; set; }
        public UserAddress? UserAddress { get; set; }
        public double TotalPrice { get; set; }
    }
}