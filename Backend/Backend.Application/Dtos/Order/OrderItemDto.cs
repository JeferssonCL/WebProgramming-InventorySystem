namespace Backend.Application.Dtos
{
    public class OrderItemDto
    {
        public ProductOrderItem? Product { get; set; }
        public int Quantity { get; set; }
        public int Subtotal { get; set; }
    }
}