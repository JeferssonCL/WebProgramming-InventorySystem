namespace Backend.Application.Dtos
{
    public class OrderItemDto
    {
        public ProductDto ProductDto { get; set; }
        public int Quantity { get; set; }
        public int Subtotal { get; set; }
    }
}