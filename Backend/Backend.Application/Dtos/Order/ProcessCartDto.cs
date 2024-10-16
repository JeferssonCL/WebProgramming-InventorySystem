using Backend.Application.Dtos.User;

namespace Backend.Application.Dtos
{
    public class ProcessCartDto
    {
        public List<CartItem>? CartItems { get; set; }
        public UserDto? User { get; set; }
        public UserAddressDto? UserAddress { get; set; }
        public double TotalPrice { get; set; }
    }
}