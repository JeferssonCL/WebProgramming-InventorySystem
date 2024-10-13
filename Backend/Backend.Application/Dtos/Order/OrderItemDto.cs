namespace Backend.Application.Dtos
{
    public class OrderItemDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public double Price { get; set; }
        public int Quantity { get; set; }
        public int Subtotal { get; set; }
    }
}