namespace Backend.Application.Dtos
{
    public class CartItem
    {
        public Guid Id { get; set; }
        public Guid VariantId { get; set; }
        public string Name { get; set; } = string.Empty;
        public double Price { get; set; }
        public string Image { get; set; } = string.Empty;
        public Dictionary<string, string> Attributes = [];
        public double Quantity { get; set; }
        public double Subtotal { get; set; }
    }
}