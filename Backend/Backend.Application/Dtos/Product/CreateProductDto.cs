using Backend.Domain.Entities.Concretes;

namespace Backend.Application.Dtos
{
    public class CreateProductDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Brand { get; set; } = string.Empty;
        public double Price { get; set; }
        public int StockQuantity { get; set; }
        public Guid StoreId { get; set; }
        public List<ImageDto> Images { get; set; } = [];
        public List<ProductVariantDto> Variants { get; set; } = [];
        public List<Guid> Categories { get; set; } = [];
    }
}