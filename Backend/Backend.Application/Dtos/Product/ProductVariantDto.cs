namespace Backend.Application.Dtos
{
    public class ProductVariantDto
    {
        public Guid variantId { get; set; }
        public string? Name { get; set; }
        public ImageDto? Image { get; set; }
        public string? Value { get; set; }
    }
}