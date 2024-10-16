namespace Backend.Application.Dtos;
public class ProductDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Brand { get; set; } = string.Empty;
    public double Price { get; set; }
    public ReducedStoreDto? Store { get; set; }
    public List<ImageDto> Images { get; set; } = [];
    public List<ProductVariantDto> Variants { get; set; } = [];
    public List<ProductCategoryDto> Categories { get; set; } = [];
}