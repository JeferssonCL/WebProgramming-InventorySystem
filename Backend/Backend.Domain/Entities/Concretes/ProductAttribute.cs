using Backend.Domain.Entities.Bases;

namespace Backend.Domain.Entities.Concretes;

public class ProductAttribute : BaseEntity
{
    public Guid ImageId { get; set; }
    public Guid ProductId { get; set; }
    public Guid VariantId { get; set; }
    public string Value { get; set; }
    public Variant Variant { get; set; }
    public Image Image { get; set; }
    public Product Product { get; set; }
}