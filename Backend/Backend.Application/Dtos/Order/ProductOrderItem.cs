namespace Backend.Application.Dtos
{
    public class ProductOrderItem
    {
        public Guid Id { get; set; }
        public Guid VariantId { get; set; }

        public string Name { get; set; } = string.Empty;
        public double Price { get; set; }
        public string Image { get; set; } = string.Empty;
        public Dictionary<string, string> Attributes = [];
    }
}