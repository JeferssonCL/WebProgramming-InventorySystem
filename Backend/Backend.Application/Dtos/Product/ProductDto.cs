namespace Backend.Application.Dtos;
public class ProductDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public double AlcoholPercentage { get; set; }
    public double Volume  { get; set; }
    public int Stock { get; set; }
    public double Price { get; set; }
    public string Brand { get; set; } = string.Empty;
    public double DiscountPercentage { get; set; }
    public double PriceWithDiscount { get; set; }
    public List<ImageDto> Images { get; set; } = [];
    public List<ProductCategoryDto> Categories { get; set; } = [];
}
