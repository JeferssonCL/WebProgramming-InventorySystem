namespace Backend.Application.Dtos
{
    public class ProductVariantDto
    {
        public Guid variantId { get; set; }
        public ImageDto? Image { get; set; }
        public double Price { get; set; }
        public List<ProductAttributeDto>? Attributes { get; set; } = [];
    }
}