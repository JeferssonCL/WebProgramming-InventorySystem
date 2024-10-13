namespace Backend.Application.Dtos
{
    public class ProductDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Brand { get; set; } = string.Empty;
        public double Price { get; set; }
        public List<string> Image { get; set; } = [];
        public List<ProductVariantDto> Variants { get; set; } = [];
    }
}